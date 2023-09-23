using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AK.JEcs.Examples
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private GameObject _prototype;
        [SerializeField] private uint _count = 1000;
        
        private IEntityWorld _entityWorld;

        private void Start()
        {
            _entityWorld = new EntityWorld();

            for (int i = 0; i < _count; i++)
            {
                var position = Random.insideUnitSphere;
                
                var entity = new Entity(_prototype, position, Quaternion.identity);
                
                if (entity.Contains(out Velocity component))
                    component.Value = position - Vector3.zero;

                _entityWorld.Entities.Add(entity);
            }

            _entityWorld.AddSystem(new MovementSystem());
        }

        private void Update()
        {
            if (Time.frameCount % 500 == 0)
            {
                _entityWorld.AddSystem(new RotationSystem());
            }
            
            if (Time.frameCount % 2000 == 0)
            {
                _entityWorld.RemoveSystem(new RotationSystem());
            }
            
            _entityWorld.Update();
        }

        private void FixedUpdate()
        {
            _entityWorld.FixedUpdate();
        }

        private void LateUpdate()
        {
            _entityWorld.LateUpdate();
        }

        private void OnDestroy()
        {
            _entityWorld.Dispose();
        }
    }
}