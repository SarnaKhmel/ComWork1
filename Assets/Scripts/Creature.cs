using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {

	// Use this for initialization
	public string nam;
	public float health;
	public float defense;
	public int offence;

	public void GetHit(int playerDamage){
		health = health - playerDamage;
	}

	protected abstract void Attack ();
	protected abstract void Death ();

}
