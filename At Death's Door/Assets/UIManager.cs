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

    public GameObject tutorial1, tutorial2;

    public GameObject player;

    public TextMeshProUGUI possessTimer;

    public GameManager manager;

    // Start is called before the first frame update
    void Awake()
    {
        if(!Stats.hasDiedOnce)
		{
            tutorial1.SetActive(true);
            
		}
		else
		{
            tutorial1.SetActive(false);
            tutorial2.SetActive(true);
		}
        manager = FindObjectOfType<GameManager>();
        //player = FindObjectOfType<PlayerMovement>().gameObject;
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
