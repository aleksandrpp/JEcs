using System.Collections.Generic;

namespace AK.JEcs
{
    public interface ISystem
    {
        void Update(HashSet<Entity> entities);
    }
}