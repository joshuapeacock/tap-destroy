using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.Core
{
    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public T[] prefabs;
        public int size;

        private List<T> pool;

        public void Awake()
        {
            pool = new List<T>(size);

            for (var i = 0; i < size; i++)
            {
                var randomIndex = Random.Range(0, prefabs.Length);
                var pooledObject = Instantiate(prefabs[randomIndex], transform);
                pooledObject.gameObject.SetActive(false);
                pool.Add(pooledObject);
            }
        }

        public T Get()
        {
            foreach (T obj in pool)
            {
                if (obj.gameObject.activeInHierarchy == false)
                {
                    return obj;
                }
            }
            Debug.Log("All objects in pool are active.", this);
            return null;
        }
    }
}
