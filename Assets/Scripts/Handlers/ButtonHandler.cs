using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    /***************************************************
     * MAIN MENU BUTTONS
     ***************************************************/
    public GameObject Map1Button;
    public GameObject Map2Button;
    public GameObject Map3Button;
    public GameObject PlayButton;

    public void ButtonMap1()
    {
        Game.MapSelection = 1;
        Game.MapCurrentPath = Game.Map1Path;
        PlayButton.GetComponent<Button>().interactable = true;
        UI.UpdateMap();
    }

    public void ButtonMap2()
    {
        Game.MapSelection = 2;
        PlayButton.GetComponent<Button>().interactable = true;
        UI.UpdateMap();
    }

    public void ButtonMap3()
    {
        Game.MapSelection = 3;
        PlayButton.GetComponent<Button>().interactable = true;
        UI.UpdateMap();
    }

    public void ButtonPlay()
    {
        UI.mapSelectPanel.SetActive(false);
        UI.gameInfoPanel.SetActive(true);
        Game.SetDefaults();
    }

    /***************************************************
     * GAME BUTTONS
     ***************************************************/
    public GameObject GamePlayButton;
    public GameObject GamePauseButton;

    public void ButtonGamePlay()
    {
        GamePlayButton.SetActive(false);
        GamePauseButton.SetActive(true);
        Game.IsPaused = false;
    }

    public void ButtonGamePause()
    {
        GamePlayButton.SetActive(true);
        GamePauseButton.SetActive(false);
        Game.IsPaused = true;
    }
}
