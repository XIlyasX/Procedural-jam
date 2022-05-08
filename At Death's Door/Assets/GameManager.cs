using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _camera;

    public GameObject humansParent;
    int humansNumber;

    public float levelDelay;
    [HideInInspector] public float timer;

    GameObject player;

    [HideInInspector] public int kills;

    [Space]
    public float loadNextLevelDelay;

    [Space]
    public GameObject canvas;

    [HideInInspector] public bool isHumanKilled;

    bool finished;
    bool loosed;

    private void Start ()
    {

        timer = levelDelay;

        humansNumber = humansParent.transform.childCount;

        player = FindObjectOfType<PlayerMovement>().gameObject;
        finished = false;
        loosed = false;
    }

    private void Update()
    {
        if(!finished && !player.GetComponent<Possessing>().doesPossess)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameOver();
        }

        if(Input.GetKeyDown(KeyCode.R))
		{
            ReloadLevel();
		}
    }

    public void Shake ()
    {
        _camera.GetComponent<Animator>().SetTrigger("Shake");
    }

    public void HumanKilled()
    {
        isHumanKilled = true;
        humansNumber--;
        kills++;
        if(humansNumber <= 0)
        {
            Win();
        }

        Shake();
    }

    public void Win()
    {
        if (loosed) return;
        Invoke("LoadNextLevel", loadNextLevelDelay);
        canvas.GetComponent<Canvas>().ActiveWinScreen();
        finished = true;
    }

    public void GameOver()
    {
        Invoke("ReloadLevel", loadNextLevelDelay);
        canvas.GetComponent<Canvas>().ActiveDeathScreen();
        Shake();
        loosed = true;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
