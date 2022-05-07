using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehavior3BOUD : MonoBehaviour
{
    GameManager manager;

    Rigidbody2D myParentRigidBody;
    [SerializeField] Transform parentTransform;

    public bool isAHumanKilled; // is any human on the level is killed ?
    [SerializeField] float runAwaySpeed = 5f; // how much running speed the human will have
    [SerializeField] float walkingSpeed = 2f;
    float currentSpeed;

    public bool isPossessed;

    [Space]

    // Demon control variables
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundMask;
    float horizontalInput;
    bool isGrounded;
    public GameObject arrow;

    [HideInInspector] public Possessing possessScript;

    [SerializeField] ParticleSystem humanDeathFx;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        myParentRigidBody = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        isAHumanKilled = manager.isHumanKilled;
        arrow.SetActive(isPossessed);

        if (!isPossessed)
        {
            //FLiping the player dependign on the run away speed
            if (runAwaySpeed > 0 || walkingSpeed > 0)
            {
                parentTransform.localScale = new Vector3(1, 1, 1);
            }
            else if (runAwaySpeed < 0 || walkingSpeed < 0)
            {
                parentTransform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (myParentRigidBody.velocity.x > 0.3f)
            {
                parentTransform.localScale = new Vector3(1, 1, 1);
            }
            else if (myParentRigidBody.velocity.x < -0.3f)
            {
                parentTransform.localScale = new Vector3(-1, 1, 1);
            }

            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isPossessed)
        {
            //Human movement behavior
            if (isAHumanKilled)
            {
                myParentRigidBody.velocity = new Vector2(runAwaySpeed, myParentRigidBody.velocity.y);
            }
            else
            {
                myParentRigidBody.velocity = new Vector2(walkingSpeed, myParentRigidBody.velocity.y);
            }
        }
        else
        {
            // Ground cheking
            isGrounded = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - 0.8f), new Vector2(0.75f, 0.25f), 0f, Vector2.down, 0.2f, groundMask);

            // Demon controlled velocity
            myParentRigidBody.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, myParentRigidBody.velocity.y);

        }
    }

    void Jump ()
    {
        myParentRigidBody.velocity = new Vector2(myParentRigidBody.velocity.x, jumpForce);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isPossessed) return;

        if (collision.gameObject.tag == "Ground")
        {
            runAwaySpeed = -runAwaySpeed;
            walkingSpeed = -walkingSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPossessed) return;

        if (collision.gameObject.tag == "Hazard")
        {
            runAwaySpeed = -runAwaySpeed;
            walkingSpeed = -walkingSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hazard")
        {
            manager.HumanKilled();

            ParticleSystem particles = Instantiate(humanDeathFx, transform.position, Quaternion.identity);

            possessScript.ExitBody();

            Destroy(this.gameObject);
        }
    }
}
