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

    public GameObject projectilePrefab;
    float shotSpeed = 7f;
    float range = 4f;


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

        if(Input.GetKeyDown(KeyCode.I)) {
            GameObject projectileTemp = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,90));
            projectileTemp.GetComponent<Rigidbody2D>().velocity.Set(this.GetComponent<Rigidbody2D>().velocity.x, shotSpeed);
        }
        if(Input.GetKeyDown(KeyCode.J)) {
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,180));
        }
        if(Input.GetKeyDown(KeyCode.K)) {
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,270));
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,0));
        }
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
