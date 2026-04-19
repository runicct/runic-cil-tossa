# How to use this module

To use this module you are expected to imherith from the  Runic.CIL.ToSSA and implement your callbacks. For instance the toy sample here implements a mini pretty printer:

``` csharp
        static void Test(int arg)
        {
            int b = 1;
            int a = 0;
            for (int n = 0; n < 10; n++)
            {
                switch (n % 3)
                {
                    case 0:
                        b = a;
                        break;
                    case 1:
                        a = 1;
                        break;
                    case 2:
                        b = a;
                        break;
                }
            }
        }
        static System.Reflection.MethodInfo GetMethodInfo<T>(T method) where T : Delegate
        {
            return method.Method;
        }
        static void Main(string[] args)
        {
            var m = GetMethodInfo(Test);
            ToSSA toSSA = new ToSSA(m.Module);
            toSSA.Process(toSSA.GetMethodSignature((uint)m.MetadataToken), m.GetMethodBody().GetILAsByteArray());
        }
        class ToSSA : Runic.CIL.ToSSA
        {
            System.Reflection.Module _module;
            public ToSSA(System.Reflection.Module module) { _module = module; }

            public override byte[] GetMethodSignature(uint methodToken)
            {
                if (methodToken == 0) return new byte[0];
                return _module.ResolveSignature((int)methodToken);
            }
            public override void Add(int offset, int destination, int a, int b) { Console.WriteLine($"IL_{offset}: Add loc_{destination} loc_{a} loc_{b}"); }
            public override void Rem(int offset, int destination, int a, int b) { Console.WriteLine($"IL_{offset}: Rem loc_{destination} loc_{a} loc_{b}"); }
            public override void StLoc(int offset, int destination, int source) { Console.WriteLine($"IL_{offset}: StLoc loc_{destination} loc_{source}"); }
            public override void LdArg(int offset, int destination, int index) { Console.WriteLine($"IL_{offset}: LdArg loc_{destination} arg_{index}"); }
            public override void LdcI4(int offset, int destination, int value) { Console.WriteLine($"IL_{offset}: LdCI4 loc_{destination} {value}"); }
            public override void Br(int offset, int address) { Console.WriteLine($"IL_{offset}: Br IL_{address}"); }
            public override void BrTrue(int offset, int address, int condition) { Console.WriteLine($"IL_{offset}: BrTrue IL_{address} loc_{condition}"); }
            public override void BrFalse(int offset, int address, int condition) { Console.WriteLine($"IL_{offset}: BrFalse IL_{address} loc_{condition}"); }
            public override void Clt(int offset, int destination, int a, int b) { Console.WriteLine($"IL_{offset}: Clt {destination} loc_{a} loc_{b}"); }
            public override void Ceq(int offset, int destination, int a, int b) { Console.WriteLine($"IL_{offset}: Ceq {destination} loc_{a} loc_{b}"); }
            public override void Cgt(int offset, int destination, int a, int b) { Console.WriteLine($"IL_{offset}: Cgt {destination} loc_{a} loc_{b}"); }
            public override void Nop(int offset) { Console.WriteLine($"IL_{offset}: Nop"); }
            public override void Switch(int offset, int[] addresses, int value)
            {
                string inst = $"IL_{offset}: Switch {value}";
                for (int n = 0; n < addresses.Length; n++)
                {
                    inst += $" IL_{addresses[n]}";
                }
                Console.WriteLine(inst);
            }
            public override void Phi(int offset, int destination, Dictionary<int, int> locals)
            {
                string inst = $"IL_{offset}: phi {destination}";
                foreach (var kvp in locals)
                {
                    inst += $" IL_{kvp.Key}->loc_{kvp.Value}";
                }
                Console.WriteLine(inst);
            }
            public override void Ret(int offset) { Console.WriteLine($"IL_{offset}: Ret"); }
        }
```

This example should produce in debug mode the following code:

```
IL_0:  Nop
IL_1:  LdCI4 loc_16 1
IL_2:  StLoc loc_17 loc_16
IL_3:  LdCI4 loc_18 0
IL_4:  StLoc loc_19 loc_18
IL_5:  LdCI4 loc_20 0
IL_6:  StLoc loc_21 loc_20
IL_7:  Br IL_55
IL_9:  Nop
IL_11: LdCI4 loc_22 3
IL_12: phi 36 IL_0->loc_21 IL_50->loc_32
IL_12: Rem loc_23 loc_36 loc_22
IL_13: StLoc loc_24 loc_23
IL_17: StLoc loc_25 loc_24
IL_19: Switch 25 IL_38 IL_42 IL_46
IL_36: Br IL_50
IL_38: Nop
IL_39: phi 36 IL_0->loc_19 IL_42->loc_28
IL_39: StLoc loc_26 loc_36
IL_40: Br IL_50
IL_42: LdCI4 loc_27 1
IL_43: StLoc loc_28 loc_27
IL_44: Br IL_50
IL_46: Nop
IL_47: phi 36 IL_0->loc_19 IL_42->loc_28
IL_47: StLoc loc_29 loc_36
IL_48: Br IL_50
IL_50: Nop
IL_52: LdCI4 loc_30 1
IL_53: phi 36 IL_0->loc_21 IL_50->loc_32
IL_53: Add loc_31 loc_36 loc_30
IL_54: StLoc loc_32 loc_31
IL_55: Nop
IL_56: LdCI4 loc_33 10
IL_58: phi 36 IL_0->loc_21 IL_50->loc_32
IL_58: Clt 34 loc_36 loc_33
IL_60: StLoc loc_35 loc_34
IL_64: BrTrue IL_9 loc_35
IL_66: Ret
```

Please not a couple of things:
* During the ToSSA process multiple instructions can be generated for a single CIL instruction
  and therefore will be tied to the same IL offset. Usually any consumer would detect this and
  use a single offset for a given group of instructions.
* The process only do some oportunistic optimizations (mostly in feed-forward cases) and therefore
  the output code may have unused locals, or repeated Phi instructions. This is intentional as it
  lets the consumer decide where to put the cursor between the optimization / cleanup level and time spent doing so.
