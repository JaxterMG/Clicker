// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using System.Collections.Generic;
using UnityEngine;

namespace Develop.Source.Units
{
    //TODO: Redo UnitsPool
    public class UnitsPool : MonoBehaviour
    {
        private Queue<GameObject> pool = new Queue<GameObject>();
        public GameObject Prefab;
        public Transform PoolRoot;
        public int InitialSIze = 50;

        private void Awake()
        {
            for (int i = 0; i < InitialSIze; i++)
            {
                GameObject obj = Instantiate(Prefab);
                obj.SetActive(false);
                if (PoolRoot != null)
                {
                    obj.transform.SetParent(PoolRoot);
                }

                pool.Enqueue(obj);
            }
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            GameObject obj;
            if (pool.Count > 0)
            {
                obj = pool.Dequeue();
            }
            else
            {
                obj = Instantiate(Prefab);
                if (PoolRoot != null)
                {
                    obj.transform.SetParent(PoolRoot);
                }
            }

            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
            return obj;
        }

        public void Return(GameObject obj)
        {
            obj.SetActive(false);
            if (PoolRoot != null)
            {
                obj.transform.SetParent(PoolRoot);
            }

            pool.Enqueue(obj);
        }
    }
}