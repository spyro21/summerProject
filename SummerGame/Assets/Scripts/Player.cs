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
    float shotVelocity = 7f;
    float shotSpeed = 2f;
    float range = 3f;
    private bool isOnShotCooldown = false;
    float attackDamage = 5f;


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

        
        if(isOnShotCooldown) {
            StartCoroutine(waitForShotSpeed());
        } else {
            checkForFire();
        }
    }

    IEnumerator waitForShotSpeed() {
        isOnShotCooldown = false;
        yield return new WaitForSeconds(shotSpeed);
    }

    

    private void checkForFire() {
        GameObject projectileTemp = null;

        if(Input.GetKeyDown(KeyCode.I)) { // up
            projectileTemp = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,0));
            projectileTemp.transform.parent = gameObject.transform;
            projectileTemp.GetComponent<Projectile>().startVelocity('I');
        }
        else if(Input.GetKeyDown(KeyCode.J)) { // left
            projectileTemp = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,90));
            projectileTemp.transform.parent = gameObject.transform;
            projectileTemp.GetComponent<Projectile>().startVelocity('J');
        }
        else if(Input.GetKeyDown(KeyCode.K)) { // down
            projectileTemp = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,180));
            projectileTemp.transform.parent = gameObject.transform;
            projectileTemp.GetComponent<Projectile>().startVelocity('K');
        }
        else if(Input.GetKeyDown(KeyCode.L)) { // right
            projectileTemp = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,270));
            projectileTemp.transform.parent = gameObject.transform;
            projectileTemp.GetComponent<Projectile>().startVelocity('L');
        }

        if(projectileTemp != null) {
            isOnShotCooldown = true;
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

    public float getShotSpeed() {
        return shotSpeed;
    }

    public float getRange() {
        return range;
    }
    #endregion
}
