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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Runic.CIL.ToSSA.ExceptionHandlersMap;

namespace Runic.CIL
{
    public abstract partial class ToSSA
    {
        class Destackifier : Runic.CIL.Destackifier
        {
            ToSSA _parent;
            SSAConverter _converter;
            ExceptionHandlersMap _handlersMap;
            public Destackifier(ToSSA parent, SSAConverter converter, ExceptionHandlersMap exceptionHandlersMap)
            {
                _parent = parent;
                _converter = converter;
                _handlersMap = exceptionHandlersMap;
            }
            void EmitSilentThrow(int offset)
            {
                List<int> offsets = new List<int>();
#if NET6_0_OR_GREATER
                ExceptionHandler? exceptionHandler = _handlersMap[offset];
#else
                ExceptionHandler exceptionHandler = _handlersMap[offset];
#endif
                if (exceptionHandler != null)
                {
                    while (exceptionHandler != null)
                    {
                        foreach (ToSSA.ExceptionHandlingClause.Clause clause in exceptionHandler.Clauses) { offsets.Add(clause.HandlerOffset); }
                        foreach (ToSSA.ExceptionHandlingClause.Filter filter in exceptionHandler.Filters) { offsets.Add(filter.HandlerOffset); }
                        exceptionHandler = exceptionHandler.Parent;
                    }
                    _converter.EmitSwitch(offset, new Instruction.SilentThrow(), new int[] { }, offsets.ToArray());
                }
            }
            public override byte[] GetMethodSignature(uint methodToken) { return _parent.GetMethodSignature(methodToken); }
            public override void Add(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Add(), destination, new int[] { a, b }); }
            public override void AddOvf(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.AddOvf(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void AddOvfUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.AddOvfUn(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void And(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.And(), destination, new int[] { a, b }); }
            public override void ArgList(int offset, int destination) { _converter.EmitAssignment(offset, new Instruction.ArgList(), destination, new int[] { }); }
            public override void Box(int offset, uint typeToken, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.Box(typeToken), destination, new int[] { source }); }
            public override void Sub(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Sub(), destination, new int[] { a, b }); }
            public override void SubOvf(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.SubOvf(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void SubOvfUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.SubOvfUn(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void Mul(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Mul(), destination, new int[] { a, b }); }
            public override void MulOvf(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.MulOvf(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void MulOvfUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.MulOvfUn(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void Div(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Div(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void DivUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.DivUn(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void Rem(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Rem(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void RemUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.RemUn(), destination, new int[] { a, b }); EmitSilentThrow(offset); }
            public override void Or(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Or(), destination, new int[] { a, b }); }
            public override void Xor(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Xor(), destination, new int[] { a, b }); }
            public override void Shl(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Shl(), destination, new int[] { a, b }); }
            public override void Shr(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Shr(), destination, new int[] { a, b }); }
            public override void ShrUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.ShrUn(), destination, new int[] { a, b }); }
            public override void LdArg(int offset, int destination, int index) { _converter.EmitAssignment(offset, new Instruction.LdArg(index), destination, new int[] { }); }
            public override void LdArgA(int offset, int destination, int index) { _converter.EmitAssignment(offset, new Instruction.LdArgA(index), destination, new int[] { }); }
            public override void StArg(int offset, int index, int source) { _converter.EmitStatement(offset, new Instruction.StArg(index), new int[] { source }); }
            public override void LdcI4(int offset, int destination, int value) { _converter.EmitAssignment(offset, new Instruction.LdcI4(value), destination, new int[] { }); }
            public override void LdcI8(int offset, int destination, long value) { _converter.EmitAssignment(offset, new Instruction.LdcI8(value), destination, new int[] { }); }
            public override void LdcR4(int offset, int destination, float value) { _converter.EmitAssignment(offset, new Instruction.LdcR4(value), destination, new int[] { }); }
            public override void LdcR8(int offset, int destination, double value) { _converter.EmitAssignment(offset, new Instruction.LdcR8(value), destination, new int[] { }); }
            public override void LdLocA(int offset, int destination, int index) { _converter.EmitAssignment(offset, new Instruction.LdLocA(), destination, new int[] { index }); }
            public override void StLoc(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.StLoc(), destination, new int[] { source }); }
            public override void Ceq(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Ceq(), destination, new int[] { a, b }); }
            public override void Cgt(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Cgt(), destination, new int[] { a, b }); }
            public override void CgtUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.CgtUn(), destination, new int[] { a, b }); }
            public override void Clt(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.Clt(), destination, new int[] { a, b }); }
            public override void CltUn(int offset, int destination, int a, int b) { _converter.EmitAssignment(offset, new Instruction.CltUn(), destination, new int[] { a, b }); }
            public override void Neg(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.Neg(), destination, new int[] { source }); }
            public override void Not(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.Not(), destination, new int[] { source }); }
            public override void LdNull(int offset, int destination) { _converter.EmitAssignment(offset, new Instruction.LdNull(), destination, new int[] { }); }
            public override void NewObj(int offset, uint ctorToken, int destination, int[] parameters) { _converter.EmitAssignment(offset, new Instruction.NewObj(ctorToken), destination, parameters); EmitSilentThrow(offset); }
            public override void ConvI(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvI(), destination, new int[] { source }); }
            public override void ConvI1(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvI1(), destination, new int[] { source }); }
            public override void ConvI2(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvI2(), destination, new int[] { source }); }
            public override void ConvI4(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvI4(), destination, new int[] { source }); }
            public override void ConvI8(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvI8(), destination, new int[] { source }); }
            public override void ConvU(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvU(), destination, new int[] { source }); }
            public override void ConvU1(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvU1(), destination, new int[] { source }); }
            public override void ConvU2(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvU2(), destination, new int[] { source }); }
            public override void ConvU4(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvU4(), destination, new int[] { source }); }
            public override void ConvU8(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvU8(), destination, new int[] { source }); }
            public override void ConvR4(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvR4(), destination, new int[] { source }); }
            public override void ConvR8(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvR8(), destination, new int[] { source }); }
            public override void ConvOvfI(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI(), destination, new int[] { source }); }
            public override void ConvOvfI1(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI1(), destination, new int[] { source }); }
            public override void ConvOvfI2(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI2(), destination, new int[] { source }); }
            public override void ConvOvfI4(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI4(), destination, new int[] { source }); }
            public override void ConvOvfI8(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI8(), destination, new int[] { source }); }
            public override void ConvOvfI1Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI1Un(), destination, new int[] { source }); }
            public override void ConvOvfI2Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI2Un(), destination, new int[] { source }); }
            public override void ConvOvfI4Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI4Un(), destination, new int[] { source }); }
            public override void ConvOvfI8Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfI8Un(), destination, new int[] { source }); }
            public override void ConvOvfIUn(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfIUn(), destination, new int[] { source }); }
            public override void ConvOvfU(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU(), destination, new int[] { source }); }
            public override void ConvOvfU1(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU1(), destination, new int[] { source }); }
            public override void ConvOvfU2(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU2(), destination, new int[] { source }); }
            public override void ConvOvfU4(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU4(), destination, new int[] { source }); }
            public override void ConvOvfU8(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU8(), destination, new int[] { source }); }
            public override void ConvOvfU1Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU1Un(), destination, new int[] { source }); }
            public override void ConvOvfU2Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU2Un(), destination, new int[] { source }); }
            public override void ConvOvfU4Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU4Un(), destination, new int[] { source }); }
            public override void ConvOvfU8Un(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfU8Un(), destination, new int[] { source }); }
            public override void ConvOvfUUn(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvOvfUUn(), destination, new int[] { source }); }
            public override void ConvRUn(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.ConvRUn(), destination, new int[] { source }); }
            public override void Call(int offset, bool tail, uint methodToken, int destination, int[] parameters) { _converter.EmitAssignment(offset, new Instruction.Call(tail, methodToken), destination, parameters); EmitSilentThrow(offset); }
            public override void Call(int offset, bool tail, uint methodToken, int[] parameters) { _converter.EmitStatement(offset, new Instruction.CallProc(tail, methodToken), parameters); EmitSilentThrow(offset); }
            public override void CallI(int offset, bool tail, uint signatureToken, int destination, int[] parameters) { _converter.EmitAssignment(offset, new Instruction.CallI(tail, signatureToken), destination, parameters); EmitSilentThrow(offset); }
            public override void CallI(int offset, bool tail, uint signatureToken, int[] parameters) { _converter.EmitStatement(offset, new Instruction.CallIProc(tail, signatureToken), parameters); EmitSilentThrow(offset); }
            public override void CallVirt(int offset, bool noNullCheck, bool tail, uint methodToken, int destination, int[] parameters) { _converter.EmitAssignment(offset, new Instruction.CallVirt(noNullCheck, tail, methodToken), destination, parameters); EmitSilentThrow(offset); }
            public override void CallVirt(int offset, bool noNullCheck, bool tail, uint methodToken, int[] parameters) { _converter.EmitStatement(offset, new Instruction.CallVirtProc(noNullCheck, tail, methodToken), parameters); EmitSilentThrow(offset); }
            public override void LdLen(int offset, int destination, int array) { _converter.EmitAssignment(offset, new Instruction.LdLen(), destination, new int[] { array }); EmitSilentThrow(offset); }
            public override void StObj(int offset, bool volatilePrefix, int alignment, uint typeToken, int address, int value) { _converter.EmitStatement(offset, new Instruction.StObj(volatilePrefix, alignment, typeToken), new int[] { address, value }); }
            public override void LdObj(int offset, bool volatilePrefix, int alignment, uint typeToken, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.StObj(volatilePrefix, alignment, typeToken), destination, new int[] { address }); }
            public override void LdSFld(int offset, bool volatilePrefix, uint fieldToken, int destination) { _converter.EmitAssignment(offset, new Instruction.LdSFld(volatilePrefix, fieldToken), destination, new int[] { }); }
            public override void LdSFldA(int offset, uint fieldToken, int destination) { _converter.EmitAssignment(offset, new Instruction.LdSFldA(fieldToken), destination, new int[] { }); }
            public override void LdFld(int offset, bool noNullCheck, bool volatilePrefix, int alignment, uint fieldToken, int destination, int obj) { _converter.EmitAssignment(offset, new Instruction.LdFld(noNullCheck, volatilePrefix, alignment, fieldToken), destination, new int[] { obj }); if (!noNullCheck) { EmitSilentThrow(offset); } }
            public override void LdFldA(int offset, uint fieldToken, int destination, int obj) { _converter.EmitAssignment(offset, new Instruction.LdFldA(fieldToken), destination, new int[] { obj }); EmitSilentThrow(offset); }
            public override void StFld(int offset, bool noNullCheck, bool volatilePrefix, int alignment, uint fieldToken, int obj, int value) { _converter.EmitStatement(offset, new Instruction.StFld(noNullCheck, volatilePrefix, alignment, fieldToken), new int[] { obj, value }); if (!noNullCheck) { EmitSilentThrow(offset); } }
            public override void LdElem(int offset, bool noNullCheck, bool noBoundCheck, uint typeToken, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElem(noNullCheck, noBoundCheck, typeToken), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemA(int offset, bool noNullCheck, bool noTypeCheck, bool noBoundCheck, bool readOnly, uint typeToken, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemA(noNullCheck, noTypeCheck, noBoundCheck, readOnly, typeToken), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck || !noTypeCheck) { EmitSilentThrow(offset); } }
            public override void LdElemI(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemI(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemI1(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemI1(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemI2(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemI2(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemI4(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemI4(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemI8(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemI8(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemR4(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemR4(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemR8(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemR8(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemU1(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemU1(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemU2(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemU2(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemU4(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemU4(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdElemRef(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { _converter.EmitAssignment(offset, new Instruction.LdElemRef(noNullCheck, noBoundCheck), destination, new int[] { array, index }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElem(int offset, bool noNullCheck, bool noTypeCheck, bool noBoundCheck, uint typeToken, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElem(noNullCheck, noBoundCheck, typeToken), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck || !noTypeCheck) { EmitSilentThrow(offset); } }
            public override void StElemI(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemI(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemI1(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemI1(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemI2(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemI2(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemI4(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemI4(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemI8(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemI8(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemR4(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemR4(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemR8(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemR8(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void StElemRef(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { _converter.EmitStatement(offset, new Instruction.StElemRef(noNullCheck, noBoundCheck), new int[] { array, index, value }); if (!noNullCheck || !noBoundCheck) { EmitSilentThrow(offset); } }
            public override void LdIndI1(int offset, bool volatilePrefix, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndI1(volatilePrefix), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndI2(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndI2(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndI4(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndI4(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndI8(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndI8(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndR4(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndR4(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndR8(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndR8(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndI(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndI(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndU1(int offset, bool volatilePrefix, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndU1(volatilePrefix), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndU2(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndU2(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndU4(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndU4(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void LdIndRef(int offset, bool volatilePrefix, int alignment, int destination, int address) { _converter.EmitAssignment(offset, new Instruction.LdIndRef(volatilePrefix, alignment), destination, new int[] { address }); EmitSilentThrow(offset); }
            public override void StIndI1(int offset, bool volatilePrefix, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndI1(volatilePrefix), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndI2(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndI2(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndI4(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndI4(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndI8(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndI8(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndR4(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndR4(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndR8(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndR8(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndRef(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndRef(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StIndI(int offset, bool volatilePrefix, int alignment, int address, int value) { _converter.EmitStatement(offset, new Instruction.StIndI(volatilePrefix, alignment), new int[] { address, value }); EmitSilentThrow(offset); }
            public override void StSFld(int offset, bool volatilePrefix, uint fieldToken, int value) { _converter.EmitStatement(offset, new Instruction.StSFld(volatilePrefix, fieldToken), new int[] { value }); EmitSilentThrow(offset); }
            public override void NewArr(int offset, uint typeToken, int destination, int size) { _converter.EmitAssignment(offset, new Instruction.NewArr(typeToken), destination, new int[] { size }); EmitSilentThrow(offset); }
            public override void Unbox(int offset, bool noTypeCheck, uint typeToken, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.Unbox(noTypeCheck, typeToken), destination, new int[] { source }); }
            public override void UnboxAny(int offset, uint typeToken, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.UnboxAny(typeToken), destination, new int[] { source }); }
            public override void SizeOf(int offset, uint typeToken, int destination) { _converter.EmitAssignment(offset, new Instruction.SizeOf(typeToken), destination, new int[] { }); EmitSilentThrow(offset); }
            public override void Br(int offset, int address) { _converter.EmitBranch(offset, new Instruction.Br(), new int[] { }, false, address); }
            public override void BrTrue(int offset, int address, int condition) { _converter.EmitBranch(offset, new Instruction.BrTrue(), new int[] { condition }, true, address); }
            public override void BrFalse(int offset, int address, int condition) { _converter.EmitBranch(offset, new Instruction.BrFalse(), new int[] { condition }, true, address); }
            public override void BrEq(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrEq(), new int[] { a, b }, true, address); }
            public override void BrGe(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrGe(), new int[] { a, b }, true, address); }
            public override void BrGeUn(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrGeUn(), new int[] { a, b }, true, address); }
            public override void BrGt(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrGt(), new int[] { a, b }, true, address); }
            public override void BrLe(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrLe(), new int[] { a, b }, true, address); }
            public override void BrGtUn(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrGtUn(), new int[] { a, b }, true, address); }
            public override void BrLeUn(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrLeUn(), new int[] { a, b }, true, address); }
            public override void BrLt(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrLt(), new int[] { a, b }, true, address); }
            public override void BrLtUn(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrLtUn(), new int[] { a, b }, true, address); }
            public override void BrNeqUn(int offset, int address, int a, int b) { _converter.EmitBranch(offset, new Instruction.BrNeqUn(), new int[] { a, b }, true, address); }
            public override void Switch(int offset, int[] addresses, int value) { _converter.EmitSwitch(offset, new Instruction.Switch(), new int[] { value }, addresses); }
            public override void Nop(int offset) { _converter.EmitStatement(offset, new Instruction.Nop(), new int[] { }); }
            public override void Ret(int offset) { _converter.EmitStatement(offset, new Instruction.Ret(), new int[] { }); }
            public override void Ret(int offset, int value) { _converter.EmitStatement(offset, new Instruction.RetValue(), new int[] { value }); }
            public override void CpObj(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.CpObj(), destination, new int[] { source }); EmitSilentThrow(offset); }
            public override void InitObj(int offset, uint typeToken, int destination) { _converter.EmitAssignment(offset, new Instruction.InitObj(typeToken), destination, new int[] { }); }
            public override void InitBlk(int offset, bool volatilePrefix, int alignment, int destination, int value, int size) { _converter.EmitStatement(offset, new Instruction.InitBlk(volatilePrefix, alignment), new int[] { destination, value, size }); EmitSilentThrow(offset); }
            public override void CpBlk(int offset, bool volatilePrefix, int alignment, int destination, int source, int size) { _converter.EmitStatement(offset, new Instruction.CpBlk(volatilePrefix, alignment), new int[] { destination, source, size }); EmitSilentThrow(offset); }
            public override void LdStr(int offset, uint literalStringToken, int destination) { _converter.EmitAssignment(offset, new Instruction.LdStr(literalStringToken), destination, new int[] { }); }
            public override void IsInst(int offset, uint typeToken, int destination, int value) { _converter.EmitAssignment(offset, new Instruction.IsInst(typeToken), destination, new int[] { value }); }
            public override void LdToken(int offset, uint token, int destination) { _converter.EmitAssignment(offset, new Instruction.LdToken(token), destination, new int[] { }); EmitSilentThrow(offset); }
            public override void LdVirtFtn(int offset, bool noNullCheck, uint methodToken, int destination, int obj) { _converter.EmitAssignment(offset, new Instruction.LdVirtFtn(noNullCheck, methodToken), destination, new int[] { obj }); }
            public override void CkFinite(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.CkFinite(), destination, new int[] { source }); EmitSilentThrow(offset); }
            public override void MkRefAny(int offset, uint token, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.MkRefAny(token), destination, new int[] { source }); EmitSilentThrow(offset); }
            public override void RefAnyVal(int offset, uint token, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.RefAnyVal(token), destination, new int[] { source }); EmitSilentThrow(offset); }
            public override void RefAnyType(int offset, int destination, int source) { _converter.EmitAssignment(offset, new Instruction.RefAnyType(), destination, new int[] { source }); EmitSilentThrow(offset); }
            public override void Jmp(int offset, uint methodToken) { _converter.EmitStatement(offset, new Instruction.Jmp(methodToken), new int[] { }); }
            public override void LocAlloc(int offset, int destination, int size) { _converter.EmitAssignment(offset, new Instruction.LocAlloc(), destination, new int[] { size }); EmitSilentThrow(offset); }
            public override void StException(int offset, int destination) { _converter.EmitAssignment(offset, new Instruction.StException(), destination, new int[] { }); }
            public override void Break(int offset) { _converter.EmitStatement(offset, new Instruction.Break(), new int[] { }); }
            public override void CastClass(int offset, bool noTypeCheck, uint typeToken, int destination, int value) { _converter.EmitAssignment(offset, new Instruction.CastClass(noTypeCheck, typeToken), destination, new int[] { value }); if (!noTypeCheck) { EmitSilentThrow(offset); } }
            public override void LdFtn(int offset, uint methodToken, int destination) { _converter.EmitAssignment(offset, new Instruction.LdFnt(methodToken), destination, new int[] { }); EmitSilentThrow(offset); }
            public override void Throw(int offset, int exception)
            {
#if NET6_0_OR_GREATER
                ExceptionHandler? exceptionHandler = _handlersMap[offset];
#else
                ExceptionHandler exceptionHandler = _handlersMap[offset];
#endif
                if (exceptionHandler != null)
                {
                    List<int> offsets = new List<int>();
                    while (exceptionHandler != null)
                    {
                        foreach (ToSSA.ExceptionHandlingClause.Clause clause in exceptionHandler.Clauses) { offsets.Add(clause.HandlerOffset); }
                        foreach (ToSSA.ExceptionHandlingClause.Filter filter in exceptionHandler.Filters) { offsets.Add(filter.HandlerOffset); }
                        exceptionHandler = exceptionHandler.Parent;
                    }
                    _converter.EmitSwitch(offset, new Instruction.Throw(), new int[] { exception }, offsets.ToArray());
                }
                else
                {
                    _converter.EmitStatement(offset, new Instruction.Throw(), new int[] { exception });
                }
            }
            public override void Rethrow(int offset)
            {
                throw new NotImplementedException("Exception handling not yet supported in ToSSA destackifier.");
            }
            public override void Leave(int offset, int address)
            {
#if NET6_0_OR_GREATER
                ExceptionHandler? exceptionHandler = _handlersMap[offset];
#else
                ExceptionHandler exceptionHandler = _handlersMap[offset];
#endif
                if (exceptionHandler != null)
                {
                    List<int> offsets = new List<int>();
                    if (exceptionHandler != null && exceptionHandler.Finally != null)
                    {
                        _converter.EmitBranch(offset, new Instruction.Leave(address), new int[] { }, false, exceptionHandler.Finally.HandlerOffset);
                        return;
                    }
                }

                _converter.EmitBranch(offset, new Instruction.Leave(address), new int[] { }, false, address);
            }
            public override void EndFilter(int offset, int value)
            {
#if NET6_0_OR_GREATER
                ToSSA.ExceptionHandlingClause.Filter? currentFilter = _handlersMap.FilterMap[offset];
                ToSSA.ExceptionHandlingClause? nextClause = null;
                ExceptionHandler? exceptionHandler = null;
#else
                ToSSA.ExceptionHandlingClause.Filter currentFilter = _handlersMap.FilterMap[offset];
                ToSSA.ExceptionHandlingClause nextClause = null;
                ExceptionHandler exceptionHandler = null;
#endif
                if (currentFilter != null)
                {
                    exceptionHandler = currentFilter.Parent;
                    bool foundCurrentFilter = false;
                    foreach (ToSSA.ExceptionHandlingClause.Filter filter in exceptionHandler.Filters)
                    {
                        if (filter.FilterOffset == currentFilter.FilterOffset && filter.HandlerOffset == currentFilter.HandlerOffset)
                        {
                            foundCurrentFilter = true;
                        }
                        else if (foundCurrentFilter)
                        {
                            nextClause = filter;
                            break;
                        }
                    }

                    if (nextClause == null)
                    {
                        while (exceptionHandler != null && nextClause == null)
                        {
                            foreach (ToSSA.ExceptionHandlingClause.Clause clause in exceptionHandler.Clauses)
                            {
                                nextClause = clause;
                            }
                            if (nextClause == null) { nextClause = exceptionHandler.Finally; }
                            exceptionHandler = exceptionHandler.Parent;
                        }
                    }
                }
                if (nextClause != null)
                {
                    _converter.EmitBranch(offset, new Instruction.EndFilter(), new int[] { value }, true, nextClause.HandlerOffset);
                }
                else
                {
                    _converter.EmitStatement(offset, new Instruction.EndFilter(), new int[] { value });
                }
            }
            public override void EndFinally(int offset)
            {
                _converter.EmitStatement(offset, new Instruction.EndFinally(), new int[] { });
            }
        }
    }
}
