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

namespace Runic.CIL
{
    public abstract partial class ToSSA
    {
        abstract internal class Instruction
        {
            internal class Add : Instruction
            {
                public Add() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Add(offset, destination, parameters[0], parameters[1]); }
            }
            internal class AddOvf : Instruction
            {
                public AddOvf() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.AddOvf(offset, destination, parameters[0], parameters[1]); }
            }
            internal class AddOvfUn : Instruction
            {
                public AddOvfUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.AddOvfUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Sub : Instruction
            {
                public Sub() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Sub(offset, destination, parameters[0], parameters[1]); }
            }
            internal class SubOvf : Instruction
            {
                public SubOvf() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.SubOvf(offset, destination, parameters[0], parameters[1]); }
            }
            internal class SubOvfUn : Instruction
            {
                public SubOvfUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.SubOvfUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Mul : Instruction
            {
                public Mul() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Mul(offset, destination, parameters[0], parameters[1]); }
            }
            internal class MulOvf : Instruction
            {
                public MulOvf() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.MulOvf(offset, destination, parameters[0], parameters[1]); }
            }
            internal class MulOvfUn : Instruction
            {
                public MulOvfUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.MulOvfUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Div : Instruction
            {
                public Div() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Div(offset, destination, parameters[0], parameters[1]); }
            }
            internal class DivUn : Instruction
            {
                public DivUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Div(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Rem : Instruction
            {
                public Rem() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Rem(offset, destination, parameters[0], parameters[1]); }
            }
            internal class RemUn : Instruction
            {
                public RemUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.RemUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class And : Instruction
            {
                public And() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.And(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Or : Instruction
            {
                public Or() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Or(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Xor : Instruction
            {
                public Xor() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Xor(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Shl : Instruction
            {
                public Shl() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Shl(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Shr : Instruction
            {
                public Shr() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Shr(offset, destination, parameters[0], parameters[1]); }
            }
            internal class ShrUn : Instruction
            {
                public ShrUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ShrUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class ArgList : Instruction
            {
                public ArgList() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ArgList(offset, destination); }
            }
            internal class Box : Instruction
            {
                uint _type;
                public Box(uint type) { _type = type; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Box(offset, _type, destination, parameters[0]); }
            }
            internal class Ceq : Instruction
            {
                public Ceq() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Ceq(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Cgt : Instruction
            {
                public Cgt() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Cgt(offset, destination, parameters[0], parameters[1]); }
            }
            internal class CgtUn : Instruction
            {
                public CgtUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CgtUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class Clt : Instruction
            {
                public Clt() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Clt(offset, destination, parameters[0], parameters[1]); }
            }
            internal class CltUn : Instruction
            {
                public CltUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CltUn(offset, destination, parameters[0], parameters[1]); }
            }
            internal class StLoc : Instruction
            {
                public StLoc() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.StLoc(offset, destination, parameters[0]); }
            }
            internal class LdLocA : Instruction
            {
                public LdLocA() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdLocA(offset, destination, parameters[0]); }
            }
            internal class LdcI4 : Instruction
            {
                int _value;
                public LdcI4(int value) { _value = value; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdcI4(offset, destination, _value); }
            }
            internal class LdcI8 : Instruction
            {
                long _value;
                public LdcI8(long value) { _value = value; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdcI8(offset, destination, _value); }
            }
            internal class LdcR4 : Instruction
            {
                float _value;
                public LdcR4(float value) { _value = value; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdcR4(offset, destination, _value); }
            }
            internal class LdcR8 : Instruction
            {
                double _value;
                public LdcR8(double value) { _value = value; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdcR8(offset, destination, _value); }
            }
            internal class LdArg : Instruction
            {
                int _index;
                public LdArg(int index) { _index = index; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdArg(offset, destination, _index); }
            }
            internal class LdArgA : Instruction
            {
                int _index;
                public LdArgA(int index) { _index = index; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdArgA(offset, destination, _index); }
            }
            internal class StArg : Instruction
            {
                int _index;
                public StArg(int index) { _index = index; }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StArg(offset, _index, parameters[0]); }
            }
            internal class Neg : Instruction
            {
                public Neg() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Neg(offset, destination, parameters[0]); }
            }
            internal class ConvU : Instruction
            {
                public ConvU() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvU(offset, destination, parameters[0]); }
            }
            internal class ConvU1 : Instruction
            {
                public ConvU1() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvU1(offset, destination, parameters[0]); }
            }
            internal class ConvU2 : Instruction
            {
                public ConvU2() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvU2(offset, destination, parameters[0]); }
            }
            internal class ConvU4 : Instruction
            {
                public ConvU4() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvU4(offset, destination, parameters[0]); }
            }
            internal class ConvU8 : Instruction
            {
                public ConvU8() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvU8(offset, destination, parameters[0]); }
            }
            internal class ConvI : Instruction
            {
                public ConvI() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvI(offset, destination, parameters[0]); }
            }
            internal class ConvI1 : Instruction
            {
                public ConvI1() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvI1(offset, destination, parameters[0]); }
            }
            internal class ConvI2 : Instruction
            {
                public ConvI2() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvI2(offset, destination, parameters[0]); }
            }
            internal class ConvI4 : Instruction
            {
                public ConvI4() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvI4(offset, destination, parameters[0]); }
            }
            internal class ConvI8 : Instruction
            {
                public ConvI8() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvI8(offset, destination, parameters[0]); }
            }
            internal class ConvR4 : Instruction
            {
                public ConvR4() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvR4(offset, destination, parameters[0]); }
            }
            internal class ConvR8 : Instruction
            {
                public ConvR8() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvR8(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI : Instruction
            {
                public ConvOvfI() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI1 : Instruction
            {
                public ConvOvfI1() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI1(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI2 : Instruction
            {
                public ConvOvfI2() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI2(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI4 : Instruction
            {
                public ConvOvfI4() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI4(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI8 : Instruction
            {
                public ConvOvfI8() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI8(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI1Un : Instruction
            {
                public ConvOvfI1Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI1Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI2Un : Instruction
            {
                public ConvOvfI2Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI2Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI4Un : Instruction
            {
                public ConvOvfI4Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI4Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfI8Un : Instruction
            {
                public ConvOvfI8Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfI8Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfIUn : Instruction
            {
                public ConvOvfIUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfIUn(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU : Instruction
            {
                public ConvOvfU() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU1 : Instruction
            {
                public ConvOvfU1() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU1(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU2 : Instruction
            {
                public ConvOvfU2() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU2(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU4 : Instruction
            {
                public ConvOvfU4() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU4(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU8 : Instruction
            {
                public ConvOvfU8() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU8(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU1Un : Instruction
            {
                public ConvOvfU1Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU1Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU2Un : Instruction
            {
                public ConvOvfU2Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU2Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU4Un : Instruction
            {
                public ConvOvfU4Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU4Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfU8Un : Instruction
            {
                public ConvOvfU8Un() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfU8Un(offset, destination, parameters[0]); }
            }
            internal class ConvOvfUUn : Instruction
            {
                public ConvOvfUUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvOvfUUn(offset, destination, parameters[0]); }
            }
            internal class ConvRUn : Instruction
            {
                public ConvRUn() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.ConvRUn(offset, destination, parameters[0]); }
            }
            internal class LdLen : Instruction
            {
                public LdLen() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdLen(offset, destination, parameters[0]); }
            }
            internal class LdStr : Instruction
            {
                uint _stringToken;
                public LdStr(uint stringToken) { _stringToken = stringToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdStr(offset, _stringToken, destination); }
            }
            internal class LdToken : Instruction
            {
                uint _token;
                public LdToken(uint token) { _token = token; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdToken(offset, _token, destination); }
            }
            internal class LdFnt : Instruction
            {
                uint _token;
                public LdFnt(uint methodToken) { _token = methodToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdFnt(offset, _token, destination); }
            }
            internal class LdVirtFtn : Instruction
            {
                bool _noNullCheck;
                uint _methodToken;
                public LdVirtFtn(bool noNullCheck, uint methodToken) { _noNullCheck = noNullCheck; _methodToken = methodToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdVirtFtn(offset, _noNullCheck, _methodToken, destination, parameters[0]); }
            }
            internal class CkFinite : Instruction
            {
                public CkFinite() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CkFinite(offset, destination, parameters[0]); }
            }
            internal class MkRefAny : Instruction
            {
                uint _token;
                public MkRefAny(uint token) { _token = token; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.MkRefAny(offset, _token, destination, parameters[0]); }
            }
            internal class RefAnyVal : Instruction
            {
                uint _token;
                public RefAnyVal(uint token) { _token = token; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.RefAnyVal(offset, _token, destination, parameters[0]); }
            }
            internal class RefAnyType : Instruction
            {
                public RefAnyType() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.RefAnyType(offset, destination, parameters[0]); }
            }
            internal class Jmp : Instruction
            {
                uint _methodToken;
                public Jmp(uint methodToken) { _methodToken = methodToken; }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Jmp(offset, _methodToken); }
            }
            internal class IsInst : Instruction
            {
                uint _typeToken;
                public IsInst(uint typeToken) { _typeToken = typeToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.IsInst(offset, _typeToken, destination, parameters[0]); }
            }
            internal class LdSFld : Instruction
            {
                bool _volatilePrefix;
                uint _fieldToken;
                public LdSFld(bool volatilePrefix, uint fieldToken) { _volatilePrefix = volatilePrefix; _fieldToken = fieldToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdSFld(offset, _volatilePrefix, _fieldToken, destination); }
            }
            internal class LdFld : Instruction
            {
                bool _noNullCheck;
                bool _volatilePrefix;
                int _alignment;
                uint _fieldToken;
                public LdFld(bool noNullCheck, bool volatilePrefix, int alignment, uint fieldToken) { _noNullCheck = noNullCheck; _volatilePrefix = volatilePrefix; _alignment = alignment; _fieldToken = fieldToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdFld(offset, _noNullCheck, _volatilePrefix, _alignment, _fieldToken, destination, parameters[0]); }
            }
            internal class LdFldA : Instruction
            {
                uint _fieldToken;
                public LdFldA(uint fieldToken) { _fieldToken = fieldToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdFldA(offset, _fieldToken, destination, parameters[0]); }
            }
            internal class StSFld : Instruction
            {
                bool _volatilePrefix;
                uint _fieldToken;
                public StSFld(bool volatilePrefix, uint fieldToken) { _volatilePrefix = volatilePrefix; _fieldToken = fieldToken; }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StSFld(offset, _volatilePrefix, _fieldToken, parameters[0]); }
            }
            internal class StFld : Instruction
            {
                bool _noNullCheck;
                bool _volatilePrefix;
                int _alignment;
                uint _fieldToken;
                public StFld(bool noNullCheck, bool volatilePrefix, int alignment, uint fieldToken) { _noNullCheck = noNullCheck; _volatilePrefix = volatilePrefix; _alignment = alignment; _fieldToken = fieldToken; }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StFld(offset, _noNullCheck, _volatilePrefix, _alignment, _fieldToken, parameters[0], parameters[1]); }
            }
            internal class LdSFldA : Instruction
            {
                uint _fieldToken;
                public LdSFldA(uint fieldToken) { _fieldToken = fieldToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdSFldA(offset, _fieldToken, destination); }
            }
            internal class LdElem : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                uint _typeToken;
                public LdElem(bool noNullCheck, bool noBoundCheck, uint typeToken)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                    _typeToken = typeToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElem(offset, _noNullCheck, _noBoundCheck, _typeToken, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemA : Instruction
            {
                bool _noNullCheck;
                bool _noTypeCheck;
                bool _noBoundCheck;
                bool _readOnly;
                uint _typeToken;
                public LdElemA(bool noNullCheck, bool noTypeCheck, bool noBoundCheck, bool readOnly, uint typeToken)
                {
                    _noNullCheck = noNullCheck;
                    _noTypeCheck = noTypeCheck;
                    _noBoundCheck = noBoundCheck;
                    _readOnly = readOnly;
                    _typeToken = typeToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemA(offset, _noNullCheck, _noTypeCheck, _noBoundCheck, _readOnly, _typeToken, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemI : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemI(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemI(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemI1 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemI1(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemI1(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemI2 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemI2(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemI2(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemI4 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemI4(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemI4(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemI8 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemI8(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemI8(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemR4 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemR4(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemR4(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemR8 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemR8(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemR8(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemU1 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemU1(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemU1(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemU2 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemU2(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemU2(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemU4 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemU4(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemU4(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class LdElemRef : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public LdElemRef(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdElemRef(offset, _noNullCheck, _noBoundCheck, destination, parameters[0], parameters[1]); }
            }
            internal class StElem : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                uint _typeToken;
                public StElem(bool noNullCheck, bool noBoundCheck, uint typeToken)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                    _typeToken = typeToken;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElem(offset, _noNullCheck, _noBoundCheck, _typeToken, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemI : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemI(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemI(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemI1 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemI1(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemI1(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemI2 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemI2(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemI2(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemI4 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemI4(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemI4(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemI8 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemI8(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemI8(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemR4 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemR4(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemR4(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemR8 : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemR8(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemR8(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class StElemRef : Instruction
            {
                bool _noNullCheck;
                bool _noBoundCheck;
                public StElemRef(bool noNullCheck, bool noBoundCheck)
                {
                    _noNullCheck = noNullCheck;
                    _noBoundCheck = noBoundCheck;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StElemRef(offset, _noNullCheck, _noBoundCheck, parameters[0], parameters[1], parameters[2]); }
            }
            internal class LdIndU1 : Instruction
            {
                bool _volatilePrefix;
                public LdIndU1(bool volatilePrefix)
                {
                    _volatilePrefix = volatilePrefix;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndU1(offset, _volatilePrefix, destination, parameters[0]); }
            }
            internal class LdIndU2 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndU2(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndU2(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndU4 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndU4(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndU4(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndI1 : Instruction
            {
                bool _volatilePrefix;
                public LdIndI1(bool volatilePrefix)
                {
                    _volatilePrefix = volatilePrefix;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndI1(offset, _volatilePrefix, destination, parameters[0]); }
            }
            internal class LdIndI2 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndI2(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndI2(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndI4 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndI4(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndI4(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndI8 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndI8(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndI8(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndR4 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndR4(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndR4(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndR8 : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndR8(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndR8(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndI : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndI(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndI(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class LdIndRef : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public LdIndRef(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdIndRef(offset, _volatilePrefix, _alignment, destination, parameters[0]); }
            }
            internal class StIndI1 : Instruction
            {
                bool _volatilePrefix;
                public StIndI1(bool volatilePrefix)
                {
                    _volatilePrefix = volatilePrefix;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndI1(offset, _volatilePrefix, parameters[0], parameters[1]); }
            }
            internal class StIndI2 : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndI2(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndI2(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StIndI4 : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndI4(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndI4(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StIndI8 : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndI8(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndI8(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StIndR4 : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndR4(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndR4(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StIndR8 : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndR8(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndR8(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StIndRef : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndRef(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndRef(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StIndI : Instruction
            {
                int _alignment;
                bool _volatilePrefix;
                public StIndI(bool volatilePrefix, int alignment)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StIndI(offset, _volatilePrefix, _alignment, parameters[0], parameters[1]); }
            }
            internal class StObj : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                uint _typeToken;
                public StObj(bool volatilePrefix, int alignment, uint typeToken)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                    _typeToken = typeToken;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.StObj(offset, _volatilePrefix, _alignment, _typeToken, parameters[0], parameters[1]); }
            }
            internal class LdObj : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                uint _typeToken;
                public LdObj(bool volatilePrefix, int alignment, uint typeToken)
                {
                    _volatilePrefix = volatilePrefix;
                    _alignment = alignment;
                    _typeToken = typeToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdObj(offset, _volatilePrefix, _alignment, _typeToken, destination, parameters[0]); }
            }
            internal class Unbox : Instruction
            {
                bool _noTypeCheck;
                uint _typeToken;
                public Unbox(bool noTypeCheck, uint typeToken)
                {
                    _noTypeCheck = noTypeCheck;
                    _typeToken = typeToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Unbox(offset, _noTypeCheck, _typeToken, destination, parameters[0]); }
            }
            internal class UnboxAny : Instruction
            {
                uint _typeToken;
                public UnboxAny(uint typeToken)
                {
                    _typeToken = typeToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.UnboxAny(offset, _typeToken, destination, parameters[0]); }
            }
            internal class Call : Instruction
            {
                bool _tail;
                uint _methodToken;
                public Call(bool tail, uint methodToken)
                {
                    _tail = tail;
                    _methodToken = methodToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Call(offset, _tail, _methodToken, destination, parameters); }
            }
            internal class CallI : Instruction
            {
                bool _tail;
                uint _signatureToken;
                public CallI(bool tail, uint signatureToken)
                {
                    _tail = tail;
                    _signatureToken = signatureToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CallI(offset, _tail, _signatureToken, destination, parameters); }
            }
            internal class CallProc : Instruction
            {
                bool _tail;
                uint _methodToken;
                public CallProc(bool tail, uint methodToken)
                {
                    _tail = tail;
                    _methodToken = methodToken;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Call(offset, _tail, _methodToken, parameters); }
            }
            internal class CallIProc : Instruction
            {
                bool _tail;
                uint _signatureToken;
                public CallIProc(bool tail, uint signatureToken)
                {
                    _tail = tail;
                    _signatureToken = signatureToken;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.CallI(offset, _tail, _signatureToken, parameters); }
            }
            internal class CallVirt : Instruction
            {
                bool _noNullCheck;
                bool _tail;
                uint _methodToken;
                public CallVirt(bool noNullCheck, bool tail, uint methodToken)
                {
                    _noNullCheck = noNullCheck;
                    _tail = tail;
                    _methodToken = methodToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CallVirt(offset, _noNullCheck, _tail, _methodToken, destination, parameters); }
            }
            internal class CallVirtProc : Instruction
            {
                bool _noNullCheck;
                bool _tail;
                uint _methodToken;
                public CallVirtProc(bool noNullCheck, bool tail, uint methodToken)
                {
                    _noNullCheck = noNullCheck;
                    _tail = tail;
                    _methodToken = methodToken;
                }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.CallVirt(offset, _noNullCheck, _tail, _methodToken, parameters); }
            }
            internal class Not : Instruction
            {
                public Not() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.Not(offset, destination, parameters[0]); }
            }
            internal class NewObj : Instruction
            {
                uint _ctorToken;
                public NewObj(uint ctorToken) { _ctorToken = ctorToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.NewObj(offset, _ctorToken, destination, parameters); }
            }
            internal class NewArr : Instruction
            {
                uint _typeToken;
                public NewArr(uint typeToken) { _typeToken = typeToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.NewArr(offset, _typeToken, destination, parameters[0]); }
            }
            internal class SizeOf : Instruction
            {
                uint _typeToken;
                public SizeOf(uint typeToken) { _typeToken = typeToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.SizeOf(offset, _typeToken, destination); }
            }
            internal class LdNull : Instruction
            {
                public LdNull() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LdNull(offset, destination); }
            }
            internal class Ret : Instruction
            {
                public Ret() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Ret(offset); }
            }

            internal class RetValue : Instruction
            {
                public RetValue() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Ret(offset, parameters[0]); }
            }
            internal class CpObj : Instruction
            {
                public CpObj() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CpObj(offset, destination, parameters[0]); }
            }
            internal class InitObj : Instruction
            {
                uint _typeToken;
                public InitObj(uint typeToken) { _typeToken = typeToken; }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.InitObj(offset, _typeToken, destination); }
            }
            internal class CpBlk : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public CpBlk(bool volatilePrefix, int alignment) { _volatilePrefix = volatilePrefix; _alignment = alignment; }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.CpBlk(offset, _volatilePrefix, _alignment, parameters[0], parameters[1], parameters[2]); }
            }
            internal class InitBlk : Instruction
            {
                bool _volatilePrefix;
                int _alignment;
                public InitBlk(bool volatilePrefix, int alignment) { _volatilePrefix = volatilePrefix; _alignment = alignment; }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.InitBlk(offset, _volatilePrefix, _alignment, parameters[0], parameters[1], parameters[2]); }
            }
            internal class Nop : Instruction
            {
                public Nop() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Nop(offset); }
            }
            internal class Switch : Instruction
            {
                public Switch() { }
                public override void EmitSwitch(ToSSA toSSA, int offset, int[] parameters, int[] addresses) { toSSA.Switch(offset, addresses, parameters[0]); }
            }
            internal class Br : Instruction
            {
                public Br() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.Br(offset, address); }
            }
            internal class BrTrue : Instruction
            {
                public BrTrue() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrTrue(offset, address, parameters[0]); }
            }
            internal class BrFalse : Instruction
            {
                public BrFalse() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrFalse(offset, address, parameters[0]); }
            }
            internal class BrEq : Instruction
            {
                public BrEq() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrEq(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrGe : Instruction
            {
                public BrGe() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrGe(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrGeUn : Instruction
            {
                public BrGeUn() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrGeUn(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrGt : Instruction
            {
                public BrGt() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrGt(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrLe : Instruction
            {
                public BrLe() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrLe(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrGtUn : Instruction
            {
                public BrGtUn() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrGtUn(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrLeUn : Instruction
            {
                public BrLeUn() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrLeUn(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrLt : Instruction
            {
                public BrLt() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrLt(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrLtUn : Instruction
            {
                public BrLtUn() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrLtUn(offset, address, parameters[0], parameters[1]); }
            }
            internal class BrNeqUn : Instruction
            {
                public BrNeqUn() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.BrNeqUn(offset, address, parameters[0], parameters[1]); }
            }
            internal class LocAlloc : Instruction
            {
                public LocAlloc() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.LocAlloc(offset, destination, parameters[0]); }
            }
            internal class StException : Instruction
            {
                public StException() { }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.StException(offset, destination); }
            }
            internal class Break : Instruction
            {
                public Break() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Break(offset); }
            }
            internal class CastClass : Instruction
            {
                bool _noTypeCheck;
                uint _typeToken;
                public CastClass(bool noTypeCheck, uint typeToken)
                {
                    _noTypeCheck = noTypeCheck;
                    _typeToken = typeToken;
                }
                public override void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { toSSA.CastClass(offset, _noTypeCheck, _typeToken, destination, parameters[0]); }
            }
            internal class Throw : Instruction
            {
                public Throw() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.Throw(offset, parameters[0]); }
                public override void EmitSwitch(ToSSA toSSA, int offset, int[] parameters, int[] addresses) { toSSA.Throw(offset, parameters[0]); }
            }
            internal class Leave : Instruction
            {
                int _address;
                public Leave(int address)
                {
                    _address = address;
                }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.Leave(offset, _address); }
            }
            internal class EndFilter : Instruction
            {
                public EndFilter() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.EndFilter(offset, parameters[0]); }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { toSSA.EndFilter(offset, parameters[0]); }

            }
            internal class EndFinally : Instruction
            {
                public EndFinally() { }
                public override void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { toSSA.EndFinally(offset); }

            }
            internal class SilentThrow : Instruction
            {
                public SilentThrow() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { }
                public override void EmitSwitch(ToSSA toSSA, int offset, int[] parameters, int[] addresses) { }
            }
            internal class SilentFinally : Instruction
            {
                public SilentFinally() { }
                public override void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { }
                public override void EmitSwitch(ToSSA toSSA, int offset, int[] parameters, int[] addresses) { }
            }

            public virtual void EmitAssignment(ToSSA toSSA, int offset, int destination, int[] parameters) { }
            public virtual void EmitStatement(ToSSA toSSA, int offset, int[] parameters) { }
            public virtual void EmitBranch(ToSSA toSSA, int offset, int[] parameters, bool condition, int address) { }
            public virtual void EmitSwitch(ToSSA toSSA, int offset, int[] parameters, int[] addresses) { }
        }

    }
}
