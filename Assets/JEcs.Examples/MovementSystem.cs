using System.Collections.Generic;
using UnityEngine;

namespace AK.JEcs.Examples
{
    [ExecutionGroup(SystemGroup.Update), ExecutionOrder(100)]
    public class MovementSystem : ISystem
    {
        public void Update(HashSet<Entity> entities)
        {
            entities.Foreach<Transform, Velocity>((entity, transform, velocity) =>
            {
                transform.position += velocity.Value * Time.deltaTime;
            });
        }
    }
}