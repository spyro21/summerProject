using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    #region Variables

    public float startingHealth;

    float health;

    Rigidbody2D rb;
    float movementSpeed = 5f;
    Vector2 movement;
    #endregion

    #region Methods
    public void takeDamage(float damage) { health -= damage; } 

    void Start()
    {
        health = startingHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    #endregion

    #region HelperMethods
    public Vector2 getMovement() {
        return movement;
    }
    #endregion
}
