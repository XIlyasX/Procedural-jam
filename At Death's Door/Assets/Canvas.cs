using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvas : MonoBehaviour
{
    public TextMeshProUGUI kills;
    public TextMeshProUGUI humanNumber;

    public TextMeshProUGUI timer;

    public GameObject winScreen;
    public GameObject deathScreen;

    GameManager manager;

    private void Start()
    {
        winScreen.SetActive(false);
        deathScreen.SetActive(false);

        winScreen.GetComponent<Animator>().SetTrigger("Activate");
        manager = FindObjectOfType<GameManager>();

        kills.text = 0.ToString();
        humanNumber.text = manager.humansParent.transform.childCount.ToString();
    }

    private void Update()
    {
        kills.text = manager.kills.ToString();



        timer.text = Mathf.Clamp(manager.timer, 0, manager.timer).ToString("0");
    }

    public void ActiveWinScreen()
    {
        winScreen.SetActive(true);
        winScreen.GetComponent<Animator>().SetTrigger("Activate");
    }

    public void ActiveDeathScreen()
    {
        deathScreen.SetActive(true);
        deathScreen.GetComponent<Animator>().SetTrigger("Activate");
    }
}
