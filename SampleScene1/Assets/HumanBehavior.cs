using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    Rigidbody2D myParentRigidBody;
    Animator anim;
    [SerializeField] Transform parentTransform;

    public bool isAHumanKilled; // is any human on the level is killed ?
    [SerializeField] float runAwaySpeed = 5f; // how much running speed the human will have
    [SerializeField] float walkingSpeed = 2f;
    float currentSpeed;

    [SerializeField] float minStopTime;
    [SerializeField] float maxStopTime;
    float currentStopTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myParentRigidBody = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        //FLiping the player dependign on the run away speed
        if(runAwaySpeed > 0 || walkingSpeed > 0)
        {
            parentTransform.localScale = new Vector3(1, 1, 1);
        } else if(runAwaySpeed < 0 || walkingSpeed < 0)
        {
            parentTransform.localScale = new Vector3(-1, 1, 1);
        }

        //Human movement behavior
        if (isAHumanKilled)
        {
            anim.SetBool("isMoving", true);
            myParentRigidBody.velocity = new Vector2(runAwaySpeed, myParentRigidBody.velocity.y);
        } else
        {
            if(currentStopTime <= 0)
            {
                anim.SetBool("isMoving", true);
                myParentRigidBody.velocity = new Vector2(walkingSpeed, myParentRigidBody.velocity.y);
                StartCoroutine(ResetWaitTIme());
            }else
            {
                anim.SetBool("isMoving", false);
                myParentRigidBody.velocity = new Vector2(0, myParentRigidBody.velocity.y);
                currentStopTime -= Time.deltaTime;
            }
        }

    }

    IEnumerator ResetWaitTIme()
    {
        float randomWaitTime = Random.Range(minStopTime, maxStopTime);
        yield return new WaitForSeconds(randomWaitTime);
        currentStopTime = randomWaitTime;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            runAwaySpeed = -runAwaySpeed;
            walkingSpeed = -walkingSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            runAwaySpeed = -runAwaySpeed;
            walkingSpeed = -walkingSpeed;
        }
    }
}
