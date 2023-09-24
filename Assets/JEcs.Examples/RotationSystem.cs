using System.Collections.Generic;
using UnityEngine;

namespace AK.JEcs.Examples
{
    [ExecutionGroup(SystemGroup.Update), ExecutionOrder(2)]
    public class RotationSystem : ISystem
    {
        public void Update(HashSet<Entity> entities)
        {
            entities.Foreach<Transform>((entity, transform) =>
            {
                transform.Rotate(Vector3.up, Time.deltaTime * 100);
            });
        }
    }
}