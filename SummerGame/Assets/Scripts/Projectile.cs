using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
            
    Player playerScript;
    Rigidbody2D rb;
    float shotSpeed;
    Vector3 startingVelocity = new Vector3();

    void Start()
    {
        playerScript = transform.parent.gameObject.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();       

        shotSpeed = playerScript.getShotSpeed();
    }

    public void startVelocity(char direction) {
        switch(direction) {
            case 'I':
                startingVelocity.x = shotSpeed;
                startingVelocity.y = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.y;
                break;
            case 'J':
                startingVelocity.x = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x;
                startingVelocity.y = -shotSpeed;
                break;
            case 'K':
                startingVelocity.x = -shotSpeed;
                startingVelocity.y = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.y;
                break;
            case 'L':
                startingVelocity.x = transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x;
                startingVelocity.y = shotSpeed;
                break;

            default:
                GameObject.Destroy(this);
                break;
        }

        rb.velocity = startingVelocity;

        StartCoroutine(waitForRangeDiminish());
        GameObject.Destroy(this);
    }

    void Update()
    {
        
    }

    IEnumerator waitForRangeDiminish() {
        yield return new WaitForSeconds(playerScript.getRange());
    }
}
