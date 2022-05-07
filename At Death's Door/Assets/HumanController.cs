using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public bool possessed;
    public float speed;

    float input;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (possessed)
        {
            input = (Input.GetAxisRaw("Horizontal"));
            rb.velocity = new Vector2(input * speed * Time.deltaTime, rb.velocity.y);
        }
    }
}
