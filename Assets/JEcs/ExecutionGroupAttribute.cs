using System;

namespace AK.JEcs
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class ExecutionGroupAttribute : Attribute
    {
        public SystemGroup Value { get; }

        public ExecutionGroupAttribute(SystemGroup value)
        {
            Value = value;
        }
    }
}