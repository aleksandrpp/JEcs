using System;
using System.Collections.Generic;
using UnityEngine;

namespace AK.JEcs
{
    public static class Filters
    {
        public static bool Contains<T>(this Entity entity, out T component) where T : Component
        {
            foreach (var c in entity.Components)
            {
                if (c is T typeComponent)
                {
                    component = typeComponent;
                    return true;
                }
            }

            component = default;
            return false;
        }

        public static bool Contains<T1, T2>(this Entity entity, out (T1, T2) components) where T1 : Component where T2 : Component
        {
            if (entity.Contains(out T1 componentT1) && entity.Contains(out T2 componentT2))
            {
                components = (componentT1, componentT2);
                return true;
            }

            components = default;
            return false;
        }

        public static bool Contains<T1, T2, T3>(this Entity entity, out (T1, T2, T3) components) where T1 : Component where T2 : Component where T3 : Component
        {
            if (entity.Contains(out T1 componentT1) && entity.Contains(out T2 componentT2) && entity.Contains(out T3 componentT3))
            {
                components = (componentT1, componentT2, componentT3);
                return true;
            }

            components = default;
            return false;
        }

        public static bool Contains<T1, T2, T3, T4>(this Entity entity, out (T1, T2, T3, T4) components) where T1 : Component where T2 : Component where T3 : Component where T4 : Component
        {
            if (entity.Contains(out T1 componentT1) && entity.Contains(out T2 componentT2) && entity.Contains(out T3 componentT3) && entity.Contains(out T4 componentT4))
            {
                components = (componentT1, componentT2, componentT3, componentT4);
                return true;
            }

            components = default;
            return false;
        }


        public static void Foreach<T>(this HashSet<Entity> entities, Action<Entity, T> system) where T : Component
        {
            foreach (var entity in entities)
            {
                if (entity.Contains(out T component))
                    system?.Invoke(entity, component);
            }
        }

        public static void Foreach<T1, T2>(this HashSet<Entity> entities, Action<Entity, T1, T2> system) where T1 : Component where T2 : Component
        {
            foreach (var entity in entities)
            {
                if (entity.Contains(out (T1, T2) components))
                    system?.Invoke(entity, components.Item1, components.Item2);
            }
        }
        
        public static void Foreach<T1, T2, T3>(this HashSet<Entity> entities, Action<Entity, T1, T2, T3> system) where T1 : Component where T2 : Component where T3 : Component
        {
            foreach (var entity in entities)
            {
                if (entity.Contains(out (T1, T2, T3) components))
                    system?.Invoke(entity, components.Item1, components.Item2, components.Item3);
            }
        }
        
        public static void Foreach<T1, T2, T3, T4>(this HashSet<Entity> entities, Action<Entity, T1, T2, T3, T4> system) where T1 : Component where T2 : Component where T3 : Component where T4 : Component
        {
            foreach (var entity in entities)
            {
                if (entity.Contains(out (T1, T2, T3, T4) components))
                    system?.Invoke(entity, components.Item1, components.Item2, components.Item3, components.Item4);
            }
        }
    }
}