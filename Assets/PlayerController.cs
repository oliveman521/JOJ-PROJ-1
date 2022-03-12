using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite Standing;
    public Sprite WalkingAway;
    public float speed = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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

        if(rb.velocity.y>0&&rb.velocity.x==0)
        {
            sr.sprite = WalkingAway;
        }
        else
        {
            sr.sprite = Standing;
        }
    }
}
