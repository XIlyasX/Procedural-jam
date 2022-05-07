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

    [Space]
    public float possessDelay;
    [HideInInspector] public float timer;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        timer = possessDelay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        sprite.SetActive(!doesPossess);

        if (doesPossess)
        {
            respawnPosition = activeHuman.transform.position;
            transform.position = activeHuman.position;
        }

        if (timer <= 0)
        {
            // GAME OVER LOGIC
            Stats.hasDiedOnce = true;
            Invoke("Restart", 2f);
            manager.Shake();
            this.gameObject.SetActive(false);
        }

        if (doesPossess) return;
        if (humanInRange)
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

    public void Restart()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Human")
        {
            humanInRange = true;
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

    public void ExitBody()
    {
        doesPossess = false;
        manager.Shake();
        transform.position = respawnPosition;
    }
}
