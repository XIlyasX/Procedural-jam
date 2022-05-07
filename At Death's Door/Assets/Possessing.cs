using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Possessing : MonoBehaviour
{
    GameManager manager;

    [HideInInspector] public bool doesPossess;

    Transform activeHuman;
    Vector3 respawnPosition;
    bool humanInRange;

    public GameObject sprite;


    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        sprite.SetActive(!doesPossess);

        if (doesPossess)
        {
            respawnPosition = activeHuman.transform.position;
            transform.position = activeHuman.position;
        }

        if (humanInRange && !doesPossess)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.Shake();
                respawnPosition = activeHuman.transform.position;
                activeHuman.GetComponent<HumanBehavior3BOUD>().isPossessed = true;
                activeHuman.GetComponent<HumanBehavior3BOUD>().possessScript = this;
                doesPossess = true;
                humanInRange = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Human")
        {
            humanInRange = true;

            if(!doesPossess)
                activeHuman = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Human")
        {
            humanInRange = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DemonHazard")
        {
            manager.GameOver();
            this.gameObject.SetActive(false);
        }
    }

    public void ExitBody()
    {
        doesPossess = false;
        manager.Shake();
        transform.position = respawnPosition;
    }
}
