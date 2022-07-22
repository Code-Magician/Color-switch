using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color randColor = new Color((float)Random.Range(0, 255), (float)Random.Range(0, 255), (float)Random.Range(0, 255), 255);
        GetComponent<SpriteRenderer>().color = randColor;
    }
}
