using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AK.JEcs
{
    public class Entity : IDisposable
    {
        public HashSet<Component> Components { get; } = new();
        
        private GameObject _object;

        public Entity(GameObject prototype, Vector3 position, Quaternion rotation)
        {
            _object = Object.Instantiate(prototype, position, rotation);
            
            foreach (var component in _object.GetComponents<Component>())
                Components.Add(component);
        }
            
        public void Dispose()
        {
            if (_object != null)
                Object.Destroy(_object);
        }
    }
}