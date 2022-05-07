using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 7;
	public float smoothMoveTime = .1f;
	public float turnSpeed = 8;

	float angle;
	float smoothInputMagnitude;
	float smoothMoveVelocity;
	Vector2 velocity;

	new Rigidbody2D rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		float inputMagnitude = inputDirection.magnitude;
		smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

		float targetAngle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg - 90f;
		angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

		velocity = inputDirection * moveSpeed * smoothInputMagnitude;
		print(velocity);
	}

	void FixedUpdate()
	{
		//rigidbody.MoveRotation(Quaternion.Euler(Vector2.up * angle));
		rigidbody.rotation = angle;
		rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);
	}

	//3BOUD'S PREVIOUS CODE

	//public float speed;
	//public float rotateSpeed;

	//Rigidbody2D rb;
	//float interpolation;

	//Vector2 input;

	//Vector3 nullVector = Vector2.zero;

	//private void Start()
	//{
	//	rb = GetComponent<Rigidbody2D>();
	//}

	//private void Update()
	//{
	//	input.x = Input.GetAxisRaw("Horizontal");
	//	input.y = Input.GetAxisRaw("Vertical");
	//	input *= 10;
	//}

	//private void FixedUpdate()
	//{
	//	Vector2 direction = (rb.position + input) - rb.position;
	//	direction.Normalize();

	//	float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
	//	if (direction.magnitude > 0)
	//		rb.rotation = angle;

	//	rb.velocity = input.normalized * speed;
	//}
}
