using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public int health = 500;
	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}

	void GetHit(int dmg) {
		health = health - dmg;
	}

	void OnCollisionEnter2D (Collision2D enemy){
		GetHit (10);
	}

	void Update () {
	
	}
}
