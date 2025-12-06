using Nano_Runtime.Helper;
using System.Collections.Generic;
using System;
using Nano_Runtime.Fallback;
using Nano_Runtime.Runtime.Panic;

namespace Nano_Runtime.Runtime.Structure
{
    internal class Function(string name)
    {
        public string Name
        {
            get => _name;
        }

        public int VirtualName
        {
            get => BakedHelper.BakeString(Name);
        }

        public List<OpCode> Instructions
        {
            get => _instructions;
        }

        private readonly string _name = name;
        private readonly List<OpCode> _instructions = new();

        public Function AddInstruction(OpCode opCode)
        {
            _instructions.Add(opCode);

            return this;
        }

        public OpCode GetInstruction(int pointer)
        {
            int originalPointer = pointer - VirtualName;

            if (originalPointer >= 0 && originalPointer < Instructions.Count)
            {
                return Instructions[originalPointer];
            }

            throw new FailedExectionPlan(
                (int)FallbackCode.OpCodeNotDefined,
                $"Op Code at function {Name} with pointer {originalPointer} not defined"
            );
        }
    }
}
