using UnityEngine;
using System.Collections;
using System.IO;

public class Player : Creature {

	public static Player player;
	public static Transform opponent;
	public Sprite playerSprite;
	Rigidbody2D rig;
	Enemy enemy;
	bool attack;

	void Start () {
		player = this;
		GetComponent<Player> ();
		//opponent.GetComponent<Enemy> ();
		enemy = GetComponent<Enemy>();
		attack = false;
		rig = player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!attack)
			Move ();
		//Attack ();
		Death ();
		//Debug.Log (Vector2.Distance (enemy.transform.position, transform.position));
	}

	void Move(){
		rig.velocity = new Vector2(1, rig.velocity.y);
	}

	protected override void Attack(){
		if (Vector2.Distance (transform.position, enemy.transform.position) < 10f) {
			attack = true;
			enemy.GetHit (offence);

		}
	}

	protected override void Death(){
		/*if (health <= 0) {
			Destroy (this);
			Destroy (playerSprite, 0.5f);
		}*/

	}
}
