using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartHealth : MonoBehaviour {
	//Amount of health this part has
	public int partHP;

	//Parent of this part
	public GameObject partParent;

	//ship death script
	public EnemyKilled deathScript;

	//capitalShip PlateRemoval Script
	public Capital_ArmorBreak peelScript;

	//capital level path change variable
	public bool pathChange = false;

	//Amount of health to take from parent when this part is destroyed
	public int HPfromParent;

	//EXPLOSIONS
	public ParticleSystem Explosion;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision col) {
		//if hit by playerBeam (minus 1000 hp)
		if (col.gameObject.tag == "playerBeam") {
			partHP -= 1000;
		}

		//if hit by playerMissile (minus 30hp)
		else if (col.gameObject.tag == "playerMissile") {
			partHP -= 30;
		}
		//if hit by any object (minus 1 hp)
		else {
			partHP -= 1;
		}
	}
	
	//Check if part is pepsi
	void Update () {

		if (partHP <= 0) {
			onDeath ();
		}
		
	}

	//Once a part is killed, remove it, play explosion
	//and remove an amount of HP from parent
	void onDeath() {
		//Remove any children of destroyed object
		foreach (Transform child in transform) {
			GameObject.Destroy (child.gameObject);
		}
		if (peelScript == null) { //do not destroy part if it is the capital ships armor piece
			Destroy (gameObject);

			Explosion.Play (true);
		}

		//deal with capital ship parts special case
		if (peelScript != null) {
			peelScript.breakArmor ();
			pathChange = true;
		}

		if (partParent != null) { //if part has a parent, subtract health from it
			EnemyPartHealth parentScript = partParent.GetComponent<EnemyPartHealth> ();
			parentScript.partHP -= HPfromParent;
		} else { //we have killed the core, remove entire prefab
			if (deathScript != null) {
				deathScript.afterDeath ();
			}
		}	
	}
}
