using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitchfork : MonoBehaviour
{
	public void OnCollisionEnter2D(Collision2D col)
	{
		print(col.gameObject.name);

		if(col.gameObject.tag == "Human")
		{
			Destroy(gameObject);
		}
	}
}
