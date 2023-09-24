using System;
using System.Collections.Generic;
using System.Reflection;

namespace AK.JEcs
{
    public class EntityWorld : IEntityWorld
    {
        public HashSet<Entity> Entities { get; } = new();
        
        private SystemList _updateSystems = new();
        private SystemList _fixedUpdateSystems = new();
        private SystemList _lateUpdateSystems = new();

        public void AddSystem(ISystem system)
        {
            if (system == null)
                return;
            
            GetSystemGroup(system.GetType()).Add(system);
        }

        public void RemoveSystem(Type systemType)
        {
            if (systemType == null)
                return;

            GetSystemGroup(systemType).Remove(systemType);
        }
        
        private SystemList GetSystemGroup(Type systemType) =>
            (systemType.GetCustomAttribute<ExecutionGroupAttribute>()?.Value ?? 0) switch
            {
                SystemGroup.Update => _updateSystems,
                SystemGroup.FixedUpdate => _fixedUpdateSystems,
                SystemGroup.LateUpdate => _lateUpdateSystems,
                _ => _updateSystems
            };

        public void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateSystems.Count; i++)
                _fixedUpdateSystems[i].Update(Entities);
        }

        public void Update()
        {
            for (int i = 0; i < _updateSystems.Count; i++)
                _updateSystems[i].Update(Entities);
        }

        public void LateUpdate()
        {
            for (int i = 0; i < _lateUpdateSystems.Count; i++)
                _lateUpdateSystems[i].Update(Entities);
        }

        public void Dispose()
        {
            foreach (var entity in Entities)
                entity.Dispose();
        }
    }
}