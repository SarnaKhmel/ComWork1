using UnityEngine;
using System.Collections;
using System.IO;

public class Enemy : Creature {

	Rigidbody2D rigEnemy;
	public static Enemy enemy;
	Player player;
	bool attack;

	void Start () {
		enemy = GetComponent<Enemy>();
		attack = false;
		player = Player.player;
		rigEnemy = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		if(!attack)
		Move ();
		Attack ();
		Death ();
	}

	void Move(){
		rigEnemy.velocity = new Vector2 (-1, rigEnemy.velocity.y);
	}

	protected override void Attack(){
		if (player) {
			if (Vector2.Distance (transform.position, player.transform.position) < 1f) {
				attack = true;
				player.GetHit (offence);
			}
		}
	}

	protected override void Death(){
		/*if (health <= 0) {
			Destroy (this);
		}*/
		/*if (Input.GetKeyUp (KeyCode.A)) {
			anim.Play(enemy_death_1.name);
			Debug.Log ("a");
		}*/
	}
}
