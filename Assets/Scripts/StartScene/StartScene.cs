using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject panel;
    public Dropdown options;

    [Header("GameMANAGER")]
    public GameManager gameManager;

    private void Update()
    {
        if(options != null)
        {
            if (options.value == 0)
            {
                gameManager.currentControlState = 0;
                //button
            }
            else if (options.value == 1)
            {
                gameManager.currentControlState = 1;
                //swipe
            }
        }
        else
        {
            gameManager.currentControlState = 0;
        }

    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void controlOptions()
    {
        if(panel.activeSelf == true)
        {
            panel.SetActive(false);
        }
        else if(panel.activeSelf == false)
        {
            panel.SetActive(true);
            options = panel.GetComponentInChildren<Dropdown>();
        }
    }
}
