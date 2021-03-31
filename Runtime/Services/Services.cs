using System;
using System.Collections.Generic;

namespace Mogze.Core.Services
{
    public static class Services
    {
        private static readonly Dictionary<Type, IService> ServicesMap = new Dictionary<Type, IService>();

        public static void AddService<T>(T service) where T : IService
        {
            ServicesMap.Add(typeof(T), service);
        }

        public static void Initialize()
        {
            foreach (var service in ServicesMap)
            {
                service.Value.Initialize();
            }
        }

        public static void Close()
        {
            foreach (var service in ServicesMap)
            {
                service.Value.Close();
            }
        }

        public static T GetService<T>() where T : IService
        {
            if (!ServicesMap.ContainsKey(typeof(T)))
            {
                throw new Exception($"Service not found: {typeof(T)}");
            }

            return (T)ServicesMap[typeof(T)];
        }
    }
}