using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerAimScript : MonoBehaviour {

        HUDController _hudController;

        HUDController HUDController {

            get {

                if (_hudController == null)
                    _hudController = EventManager.Request<HUDController>("HUDController");

                return _hudController;
            }
        }

        public Transform target;

        void Update() {

            if (!HUDController.GetPaused())
                transform.rotation = Quaternion.LookRotation(target.position - transform.position);
        }
    }
}