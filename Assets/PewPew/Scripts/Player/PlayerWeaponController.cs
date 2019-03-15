using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerWeaponController : GameEventListener {

        HUDController _hudController;

        HUDController HUDController {
            get {
                if (_hudController == null)
                    _hudController = EventManager.Request<HUDController>("HUDController");

                return _hudController;
            }
        }

        public LaserScript laser;

        PlayerGunScript gun;
        PlayerMissleScript missile;
        bool OSX;

        void Update() {

            if (!_playing)
                return;

            if (OSX) {

                if (Input.GetButtonDown("Switch To Gun Mac")) {

                    laser.gameObject.SetActive(false);
                    missile.enabled = false;
                    gun.enabled = true;
                    HUDController.SetWeaponActive(0);

                } else if (Input.GetButtonDown("Switch To Laser Mac")) {

                    gun.enabled = false;
                    missile.enabled = false;
                    laser.gameObject.SetActive(true);
                    HUDController.SetWeaponActive(1);

                } else if (Input.GetButtonDown("Switch To Missile Mac")) {

                    laser.gameObject.SetActive(false);
                    gun.enabled = false;
                    missile.enabled = true;
                    HUDController.SetWeaponActive(2);
                }

            } else {

                if (Input.GetButtonDown("Switch To Gun Windows")) {

                    laser.gameObject.SetActive(false);
                    missile.enabled = false;
                    gun.enabled = true;
                    HUDController.SetWeaponActive(0);

                } else if (Input.GetButtonDown("Switch To Laser Windows")) {

                    gun.enabled = false;
                    missile.enabled = false;
                    laser.gameObject.SetActive(true);
                    HUDController.SetWeaponActive(1);

                } else if (Input.GetButtonDown("Switch To Missile Windows")) {

                    laser.gameObject.SetActive(false);
                    gun.enabled = false;
                    missile.enabled = true;
                    HUDController.SetWeaponActive(2);
                }
            }
        }

        protected override void Awake() {

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            gun = GetComponentInChildren<PlayerGunScript>();
            missile = GetComponentInChildren<PlayerMissleScript>();

            base.Awake();
        }
    }
}