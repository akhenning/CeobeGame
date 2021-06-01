using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScript : MonoBehaviour
{
    public static int score;
    public static int highestCombo;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Static script successfully initiated");
        score = 0;
        highestCombo = 0;
    }
}
