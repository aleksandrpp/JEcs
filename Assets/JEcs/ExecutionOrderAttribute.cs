using System;

namespace AK.JEcs
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class ExecutionOrderAttribute : Attribute
    {
        public uint Value { get; }

        public ExecutionOrderAttribute(uint value)
        {
            Value = value;
        }
    }
}