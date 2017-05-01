using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreColor : MonoBehaviour {
		//CoreHP
		public int coreHP;

		//flag core destroyed
		public bool coreDestroyed = false;

		//EXPLOSIONS
		public ParticleSystem Explosion;

		//Colors as core is damaged
		public Color fullHP;
		public Color HP80;
		public Color HP60;
		public Color HP40;
		public Color HP20;

		//When hit by different player weapons, remove diffrent amounts of HP
		void OnCollisionEnter(Collision col) {
			//if hit by playerBeam (minus 1000 hp)
			if (col.gameObject.tag == "playerBeam") {
				coreHP -= 50;
			}

			//if hit by playerMissile (minus 30hp)
			else if (col.gameObject.tag == "playerMissile") {
				coreHP -= 15;
			}
			//if hit by any object (minus 1 hp)
			else {
				coreHP -= 1;
			}
		}

		//Check on part HP
		void Update () {

			//change color based on HP
			/*if (coreHP <= 200) {
			gameObject.GetComponent<Renderer>().material.color = Color.Lerp(fullHP, HP80, 1.0f);
			}
			if (coreHP <= 150) {
				gameObject.GetComponent<Renderer>().material.color = Color.Lerp(HP80, HP60, 1.0f);
			}
			if (coreHP <= 100) {
				gameObject.GetComponent<Renderer>().material.color = Color.Lerp(HP60, HP40, 1.0f);
			}
			if (coreHP <= 50) {
				gameObject.GetComponent<Renderer>().material.color = Color.Lerp(HP40, HP20, 1.0f);
			}*/
				
			
			//when part ded, do some stuff
			if (coreHP <= 0) {
				onDeath ();
			}

		}

		//when core ded
		void onDeath() {
			coreDestroyed = true;
			Destroy (gameObject);
		}
		
}
