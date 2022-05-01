using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace Mogze.Core.Services
{
    public static class Services
    {
        private static bool isInitialized = false;
        private static readonly Dictionary<Type, IService> ServicesMap = new Dictionary<Type, IService>();

        public static void AddService<T>(T service) where T : IService
        {
            if (!isInitialized)
            {
                ServicesMap.Add(typeof(T), service);
            }
            else
            {
                Debug.LogError("You are trying to add a service after initialization");
            }
        }

        public static async Task Initialize()
        {
            if (isInitialized) return;

            foreach (var service in ServicesMap)
            {
                await service.Value.Initialize();
            }

            isInitialized = true;
        }

        /// <summary>
        /// To be paired with OnApplicationPause event in Unity.
        /// </summary>
        public static void Pause(bool isPaused)
        {
            foreach (var service in ServicesMap)
            {
                service.Value.Pause(isPaused);
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