using System.Collections.Generic;
using System.Reflection;

namespace AK.JEcs
{
    public class EntityWorld : IEntityWorld
    {
        public HashSet<Entity> Entities { get; } = new();
        
        private UniqueSortedList<ISystem> GetSystemGroup(ISystem system)
        {
            var attribute = system.GetType().GetCustomAttribute<ExecutionGroupAttribute>();
            return (attribute?.Value ?? 0) switch
            {
                SystemGroup.Update => _updateSystems,
                SystemGroup.FixedUpdate => _fixedUpdateSystems,
                SystemGroup.LateUpdate => _lateUpdateSystems,
                _ => _updateSystems
            };
        }
        
        private UniqueSortedList<ISystem> _updateSystems = new(new PriorityComparer());
        private UniqueSortedList<ISystem> _fixedUpdateSystems = new(new PriorityComparer());
        private UniqueSortedList<ISystem> _lateUpdateSystems = new(new PriorityComparer());

        public void AddSystem(ISystem system)
        {
            if (system == null)
                return;
            
            GetSystemGroup(system).Add(system);
        }

        public void RemoveSystem(ISystem system)
        {
            if (system == null)
                return;

            GetSystemGroup(system).Remove(system);
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateSystems.Count; i++)
                _updateSystems[i].Update(Entities);
        }

        public void Update()
        {
            for (int i = 0; i < _updateSystems.Count; i++)
                _updateSystems[i].Update(Entities);
        }

        public void LateUpdate()
        {
            for (int i = 0; i < _lateUpdateSystems.Count; i++)
                _updateSystems[i].Update(Entities);
        }

        public void Dispose()
        {
            foreach (var entity in Entities)
                entity.Dispose();
        }
    }
}