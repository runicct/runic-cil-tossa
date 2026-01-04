/*
 * MIT License
 * 
 * Copyright (c) 2026 Runic Compiler Toolkit Contributors
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Net;
using static Runic.CIL.ToSSA.Instruction;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Runic.CIL
{
    public abstract partial class ToSSA
    {
        internal class ExceptionHandlersMap
        {
            public class ExceptionHandler
            {
                int _tryOffset;
                internal int TryOffset { get { return _tryOffset; } }
                uint _tryLength;
                internal uint TryLength { get { return _tryLength; } }
                ExceptionHandler? _parent = null;
                public ExceptionHandler? Parent { get { return _parent; } set { _parent = value; } }
                List<ExceptionHandlingClause.Clause> _clauses = new List<ExceptionHandlingClause.Clause>();
                public IEnumerable<ExceptionHandlingClause.Clause> Clauses { get { return _clauses; } }
                List<ExceptionHandlingClause.Filter> _filters = new List<ExceptionHandlingClause.Filter>();
                public IEnumerable<ExceptionHandlingClause.Filter> Filters { get { return _filters; } }
                ExceptionHandlingClause.Finally? _finally = null;
                public ExceptionHandlingClause.Finally? Finally { get { return _finally; } }
                public void AddClause(ExceptionHandlingClause clause)
                {
                    switch (clause)
                    {
                        case ExceptionHandlingClause.Clause c:
                            _clauses.Add(c);
                            break;
                        case ExceptionHandlingClause.Filter f:
                            _filters.Add(f);
                            break;
                        case ExceptionHandlingClause.Finally @finally:
                            if (_finally != null)
                            {
                                throw new InvalidOperationException("An exception handler can only have one finally clause.");
                            }
                            _finally = @finally;
                            break;
                    }
                    clause.Parent = this;
                }
                internal ExceptionHandler(int tryOffset, uint tryLength)
                {
                    _tryOffset = tryOffset;
                    _tryLength = tryLength;
                }
            }

            public ExceptionHandlersMap(int bytecodeLength)
            {
                _handlers = new ExceptionHandler[bytecodeLength];
                _filterMap = new ToSSA.ExceptionHandlingClause.Filter[bytecodeLength];
            }

            ExceptionHandler[] _handlers;
            public ExceptionHandler? this[int offset] { get  { return _handlers[offset]; } }

            ToSSA.ExceptionHandlingClause.Filter[] _filterMap;
            public ToSSA.ExceptionHandlingClause.Filter[] FilterMap { get { return _filterMap; } }

            Dictionary<ulong, ExceptionHandler> _handlersMap = new Dictionary<ulong, ExceptionHandler>();

            void MapFilterRegion(ExceptionHandlingClause.Filter filter)
            {
                int start = filter.FilterOffset;
                int end = filter.HandlerOffset;
                for (int n = start; n < end; n++)
                {
                    if (_filterMap[n] != null)
                    {
                        if (_filterMap[n].FilterOffset >= filter.FilterOffset &&
                            _filterMap[n].HandlerOffset <= filter.HandlerOffset)
                        {
                            continue;
                        }
                    }
                    _filterMap[n] = filter;
                }
            }

            public void AddClause(ExceptionHandlingClause clause)
            {
                ulong id = ((ulong)clause.TryLength << 32) + (ulong)clause.TryOffset;
                ExceptionHandler handler;
                if (!_handlersMap.TryGetValue(id, out handler))
                {
                    handler = new ExceptionHandler(clause.TryOffset, clause.TryLength);
                    _handlersMap.Add(id, handler);
                }
                handler.AddClause(clause);
                int start = handler.TryOffset;
                int end = handler.TryOffset + (int)handler.TryLength;
                for (int n = start; n < end; n++)
                {
                    ExceptionHandler? existingHandler = _handlers[n];
                    if (existingHandler == null)
                    {
                        _handlers[n] = handler;
                        continue;
                    }
                    if (existingHandler.TryOffset == handler.TryOffset && existingHandler.TryLength == handler.TryLength) { continue; }
                    if (existingHandler.TryOffset <= handler.TryOffset &&
                        (existingHandler.TryOffset + (int)existingHandler.TryLength) >= (handler.TryOffset + (int)handler.TryLength))
                    {
                        handler.Parent = existingHandler;
                        _handlers[n] = handler;
                        continue;
                    }
                    ExceptionHandler? parent = existingHandler.Parent;
                    while (true)
                    {
                        if (parent == null)
                        {
                            existingHandler.Parent = handler;
                            break;
                        }

                        if (parent.TryOffset == handler.TryOffset && parent.TryLength == handler.TryLength) { break; }

                        if (parent.TryOffset <= handler.TryOffset &&
                            (parent.TryOffset + (int)parent.TryLength) >= (handler.TryOffset + (int)handler.TryLength))
                        {
                            handler.Parent = parent;
                            existingHandler.Parent = handler;
                            break;
                        }
                        existingHandler = parent;
                        parent = existingHandler.Parent;
                    }
                }

                switch (clause)
                {
                    case ExceptionHandlingClause.Filter filter:
                        MapFilterRegion(filter);
                        break;
                }
            }
        }
    }
}