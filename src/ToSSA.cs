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

using static Runic.CIL.ToSSA;
using static Runic.CIL.ToSSA.ExceptionHandlersMap;
using static Runic.CIL.ToSSA.ExceptionHandlingClause;
using static Runic.CIL.ToSSA.Instruction;

namespace Runic.CIL
{
    public abstract partial class ToSSA
    {
        public class ExceptionHandlingClause
        {
            public class Filter : ExceptionHandlingClause
            {
                int _filterOffset;
                internal int FilterOffset { get { return _filterOffset; } }
           
                public Filter(int tryOffset, uint tryLength, int filterOffset, int handlerOffset) : base(tryOffset, tryLength, handlerOffset) { _filterOffset = filterOffset; }
            }
            public class Clause : ExceptionHandlingClause
            {
                public Clause(int tryOffset, uint tryLength, int handlerOffset) : base(tryOffset, tryLength, handlerOffset) { }
            }
            public class Finally : ExceptionHandlingClause
            {
                public Finally(int tryOffset, uint tryLength, int handlerOffset) :   base(tryOffset, tryLength, handlerOffset) { }
            }
            ExceptionHandler _parent;
            internal ExceptionHandler Parent { get { return _parent; } set { _parent = value; } }
            int _handlerOffset;
            internal int HandlerOffset { get { return _handlerOffset; } }

            int _tryOffset;
            internal int TryOffset { get { return _tryOffset; } }
            uint _tryLength;
            internal uint TryLength { get { return _tryLength; } }
            internal ExceptionHandlingClause(int tryOffset, uint tryLength, int handlerOffset)
            {
                _tryOffset = tryOffset;
                _tryLength = tryLength;
                _handlerOffset = handlerOffset;
            }
        }
        public abstract byte[] GetMethodSignature(uint methodToken);
        public virtual void Add(int offset, int destination, int a, int b) { }
        public virtual void AddOvf(int offset, int destination, int a, int b) { }
        public virtual void AddOvfUn(int offset, int destination, int a, int b) { }
        public virtual void Sub(int offset, int destination, int a, int b) { }
        public virtual void SubOvf(int offset, int destination, int a, int b) { }
        public virtual void SubOvfUn(int offset, int destination, int a, int b) { }
        public virtual void Mul(int offset, int destination, int a, int b) { }
        public virtual void MulOvf(int offset, int destination, int a, int b) { }
        public virtual void MulOvfUn(int offset, int destination, int a, int b) { }
        public virtual void Div(int offset, int destination, int a, int b) { }
        public virtual void DivUn(int offset, int destination, int a, int b) { }
        public virtual void Rem(int offset, int destination, int a, int b) { }
        public virtual void RemUn(int offset, int destination, int a, int b) { }
        public virtual void And(int offset, int destination, int a, int b) { }
        public virtual void Or(int offset, int destination, int a, int b) { }
        public virtual void Xor(int offset, int destination, int a, int b) { }
        public virtual void Shl(int offset, int destination, int a, int b) { }
        public virtual void Shr(int offset, int destination, int a, int b) { }
        public virtual void ShrUn(int offset, int destination, int a, int b) { }
        public virtual void Neg(int offset, int destination, int source) { }
        public virtual void Not(int offset, int destination, int source) { }
        public virtual void ConvU(int offset, int destination, int source) { }
        public virtual void ConvU1(int offset, int destination, int source) { }
        public virtual void ConvU2(int offset, int destination, int source) { }
        public virtual void ConvU4(int offset, int destination, int source) { }
        public virtual void ConvU8(int offset, int destination, int source) { }
        public virtual void ConvR4(int offset, int destination, int source) { }
        public virtual void ConvR8(int offset, int destination, int source) { }
        public virtual void ConvI(int offset, int destination, int source) { }
        public virtual void ConvI1(int offset, int destination, int source) { }
        public virtual void ConvI2(int offset, int destination, int source) { }
        public virtual void ConvI4(int offset, int destination, int source) { }
        public virtual void ConvI8(int offset, int destination, int source) { }
        public virtual void ConvOvfI(int offset, int destination, int source) { }
        public virtual void ConvOvfI1(int offset, int destination, int source) { }
        public virtual void ConvOvfI2(int offset, int destination, int source) { }
        public virtual void ConvOvfI4(int offset, int destination, int source) { }
        public virtual void ConvOvfI8(int offset, int destination, int source) { }
        public virtual void ConvOvfI1Un(int offset, int destination, int source) { }
        public virtual void ConvOvfI2Un(int offset, int destination, int source) { }
        public virtual void ConvOvfI4Un(int offset, int destination, int source) { }
        public virtual void ConvOvfI8Un(int offset, int destination, int source) { }
        public virtual void ConvOvfIUn(int offset, int destination, int source) { }
        public virtual void ConvOvfU(int offset, int destination, int source) { }
        public virtual void ConvOvfU1(int offset, int destination, int source) { }
        public virtual void ConvOvfU2(int offset, int destination, int source) { }
        public virtual void ConvOvfU4(int offset, int destination, int source) { }
        public virtual void ConvOvfU8(int offset, int destination, int source) { }
        public virtual void ConvOvfU1Un(int offset, int destination, int source) { }
        public virtual void ConvOvfU2Un(int offset, int destination, int source) { }
        public virtual void ConvOvfU4Un(int offset, int destination, int source) { }
        public virtual void ConvOvfU8Un(int offset, int destination, int source) { }
        public virtual void ConvOvfUUn(int offset, int destination, int source) { }
        public virtual void ConvRUn(int offset, int destination, int source) { }
        public virtual void LdLen(int offset, int destination, int array) { }
        public virtual void LdSFld(int offset, bool volatilePrefix, uint fieldToken, int destination) { }
        public virtual void LdFld(int offset, bool noNullCheck, bool volatilePrefix, int alignment, uint fieldToken, int destination, int obj) { }
        public virtual void LdFldA(int offset, uint fieldToken, int destination, int obj) { }
        public virtual void StSFld(int offset, bool volatilePrefix, uint fieldToken, int value) { }
        public virtual void StFld(int offset, bool noNullCheck, bool volatilePrefix, int alignment, uint fieldToken, int obj, int value) { }
        public virtual void LdSFldA(int offset, uint fieldToken, int destination) { }
        public virtual void LdElem(int offset, bool noNullCheck, bool noBoundCheck, uint typeToken, int destination, int array, int index) { }
        public virtual void LdElemA(int offset, bool noNullCheck, bool noTypeCheck, bool noBoundCheck, bool readOnly, uint typeToken, int destination, int array, int index) { }
        public virtual void LdElemI(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemI1(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemI2(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemI4(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemI8(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemU1(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemU2(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemU4(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemR4(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemR8(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void LdElemRef(int offset, bool noNullCheck, bool noBoundCheck, int destination, int array, int index) { }
        public virtual void StElem(int offset, bool noNullCheck, bool noBoundCheck, uint typeToken, int array, int index, int value) { }
        public virtual void StElemI(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemI1(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemI2(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemI4(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemI8(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemR4(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemR8(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void StElemRef(int offset, bool noNullCheck, bool noBoundCheck, int array, int index, int value) { }
        public virtual void LdIndU1(int offset, bool volatilePrefix, int destination, int address) { }
        public virtual void LdIndU2(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndU4(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndI1(int offset, bool volatilePrefix, int destination, int address) { }
        public virtual void LdIndI2(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndI4(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndI8(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndR4(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndR8(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndI(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void LdIndRef(int offset, bool volatilePrefix, int alignment, int destination, int address) { }
        public virtual void StObj(int offset, bool volatilePrefix, int alignment, uint typeToken, int address, int value) { }
        public virtual void LdObj(int offset, bool volatilePrefix, int alignment, uint typeToken, int destination, int address) { }
        public virtual void StIndI1(int offset, bool volatilePrefix, int address, int value) { }
        public virtual void StIndI2(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void StIndI4(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void StIndI8(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void StIndR4(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void StIndR8(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void StIndRef(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void StIndI(int offset, bool volatilePrefix, int alignment, int address, int value) { }
        public virtual void Call(int offset, bool tail, uint methodToken, int destination, int[] parameters) { }
        public virtual void Call(int offset, bool tail, uint methodToken, int[] parameters) { }
        public virtual void CallI(int offset, bool tail, uint signatureToken, int destination, int[] parameters) { }
        public virtual void CallI(int offset, bool tail, uint signatureToken, int[] parameters) { }
        public virtual void CallVirt(int offset, bool noNullCheck, bool tail, uint methodToken, int destination, int[] parameters) { }
        public virtual void CallVirt(int offset, bool noNullCheck, bool tail, uint methodToken, int[] parameters) { }
        public virtual void NewObj(int offset, uint ctorToken, int destination, int[] parameters) { }
        public virtual void NewArr(int offset, uint typeToken, int destination, int size) { }
        public virtual void SizeOf(int offset, uint typeToken, int destination) { }
        public virtual void ArgList(int offset, int destination) { }
        public virtual void Box(int offset, uint typeToken, int destination, int source) { }
        public virtual void Unbox(int offset, bool noTypeCheck, uint typeToken, int destination, int source) { }
        public virtual void UnboxAny(int offset, uint typeToken, int destination, int source) { }
        public virtual void Ceq(int offset, int destination, int a, int b) { }
        public virtual void Cgt(int offset, int destination, int a, int b) { }
        public virtual void CgtUn(int offset, int destination, int a, int b) { }
        public virtual void Clt(int offset, int destination, int a, int b) { }
        public virtual void CltUn(int offset, int destination, int a, int b) { }
        public virtual void StLoc(int offset, int destination, int source) { }
        public virtual void LdLocA(int offset, int destination, int index) { }
        public virtual void LdcI4(int offset, int destination, int value) { }
        public virtual void LdcI8(int offset, int destination, long value) { }
        public virtual void LdcR4(int offset, int destination, float value) { }
        public virtual void LdcR8(int offset, int destination, double value) { }
        public virtual void LdArg(int offset, int destination, int index) { }
        public virtual void LdArgA(int offset, int destination, int index) { }
        public virtual void StArg(int offset, int index, int value) { }
        public virtual void LdNull(int offset, int destination) { }
        public virtual void Switch(int offset, int[] addresses, int value) { }
        public virtual void Br(int offset, int address) { }
        public virtual void BrEq(int offset, int address, int a, int b) { }
        public virtual void BrGe(int offset, int address, int a, int b) { }
        public virtual void BrGt(int offset, int address, int a, int b) { }
        public virtual void BrLe(int offset, int address, int a, int b) { }
        public virtual void BrGeUn(int offset, int address, int a, int b) { }
        public virtual void BrGtUn(int offset, int address, int a, int b) { }
        public virtual void BrLeUn(int offset, int address, int a, int b) { }
        public virtual void BrLt(int offset, int address, int a, int b) { }
        public virtual void BrLtUn(int offset, int address, int a, int b) { }
        public virtual void BrNeqUn(int offset, int address, int a, int b) { }
        public virtual void BrTrue(int offset, int address, int condition) { }
        public virtual void BrFalse(int offset, int address, int condition) { }
        public virtual void Ret(int offset) { }
        public virtual void Ret(int offset, int value) { }
        public virtual void CpObj(int offset, int destination, int source) { }
        public virtual void InitObj(int offset, uint typeToken,  int destination) { }
        public virtual void InitBlk(int offset, bool volatilePrefix, int alignment, int destination, int value, int size) { }
        public virtual void CpBlk(int offset, bool volatilePrefix, int alignment, int destination, int source, int size) { }
        public virtual void LdStr(int offset, uint stringToken, int destination) { }
        public virtual void LdToken(int offset, uint token, int destination) { }
        public virtual void LdFnt(int offset, uint methodToken, int destination) { }
        public virtual void LdVirtFtn(int offset, bool noNullCheck, uint methodToken, int destination, int obj) { }
        public virtual void CkFinite(int offset, int destination, int source) { }
        public virtual void MkRefAny(int offset, uint token, int destination, int source) { }
        public virtual void RefAnyVal(int offset, uint token, int destination, int source) { }
        public virtual void RefAnyType(int offset, int destination, int source) { }
        public virtual void Jmp(int offset, uint methodToken) { }
        public virtual void IsInst(int offset, uint typeToken, int destination, int source) { }
        public virtual void LocAlloc(int offset, int destination, int size) { }
        public virtual void CastClass(int offset, bool noTypeCheck, uint typeToken, int destination, int value) { }
        public virtual void StException(int offset, int destination) { }
        public virtual void EndFilter(int offset, int value) { }
        public virtual void EndFinally(int offset) { }
        public virtual void Phi(int offset, int destination, Dictionary<int, int> locals) { }
        public virtual void Nop(int offset) { }
        public virtual void Throw(int offset, int exception) { }
        public virtual void Leave(int offset, int address) { }
        public virtual void Break(int offset) { }

        class SSAConverter : Runic.Algorithms.ToSSA<Instruction>
        {
            ToSSA _toSSA;
            public SSAConverter(ToSSA parent) { _toSSA = parent; }
            public override void Assignment(int offset, Instruction tag, int destination, int[] parameters) { tag.EmitAssignment(_toSSA, offset, destination, parameters); }
            public override void Statement(int offset, Instruction tag, int[] parameters) { tag.EmitStatement(_toSSA, offset, parameters); }
            public override void Branch(int offset, Instruction tag, int[] parameters, bool condition, int address) { tag.EmitBranch(_toSSA, offset, parameters, condition, address); }
            public override void Switch(int offset, Instruction tag, int[] parameters, int[] targets) { tag.EmitSwitch(_toSSA, offset, parameters, targets); }
            public override void Phi(int offset, int destination, Dictionary<int, int> locals) { _toSSA.Phi(offset, destination, locals); }
        }
#if NET6_0_OR_GREATER
        CIL.Destackifier.ExceptionHandlingClause[]? ToDestackifierEhc(ExceptionHandlingClause[]? clauses)
#else
        CIL.Destackifier.ExceptionHandlingClause[] ToDestackifierEhc(ExceptionHandlingClause[] clauses)
#endif
        {
            if (clauses == null) { return null; }
            List<CIL.Destackifier.ExceptionHandlingClause> destackifierEhc = new List<CIL.Destackifier.ExceptionHandlingClause>();
            for (int n = 0; n < clauses.Length; n++)
            {
                switch (clauses[n])
                {
                    case ExceptionHandlingClause.Filter filter:
                        destackifierEhc.Add(new CIL.Destackifier.ExceptionHandlingClause.Filter(filter.FilterOffset, filter.HandlerOffset));
                        break;
                    case ExceptionHandlingClause.Clause normal:
                        destackifierEhc.Add(new CIL.Destackifier.ExceptionHandlingClause.Clause(normal.HandlerOffset));
                        break;
                }
            }
            return destackifierEhc.ToArray();
        }
        public void Process(uint methodToken, byte[] bytecode)
        {
            Process(null, GetMethodSignature(methodToken), bytecode);
        }
#if NET6_0_OR_GREATER
        public void Process(ExceptionHandlingClause[]? exceptionHandlingClauses, uint methodToken, byte[] bytecode)
#else
        public void Process(ExceptionHandlingClause[] exceptionHandlingClauses, uint methodToken, byte[] bytecode)
#endif
        {
            Process(exceptionHandlingClauses, GetMethodSignature(methodToken), bytecode);
        }
        public void Process(byte[] methodSignature, byte[] bytecode)
        {
            Process(null, methodSignature, bytecode);
        }
#if NET6_0_OR_GREATER
        public void Process(ExceptionHandlingClause[]? exceptionHandlingClauses, byte[] methodSignature, byte[] bytecode)
#else
        public void Process(ExceptionHandlingClause[] exceptionHandlingClauses, byte[] methodSignature, byte[] bytecode)
#endif
        {
            ExceptionHandlersMap exceptionHandlersMap = new ExceptionHandlersMap(bytecode.Length);
            SSAConverter converter = new SSAConverter(this);
            Destackifier destackifier = new Destackifier(this, converter, exceptionHandlersMap);
            if (exceptionHandlingClauses != null)
            {
                for (int n = 0; n < exceptionHandlingClauses.Length; n++)
                {
                    exceptionHandlersMap.AddClause(exceptionHandlingClauses[n]);
                }
            }
            destackifier.Destackify(ToDestackifierEhc(exceptionHandlingClauses), methodSignature, bytecode);
            converter.Process();
        }
    }
}
