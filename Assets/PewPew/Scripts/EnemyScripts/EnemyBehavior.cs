using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    //The script for our basic grunt enemies
    public class EnemyBehavior : MonoBehaviour {

        GameObject player;
        GameObject path;
        Vector3 goal;
        Vector3 rand;
        string state;
        int timer;
        int moveSide;

        public GameObject[] visibleBits;
        public GruntWeaponScript[] MiniGunsEquipped;
        public SniperWeaponScript SniperGun;
        public float shipWeight = 1.0f;
        private float faceSpeed = 1.0f;
        private bool seen;
        private bool shooting;

        //transitions to the attack state when called
        public void Attack() {

            state = "ATTACK";
            //fire.enabled = true;
        }

        //activates the enemy
        public void Activate() {

            transform.parent = path.transform;
            state = "ACTIVE";
        }

        //destroys when it leaves the scene
        void Disable() {

            Destroy(gameObject);
        }

        //the basic state machine for our grunts
        void Update() {

            if (state.Equals("ACTIVE")) {

                //When it activates, it moves to the middle of the screen
                // TODO: Replace iTween solutions
                //iTween.LookUpdate(gameObject, iTween.Hash("looktarget", player.transform.position, "speed", 1.0f));
                goal = path.transform.position + (path.transform.forward * 30) + rand;

                // TODO: Replace iTween solutions
                //iTween.MoveUpdate(gameObject, iTween.Hash("position", goal, "time", 0.5f * shipWeight));
                if (Mathf.Abs(transform.position.x - goal.x) < 2 && Mathf.Abs(transform.position.y - goal.y) < 2 && Mathf.Abs(transform.position.z - goal.z) < 2)
                    Attack();

                //and becomes visible
                foreach (GameObject model in visibleBits)
                    model.GetComponent<Renderer>().enabled = true;

            } else if (state.Equals("ATTACK")) {

                //Moves back and forth in front of the player
                // TODO: Replace iTween solutions
                //iTween.LookUpdate(gameObject, iTween.Hash("looktarget", player.transform.position, "speed", 1.0f * faceSpeed));
                if (timer > 350) {

                    //State = "DISABLE";
                    timer = timer + 1;
                }

                if (moveSide < 50) {

                    transform.position = transform.position + (path.transform.right.normalized * .2f);
                    moveSide++;
                }

                if (moveSide >= 50) {

                    transform.position = transform.position - (path.transform.right.normalized * .2f);
                    moveSide++;
                }

                if (moveSide == 100) {

                    moveSide = 0;
                }

                //and starts shooting
                foreach (GruntWeaponScript pewpew in MiniGunsEquipped) {

                    if (pewpew != null)
                        pewpew.enabled = true;

                }

                if (SniperGun != null)
                    SniperGun.enabled = true;

            } else if (state.Equals("DISABLE")) {

                //eventually deparents the enemy

                //fire.enabled = false;
                goal = transform.position - (path.transform.forward * 20);

                // TODO: Replace iTween solutions
                //iTween.MoveUpdate(gameObject, iTween.Hash("position", goal, "time", 0.5f * shipWeight));
                timer--;

                if (timer < 310)
                    Disable();

            } else if (state.Equals("IDLE")) {

                // TODO: Replace iTween solutions
                //iTween.LookUpdate(gameObject, iTween.Hash("looktarget", player.transform.position, "speed", 1.0f * faceSpeed));
            }
        }

        void Start() {

            path = GameObject.FindGameObjectWithTag("PathObject");
            player = GameObject.FindGameObjectWithTag("Player");
            state = "IDLE";

            timer = 0;
            moveSide = 0;
            rand = new Vector3(Random.Range(-5f, 5f), Random.Range(-10f, 10f), Random.Range(-5f, 5f));

            //hide all parts
            foreach (GameObject model in visibleBits) {
                model.GetComponent<Renderer>().enabled = false;
            }

            //disable all weapon scripts
            foreach (GruntWeaponScript pewpew in MiniGunsEquipped) {
                pewpew.enabled = false;
            }

            if (SniperGun != null)
                SniperGun.enabled = false;
        }
    }
}