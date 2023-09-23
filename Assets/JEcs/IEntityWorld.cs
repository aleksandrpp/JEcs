using System;
using System.Collections.Generic;

namespace AK.JEcs
{
    public interface IEntityWorld : IDisposable
    {
        HashSet<Entity> Entities { get; }

        void AddSystem(ISystem system);

        void RemoveSystem(ISystem system);

        void FixedUpdate();

        void Update();

        void LateUpdate();
    }
}