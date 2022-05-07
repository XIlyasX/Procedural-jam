using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public int goalValue;

    public TextMeshProUGUI score;
    public TextMeshProUGUI goal;

    public TextMeshProUGUI possessTimer;

    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        goal.text = goalValue.ToString();
        possessTimer.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Stats.humansKilled.ToString();
        possessTimer.text = manager.player.GetComponent<Possessing>().timer.ToString("0");
    }
}
