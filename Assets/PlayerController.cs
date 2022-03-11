using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 playerInputs;

        playerInputs.x = Input.GetAxisRaw("Horizontal");
        playerInputs.y = Input.GetAxisRaw("Vertical");

        transform.position += (Vector3)playerInputs.normalized * speed * Time.deltaTime;

    }
}
