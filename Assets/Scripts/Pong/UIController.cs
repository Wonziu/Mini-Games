using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameController myGameController;
    public GameObject UIGame;
    public GameObject UIWin;
    public Text PlayerName;

    public void OnButtonScoreClick(int score)
    {
        myGameController.MaxPoints = score;
    }

    public void OnButtonPowerUpClick(int c)
    {
        myGameController.PowerUpChance = c;
    }

    public void OnButtonStartClick()
    {
        UIGame.SetActive(false);
        myGameController.StartGame();
    }
    
    public void GameWin(string name)
    {
        UIWin.SetActive(true);
        PlayerName.text = name + " Won!";
    }

    public void ResetGame()
    {
        myGameController.ResetGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}