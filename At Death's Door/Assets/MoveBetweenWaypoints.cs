using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
	public float speed;

	[Space]
	public float delay;

	int currentWaypoint;
	float timer;

	private void Start()
	{
		currentWaypoint = 0;
		timer = delay;
	}

	private void Update()
	{
		timer -= Time.deltaTime;
	}

	private void FixedUpdate()
	{
		if (timer <= 0)
		{
			Vector2 movement = (waypoints[currentWaypoint].position - transform.position).normalized * speed * Time.deltaTime;
			transform.position += (Vector3)movement;
		}

		if(Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.3f)
		{
			currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
			timer = delay;
		}
	}
}
