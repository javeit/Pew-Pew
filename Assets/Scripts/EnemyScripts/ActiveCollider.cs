using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class ActiveCollider : MonoBehaviour {

        public int count = 0;

        private int passes = 0;

        public EnemyBehavior enemy;

        void OnTriggerEnter(Collider other) {

            if (other.CompareTag("Player") && passes >= count)
                passes++;
        }

        void OnTriggerExit(Collider other) {

            if (other.CompareTag("Player") && passes >= count) {

                enemy.Activate();
                transform.parent = null;
            }
        }
    }
}