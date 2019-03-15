using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class AimObjectController : GameEventListener {

        public float moveSpeedMouse;
        public float moveSpeedController;

        float xValMouse;
        float xValController;
        float yValMouse;
        float yValController;

        bool OSX;

        void Update() {

            if (!_playing || _paused)
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

        protected override void OnInitGame() {

            base.OnInitGame();

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;
        }
    }
}