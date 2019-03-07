using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class AimObjectController : MonoBehaviour {

        HUDController _hudController;

        HUDController HUDController {
            get {
                if (_hudController == null)
                    _hudController = EventManager.Request<HUDController>("HUDController");

                return _hudController;
            }
        }

        public float moveSpeedMouse;
        public float moveSpeedController;

        private float xValMouse;
        private float xValController;
        private float yValMouse;
        private float yValController;

        private bool OSX;
        //Need this to disable while paused -Scott
        void Start() {

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update() {

            if (HUDController.GetPaused())
                return;

            if (OSX) {

                xValMouse = Input.GetAxis("Aim Horizontal Mac");
                yValMouse = Input.GetAxis("Aim Vertical Mac");

                transform.localPosition += new Vector3(xValMouse, yValMouse, 0) * moveSpeedMouse;

                xValController = Input.GetAxis("Aim Horizontal Mac Controller");
                yValController = Input.GetAxis("Aim Vertical Mac Controller");

                transform.localPosition += new Vector3(xValController, yValController, 0) * moveSpeedController;

            } else {

                xValMouse = Input.GetAxis("Aim Horizontal Windows");
                yValMouse = Input.GetAxis("Aim Vertical Windows");

                transform.localPosition += new Vector3(xValMouse, yValMouse, 0) * moveSpeedMouse;

                xValController = Input.GetAxis("Aim Horizontal Windows Controller");
                yValController = Input.GetAxis("Aim Vertical Windows Controller");

                transform.localPosition += new Vector3(xValController, yValController, 0) * moveSpeedController;
            }
        }
    }
}