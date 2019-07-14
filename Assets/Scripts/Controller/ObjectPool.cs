using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Controller
{
    public class ObjectPool
    {
        private Dictionary<string, Queue<BaseModel>> _pools;

        public ObjectPool()
        {
            _pools = new Dictionary<string, Queue<BaseModel>>();
        }

        /// <summary>
        /// Adds game objects created from prefab to object pool
        /// </summary>
        /// <param name="poolName">Pool's name</param>
        /// <param name="obj">Object to create</param>
        /// <param name="count">Count of objects to create</param>
        /// <param name="parent">Parent game object on scene</param>
        public void AddPool(string poolName, BaseModel obj, int count, Transform parent)
        {
            var newPool = new Queue<BaseModel>();

            for (int i = 0; i < count; i++)
            {
                var newObj = Object.Instantiate(obj, Vector3.zero, Quaternion.identity, parent);
                newObj.SetActive(false);
                newPool.Enqueue(newObj);
            }
            
            _pools.Add(poolName, newPool);
        }

        private Queue<BaseModel> GetPool(string poolName)
        {
            _pools.TryGetValue(poolName, out var pool);
            return pool;
        }

        public void AddObjectToPool(string poolName, BaseModel obj)
        {
            var pool = GetPool(poolName);
            obj.SetActive(false);
            pool?.Enqueue(obj);
        }

        /// <summary>
        /// Get object from pool
        /// </summary>
        /// <param name="poolName">Pool name</param>
        /// <returns>Active object from pool</returns>
        /// <exception cref="NullReferenceException">throw NPE when pool is not found</exception>
        public BaseModel GetObjectFromPool(string poolName)
        {
            var pool = GetPool(poolName);
            if (pool == null) return null;
            var obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
    }
}