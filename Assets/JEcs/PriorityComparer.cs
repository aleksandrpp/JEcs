using System.Collections.Generic;
using System.Reflection;

namespace AK.JEcs
{
    public class PriorityComparer : IComparer<ISystem>
    {
        public int Compare(ISystem x, ISystem y)
        {
            var xPriority = x?.GetType().GetCustomAttribute<ExecutionOrderAttribute>()?.Value ?? 0;
            var yPriority = y?.GetType().GetCustomAttribute<ExecutionOrderAttribute>()?.Value ?? 0;
            return xPriority.CompareTo(yPriority);
        }
    }
}