using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementButtons : Singleton<MovementButtons>
{
    public Button up, down, right, left;
    // Start is called before the first frame update
    void Awake()
    {
        up = transform.GetChild(0).GetComponent<Button>();
        down = transform.GetChild(1).GetComponent<Button>();
        right = transform.GetChild(2).GetComponent<Button>();
        left = transform.GetChild(3).GetComponent<Button>();
    }
}
