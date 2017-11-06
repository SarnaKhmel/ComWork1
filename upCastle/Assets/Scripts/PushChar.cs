using UnityEngine;
using System.Collections;

public class PushChar : MonoBehaviour {

	public GameObject spawner;
	public int p_energy = 0;

	void Start () {
		spawner = this.gameObject;
	}

	void PushCharacter(string name){
		Character character = Instantiate (Resources.Load (name, typeof(Character))) as Character;
		character.transform.position = spawner.transform.position;
		character = GetComponent<Character> ();
	}

	void Update () {
		if (Enemy.charCount == 0 && p_energy >= 400) {
			if (Input.GetKeyUp (KeyCode.A)) {
				PushCharacter ("char_1");
				p_energy = 0;
				Enemy.charCount = 1;
			}
		}
		p_energy++;
	}
}
