using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessing : MonoBehaviour
{
    [HideInInspector] public bool doesPossess;

    Vector3 respawnPosition;
    bool humanInRange;

    private void Update()
    {
        this.gameObject.SetActive(!doesPossess);

        if (humanInRange)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Human")
        {

            
        }
    }

    public void ExitBody()
    {
        doesPossess = false;
        transform.position = respawnPosition;
    }
}
