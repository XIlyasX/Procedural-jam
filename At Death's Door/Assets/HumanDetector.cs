using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDetector : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Human")
        {
            manager.GameOver();
        }
    }
}
