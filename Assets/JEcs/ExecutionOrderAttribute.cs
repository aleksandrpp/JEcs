using System;

namespace AK.JEcs
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExecutionOrderAttribute : Attribute
    {
        public uint Value { get; }

        public ExecutionOrderAttribute(uint value)
        {
            Value = value;
        }
    }
}