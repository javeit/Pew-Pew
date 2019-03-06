using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PewPew {

    public class EventManagerTest : MonoBehaviour {

        public float testValue;

        public bool testRequest1;

        public float testA;
        public float testB;
        public float testT;

        float Request1(float a, float b, float t) {

            t = Mathf.Clamp01(t);

            return Mathf.Lerp(a, b, t);
        }

        void AddRequests() {

            EventManager.AddRequest<float, float, float, float>("floatRequest1", Request1);
        }

        void RemoveRequests() {

            EventManager.RemoveRequest<float, float, float, float>("floatRequest1");
        }

        void Update() {

            if (testRequest1) {

                testValue = EventManager.Request<float, float, float, float>("floatRequest1", testA, testB, testT);

                testRequest1 = false;
            }
        }

        void Awake() {

            AddRequests();
        }

        void OnDestroy() {

            RemoveRequests();
        }
    }
}