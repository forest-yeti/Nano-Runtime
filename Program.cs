using Nano_Runtime.Runtime;
using Nano_Runtime.Runtime.Structure;

class Program
{
    public static void Main()
    {
        ExectionPlan exectionPlan = new();

        exectionPlan
            .AddFunction(
                (new Function("Sum"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "z"))
                    .AddInstruction(new OpCode(OpCodeTable.Popi, "z"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "y"))
                    .AddInstruction(new OpCode(OpCodeTable.Popi, "y"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "x"))
                    .AddInstruction(new OpCode(OpCodeTable.Popi, "x"))
                    .AddInstruction(new OpCode(OpCodeTable.Loadi, "_Acc", "0"))
                    .AddInstruction(new OpCode(OpCodeTable.Add, "x"))
                    .AddInstruction(new OpCode(OpCodeTable.Add, "y"))
                    .AddInstruction(new OpCode(OpCodeTable.Add, "z"))
                    .AddInstruction(new OpCode(OpCodeTable.Puti, "_Acc"))
                    .AddInstruction(new OpCode(OpCodeTable.Loadi, "_Acc", "0"))
                    .AddInstruction(new OpCode(OpCodeTable.Ret))
            )
            .AddFunction(
                (new Function("Main"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "x"))
                    .AddInstruction(new OpCode(OpCodeTable.Loadi, "x", "200"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "y"))
                    .AddInstruction(new OpCode(OpCodeTable.Loadi, "y", "500"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "z"))
                    .AddInstruction(new OpCode(OpCodeTable.Loadi, "z", "500"))
                    .AddInstruction(new OpCode(OpCodeTable.Puti, "x"))
                    .AddInstruction(new OpCode(OpCodeTable.Puti, "y"))
                    .AddInstruction(new OpCode(OpCodeTable.Puti, "z"))
                    .AddInstruction(new OpCode(OpCodeTable.Call, "Sum"))
                    .AddInstruction(new OpCode(OpCodeTable.Def, "INT", "tmp"))
                    .AddInstruction(new OpCode(OpCodeTable.Popi, "tmp"))
                    .AddInstruction(new OpCode(OpCodeTable.Puti, "tmp"))
                    .AddInstruction(new OpCode(OpCodeTable.Call, "__I_Output_WriteLine"))
                    .AddInstruction(new OpCode(OpCodeTable.Ret))
            );

        (new NanoRuntime()).Run(exectionPlan);
    }
}
