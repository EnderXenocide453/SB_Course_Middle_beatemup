using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataProviding
{
    public static class DataProvider
    {
        private static Dictionary<Type, IDataContainer> _containers = new Dictionary<Type, IDataContainer>();

        public static void RegisterData<T>(T container) where T : class, IDataContainer
        {
            _containers[typeof(T)] = container;
        }

        public static T GetData<T>() where T : class, IDataContainer, new()
        {
            if (_containers.TryGetValue(typeof(T), out var container))
                return (T)container;

            Debug.LogError($"Container of type {typeof(T)} not found. Create empty container");

            container = new T();
            _containers[typeof(T)] = container;
            return (T)container;
        }
    }
}
