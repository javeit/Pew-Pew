using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour {

        public T original;
        public int initialPoolSize;

        List<T> _pooledObjects;
        List<T> _usedObjects;

        public T GetPooledObject() {

            T poolableObject;

            if (_pooledObjects.Count > 0) {

                poolableObject = _pooledObjects[0];
                _pooledObjects.RemoveAt(0);

            } else if(original != null) {

                poolableObject = Instantiate<T>(original, transform);

            } else {

                poolableObject = null;
            }

            _usedObjects.Add(poolableObject);

            return poolableObject;
        }

        public void ReturnToPool(T pooledObject) {

            if (pooledObject == null)
                return;

            _pooledObjects.Add(pooledObject);
            _usedObjects.Remove(pooledObject);

            pooledObject.gameObject.SetActive(false);
            pooledObject.transform.SetParent(transform);
        }

        void Awake() {

            _pooledObjects = new List<T>();
            _usedObjects = new List<T>();

            if (original != null) {

                T newPoolableObject;

                for (int i = 0; i < initialPoolSize; i++) {

                    newPoolableObject = Instantiate<T>(original, transform);
                    newPoolableObject.gameObject.SetActive(false);

                    _pooledObjects.Add(newPoolableObject);
                }
            }
        }
    }
}