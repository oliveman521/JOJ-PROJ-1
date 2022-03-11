using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 playerInputs;

        playerInputs.x = Input.GetAxisRaw("Horizontal");
        playerInputs.y = Input.GetAxisRaw("Vertical");


        rb.velocity = playerInputs.normalized * speed;

        if(rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
        }
        else if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, transform.rotation.z);
        }
    }
}
