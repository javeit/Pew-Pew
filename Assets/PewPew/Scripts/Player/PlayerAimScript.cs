using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class 
    PlayerAimScript : GameEventListener {

        public Transform target;

        void Update() {

            if (!_playing || _paused)
                return;

            transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        }
    }
}