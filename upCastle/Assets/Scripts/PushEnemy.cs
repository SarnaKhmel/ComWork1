using UnityEngine;
using System.Collections;

public class PushEnemy : MonoBehaviour {

	public GameObject spawner;
	public int e_energy = 0;

	void Start () {
		spawner = this.gameObject;
	}

	void PushCharacter(string name){
		Enemy character = Instantiate (Resources.Load (name, typeof(Enemy))) as Enemy;
		character.transform.position = spawner.transform.position;
		character = GetComponent<Enemy> ();
	}

	void Update () {
		if (Character.enemyCount == 0 && e_energy >= 400) {
			//if (Input.GetKeyUp (KeyCode.E)) {
				PushCharacter ("char_3");
				e_energy = 0;
				Character.enemyCount = 1;
			//}
		}
		e_energy++;
	}
}
