using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {

	private float health = 10f;
	public void takeDamage(float damage) {
		health -= damage;
	}
}
