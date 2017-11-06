using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 0;
	public int offense = 0;
	public int defense = 0;
	public float velocity = 0.0f;
	public string attackAnimation;
	public string walkAnimation;
	public string deathAnimation;
	public static int charCount = 0;

	Animator anim;

	private Rigidbody2D body;
	public bool attack = false;
	public bool stop = false;
	private int count = 25;

	public static Character opponent;

	void Start () {
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D>();
	}

	void Move() {
		if (attack == false) {
			body.velocity = new Vector2 (velocity, 0);
		} else {
			body.velocity = new Vector2 (0, 0);
		}
	}

    public void GetHit(int dmg) {
		health = health - dmg;
	}

	void Death() {
		if (health <= 0) {
			anim.Play ("c3_death", -1, 0f);
			Character.opponent = null;
			opponent.attack = false;
			opponent.stop = false;
			Destroy (this.gameObject);
			charCount = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D enemy){
		if (enemy.gameObject.tag == "Player") {
			attack = true;
			Character.opponent = this;
			GetHit (10);
		}
		if (enemy.gameObject.tag == "Enemy") {
			attack = false;
			stop = true;
		}
	}

	void OnCollisionStay2D(Collision2D enemy){
		if (enemy.gameObject.tag == "Player") {
			attack = true;
			Character.opponent = this;
			count++;
		}
		if (enemy.gameObject.tag == "Enemy") {
			attack = false;
			stop = false;
		}
	}
		
	void OnCollisionExit2D(Collision2D enemy){
		attack = false;
		stop = false;
		Character.opponent = null;
		Debug.Log ("Exit");
	}

	void Update () {
		if (!stop) {
			Move ();
		}
		if (Character.opponent) {
			if (attack == true && count >= 25) {
				anim.Play (attackAnimation, -1, 0f);
				count = 0;
				GetHit (10);
				Death ();
			}
		} 
		count++;
	}
}
