using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _camera;

    public void Shake()
    {
        _camera.GetComponent<Animator>().SetTrigger("Shake");
    }
}
