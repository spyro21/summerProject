using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{


    public GameObject crosshairs;
    private Vector3 target;
    void Start()
    {
        
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        
        crosshairs.transform.position = new Vector2(target.x, target.y);
    }
}
