using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerController : MonoBehaviour {

        HUDController _hudController;

        HUDController HUDController {
            get {
                if (_hudController == null)
                    _hudController = EventManager.Request<HUDController>("HUDController");

                return _hudController;
            }
        }

        public float maxSpeed;
        public bool wasHit;
        public float gracePeriod = 1f;

        float timeSinceLastHit;

        void Update() {

            float verticalMoveSpeed = maxSpeed * Input.GetAxis("Vertical");
            float horizontalMoveSpeed = maxSpeed * Input.GetAxis("Horizontal");

            if (((transform.localPosition.x < -3.5) && (horizontalMoveSpeed < 0)) || ((transform.localPosition.x > 3.5) && (horizontalMoveSpeed > 0)))
                horizontalMoveSpeed = 0;

            if (((transform.localPosition.y < -2) && (verticalMoveSpeed < 0)) || ((transform.localPosition.y > 2) && (verticalMoveSpeed > 0)))
                verticalMoveSpeed = 0;

            transform.Translate((Vector3.up * verticalMoveSpeed * Time.fixedDeltaTime) + (Vector3.right * horizontalMoveSpeed * Time.fixedDeltaTime));
        }

        void OnTriggerEnter(Collider col) {

            if (col.tag == "playerGun" || col.tag == "playerMissile" || col.tag == "EnemyBox")
                return;

            Hit();
        }

        public void Hit() {

            if(Time.time - timeSinceLastHit < gracePeriod)
                return;

            HUDController.DecrimentHearts();
            timeSinceLastHit = Time.time;
        }

        void Start() {

            timeSinceLastHit = Time.time;
        }
    }
}