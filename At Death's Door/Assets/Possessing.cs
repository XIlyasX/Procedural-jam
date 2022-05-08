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
    public float checkRadius;
    public LayerMask humans;



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

		bool nearHuman = Physics2D.OverlapCircle(transform.position, checkRadius, humans);
		Collider2D col = Physics2D.OverlapCircle(transform.position, checkRadius, humans);
		if (nearHuman)
		{
			print("near human");
			humanInRange = true;

			if (!doesPossess)
				activeHuman = col.transform;
		}
		else
		{
			humanInRange = false;
		}

		print(doesPossess);


	}

    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Human")
    //    {
    //        print("near human");
    //        humanInRange = true;

    //        if (!doesPossess)
    //            activeHuman = collision.transform;
    //    }
    //    else
    //    {
    //        humanInRange = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Human")
        //{
        //    humanInRange = true;

        //    if(!doesPossess)
        //        activeHuman = other.transform;
        //}

        if(other.tag == "DemonHazard" && doesPossess == false)
		{
            
            
                manager.GameOver();
                this.gameObject.SetActive(false);
            AudioManager.instance.Play("HumanDeath", AudioManager.AudioPlay.Oneshot);


        }
        if (other.tag == "DEATH")
        {


            manager.GameOver();
            AudioManager.instance.Play("HumanDeath", AudioManager.AudioPlay.Oneshot);

            this.gameObject.SetActive(false);

        }
    }

    private void OnTriggerStay2D(Collider2D other)
	{
        

        if (other.tag == "DemonHazard" && doesPossess == false)
        {

            AudioManager.instance.Play("HumanDeath", AudioManager.AudioPlay.Oneshot);
            manager.GameOver();
            this.gameObject.SetActive(false);

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Human")
        {
            humanInRange = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "DemonHazard")
    //    {
    //        manager.GameOver();
    //        this.gameObject.SetActive(false);
    //    }
    //}

    public void ExitBody()
    {
        doesPossess = false;
        manager.Shake();
        transform.position = respawnPosition;
    }
}
