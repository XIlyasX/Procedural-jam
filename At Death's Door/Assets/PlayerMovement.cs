using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    public Transform target;

    Rigidbody2D rb;

    Vector2 input;

    Vector3 nullVector = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input *= 10;
        Debug.Log(input);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (rb.position + input) - rb.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
        rb.velocity = input.normalized * speed;
    }
}