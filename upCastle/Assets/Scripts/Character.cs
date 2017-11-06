using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int health = 0;
	public int offense = 0;
	public int defense = 0;
	public float velocity = 0.0f;
	public GameObject spawner;
	public string attackAnimation;
	public string walkAnimation;
	public string deathAnimation;

	private Rigidbody2D body;
	public bool attack = false;
	public bool stop = false;
	private Animator anim;
	private int count = 25;

	public static Enemy opponent;
	public static int enemyCount = 0;

	void Start () {
		spawner = GetComponent<GameObject> ();
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

	void GetHit(int dmg) {
		health = health - dmg;
	}

	void OnCollisionEnter2D(Collision2D enemy){
		if (enemy.gameObject.tag == "Enemy") {
			attack = true;
			Enemy.opponent = this;
			GetHit (10);
		}
		if (enemy.gameObject.tag == "Player") {
			stop = true;
			Debug.Log ("stop!!!");
		}
	}

	void OnCollisionStay2D(Collision2D enemy){
		if (enemy.gameObject.tag == "Enemy") {
			attack = true;
			Enemy.opponent = this;
			count++;
		}
		if (enemy.gameObject.tag == "Player") {
			stop = true;
		}
	}

	void OnCollisionExit2D(Collision2D enemy){
		attack = false;
		stop = false;
		Enemy.opponent = null;
	}

	void Death() {
		if (health <= 0) {
			anim.Play ("c1_death", -1, 0f);
			Enemy.opponent = null;
			opponent.attack = false;
			opponent.stop = false;
			Destroy (this.gameObject);
			Enemy.charCount = 0;
		}
	}

	void Update () {
		if (!stop) {
			Move ();
		}
		if (Enemy.opponent) {
			if (attack == true && count >= 25) {
				anim.Play (attackAnimation, -1, 0f);
				count = 0;
				GetHit (10);
				Death ();
			}
		}
		count++;
		Debug.Log (Character.opponent);
		Debug.Log (Enemy.opponent);
		Debug.Log (stop);
		Debug.Log (attack);
	}
}
