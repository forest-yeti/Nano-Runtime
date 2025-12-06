using Nano_Runtime.Fallback;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.OpCodeBackend;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Signal;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime
{
    internal class NanoRuntime
    {
        public static string ENTRY_POINT = "Main";

        Dictionary<string, IOpCodeRunner> _opCodeRunners = new();

        public NanoRuntime()
        {
            _opCodeRunners[OpCodeTable.Def] = new DefOpCodeRunner();
            _opCodeRunners[OpCodeTable.Loadi] = new LoadiOpCodeRunner();
            _opCodeRunners[OpCodeTable.Puti] = new PutiOpCodeRunner();
            _opCodeRunners[OpCodeTable.Popi] = new PopiOpCodeRunner();
            _opCodeRunners[OpCodeTable.Add] = new AddOpCodeRunner();
            _opCodeRunners[OpCodeTable.Ret] = new RetOpCodeRunner();
            _opCodeRunners[OpCodeTable.Call] = new CallOpCodeRunner();
        }

        public void Run(ExectionPlan exectionPlan)
        {
            GlobalRegister.InstructionPointer = exectionPlan.GetEntryPointVirtual();
            GlobalRegister.RunnedFunction = ENTRY_POINT;
            CallStack.AddScope(ENTRY_POINT, new());

            while (true)
            {
                Function runnedFunction = exectionPlan.GetFunction(GlobalRegister.RunnedFunction);

                OpCode opCode = runnedFunction.GetInstruction(GlobalRegister.InstructionPointer);
                if (!_opCodeRunners.ContainsKey(opCode.Type))
                {
                    throw new FailedExectionPlan(
                        (int)FallbackCode.UnsupportedOpCode,
                        $"Unsupported op code with name - {opCode.Type}"
                    );
                }

                try
                {
                    _opCodeRunners[opCode.Type].Run(opCode);
                    GlobalRegister.InstructionPointer++;
                }
                catch (ExitProgramSignal)
                {
                    break;
                }
            }
        }
    }
}
