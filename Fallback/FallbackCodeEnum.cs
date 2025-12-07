namespace Nano_Runtime.Fallback
{
    enum FallbackCode
    {
        FunctionAlreadyExist,
        EntryPointNotDefined,
        FunctionNotDefined,
        OpCodeNotDefined,
        OpCodeWrongStructure,
        FunctionScopeVariableAlreadyDefined,
        FunctionScopeVariableNotDefined,
        UnsupportedOpCode,
        ReservedWordUsing,
        EmptyGlobalStack,
        LoadFloatToInt
    }
}
