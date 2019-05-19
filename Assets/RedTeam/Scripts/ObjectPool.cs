using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    /// <summary>
    /// Maintains a pool of game objects
    /// </summary>
    public class ObjectPool : MonoBehaviour {

        public GameObject original;
        public int initialPoolSize;

        List<GameObject> _pooledObjects;
        List<GameObject> _usedObjects;

        /// <summary>
        /// Returns a pooled object of type <see cref="T"/> if available,
        /// otherwise, returns a new object of type <see cref="T"/>
        /// </summary>
        /// <returns>an object of type <see cref="T"/></returns>
        public GameObject GetPooledObject() {

            GameObject poolableObject;

            if (_pooledObjects.Count > 0) {

                poolableObject = _pooledObjects[0];
                _pooledObjects.RemoveAt(0);

            } else if(original != null) {

                poolableObject = Instantiate(original, transform);

            } else {

                poolableObject = null;
                Debug.LogError("Pooled object could not be created because the original template is null");
            }

            _usedObjects.Add(poolableObject);

            return poolableObject;
        }

        /// <summary>
        /// Returns a poolable object to the pool for use later
        /// </summary>
        /// <param name="poolableObject"></param>
        public void ReturnToPool(GameObject poolableObject) {

            if (poolableObject == null)
                return;

            _pooledObjects.Add(poolableObject);
            _usedObjects.Remove(poolableObject);

            poolableObject.SetActive(false);
            poolableObject.transform.SetParent(transform);
        }

        void Awake() {

            _pooledObjects = new List<GameObject>();
            _usedObjects = new List<GameObject>();

            if (original != null) {

                GameObject newPoolableObject;

                for (int i = 0; i < initialPoolSize; i++) {

                    newPoolableObject = Instantiate(original, transform);
                    newPoolableObject.gameObject.SetActive(false);

                    _pooledObjects.Add(newPoolableObject);
                }
            }
        }
    }
}