using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior : MonoBehaviour
{
    Rigidbody2D myParentRigidBody;
    [SerializeField] Transform parentTransform;

    public bool isAHumanKilled; // is any human on the level is killed ?
    [SerializeField] float runAwaySpeed = 5f; // how much running speed the human will have
    [SerializeField] float walkingSpeed = 2f;
    float currentSpeed;

    private void Start()
    {
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
            myParentRigidBody.velocity = new Vector2(runAwaySpeed, myParentRigidBody.velocity.y);
        } else
        {
            myParentRigidBody.velocity = new Vector2(walkingSpeed, myParentRigidBody.velocity.y);
        }

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
