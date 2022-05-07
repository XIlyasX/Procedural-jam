using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinToneRandomizer : MonoBehaviour
{
    public SpriteRenderer bodySprite;

    public Color[] colors;
    [HideInInspector] public int randomInt;

    private void Start()
    {
        randomInt = Random.Range(0, colors.Length);
        bodySprite.color = colors[randomInt];
    }
}
