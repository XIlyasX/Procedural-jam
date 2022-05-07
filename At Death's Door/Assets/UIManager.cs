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

    // Start is called before the first frame update
    void Start()
    {
        goal.text = goalValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Stats.humansKilled.ToString();
    }
}
