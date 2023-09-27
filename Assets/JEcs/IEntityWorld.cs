using System;
using System.Collections.Generic;

namespace AK.JEcs
{
    public interface IEntityWorld : IDisposable
    {
        HashSet<Entity> Entities { get; }

        void AddSystem<T>(T system) where T : ISystem;

        void RemoveSystem<T>() where T : ISystem;

        void FixedUpdate();

        void Update();

        void LateUpdate();
    }
}