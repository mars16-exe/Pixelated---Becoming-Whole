using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : Singleton<GameManager>
{
    public int currentControlState;

    private GameObject Dpad, swipePad;


    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        Dpad = GameObject.Find("dPad").gameObject;
        swipePad = GameObject.Find("swipePad").gameObject;

        if (currentControlState == 0)    //dPad
        {
            Dpad.SetActive(true);
            swipePad.SetActive(false);
        }
        else if (currentControlState == 1)  //swipe
        {
            Dpad.SetActive(false);
            swipePad.SetActive(true);
        }
    }
}
