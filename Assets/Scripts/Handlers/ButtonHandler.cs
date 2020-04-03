using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        Game.MapCurrentPath = Game.Map2Path;
        PlayButton.GetComponent<Button>().interactable = true;
        UI.UpdateMap();
    }

    public void ButtonMap3()
    {
        Game.MapSelection = 3;
        Game.MapCurrentPath = Game.Map3Path;
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
    public GameObject GameFastForwardButton;

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

    public void ButtonFastForward()
    {
        Game.IsFastForward = !Game.IsFastForward;
        SwapThisButtonDisplay();
    }

    private void SwapThisButtonDisplay()
    {
        if (Game.IsFastForward)
        {
            Color newColor = new Color32(60, 255, 0, 255);
            GameFastForwardButton.GetComponent<Image>().color = newColor;
            GameFastForwardButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "<<";
        }
        else
        {
            Color newColor = new Color32(255, 255, 255, 255);
            GameFastForwardButton.GetComponent<Image>().color = newColor;
            GameFastForwardButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = ">>";
        }
    }

    /***************************************************
     * GAME BUTTONS
     ***************************************************/
    public GameObject Upgrade1Button;
    public static GameObject upgrade1Button;
    public GameObject Upgrade2Button;
    public static GameObject upgrade2Button;
    public GameObject Upgrade3Button;
    public static GameObject upgrade3Button;

    public void ButtonUpgrade1()
    {
        GameObject dragon = Game.SelectedDragon.gameObject;
        if (dragon.name.Contains("Green"))
        {
            GreenDragon info = dragon.GetComponent<GreenDragon>();
            if (Game.Gold >= info.Upgrade1Cost)
            {
                Game.Gold -= info.Upgrade1Cost;
                info.Upgrade1Active = true;
            }
        }
        else if (dragon.name.Contains("Purple"))
        {
            PurpleDragon info = dragon.GetComponent<PurpleDragon>();
            if (Game.Gold >= info.Upgrade1Cost)
            {
                Game.Gold -= info.Upgrade1Cost;
                info.Upgrade1Active = true;
            }
        }
        else if (dragon.name.Contains("Forest"))
        {
            ForestDragon info = dragon.GetComponent<ForestDragon>();
            if (Game.Gold >= info.Upgrade1Cost)
            {
                Game.Gold -= info.Upgrade1Cost;
                info.Upgrade1Active = true;
            }
        }
        else if (dragon.name.Contains("Cyan"))
        {
            CyanDragon info = dragon.GetComponent<CyanDragon>();
            if (Game.Gold >= info.Upgrade1Cost)
            {
                Game.Gold -= info.Upgrade1Cost;
                info.Upgrade1Active = true;
            }
        }
        TextHandler.UpdateResourceTexts();
    }

    public void ButtonUpgrade2()
    {
        GameObject dragon = Game.SelectedDragon.gameObject;
        if (dragon.name.Contains("Green"))
        {
            GreenDragon info = dragon.GetComponent<GreenDragon>();
            if (Game.Gold >= info.Upgrade2Cost)
            {
                Game.Gold -= info.Upgrade2Cost;
                info.Upgrade2Active = true;
            }
        }
        else if (dragon.name.Contains("Purple"))
        {
            PurpleDragon info = dragon.GetComponent<PurpleDragon>();
            if (Game.Gold >= info.Upgrade2Cost)
            {
                Game.Gold -= info.Upgrade2Cost;
                info.Upgrade2Active = true;
            }
        }
        else if (dragon.name.Contains("Forest"))
        {
            ForestDragon info = dragon.GetComponent<ForestDragon>();
            if (Game.Gold >= info.Upgrade2Cost)
            {
                Game.Gold -= info.Upgrade2Cost;
                info.Upgrade2Active = true;
            }
        }
        else if (dragon.name.Contains("Cyan"))
        {
            CyanDragon info = dragon.GetComponent<CyanDragon>();
            if (Game.Gold >= info.Upgrade2Cost)
            {
                Game.Gold -= info.Upgrade2Cost;
                info.Upgrade2Active = true;
            }
        }
        TextHandler.UpdateResourceTexts();
    }

    public void ButtonUpgrade3()
    {
        GameObject dragon = Game.SelectedDragon.gameObject;
        if (dragon.name.Contains("Green"))
        {
            GreenDragon info = dragon.GetComponent<GreenDragon>();
            if (Game.Gold >= info.Upgrade3Cost)
            {
                Game.Gold -= info.Upgrade3Cost;
                info.Upgrade3Active = true;
            }
        }
        else if (dragon.name.Contains("Purple"))
        {
            PurpleDragon info = dragon.GetComponent<PurpleDragon>();
            if (Game.Gold >= info.Upgrade3Cost)
            {
                Game.Gold -= info.Upgrade3Cost;
                info.Upgrade3Active = true;
            }
        }
        else if (dragon.name.Contains("Forest"))
        {
            ForestDragon info = dragon.GetComponent<ForestDragon>();
            if (Game.Gold >= info.Upgrade3Cost)
            {
                Game.Gold -= info.Upgrade3Cost;
                info.Upgrade3Active = true;
            }
        }
        else if (dragon.name.Contains("Cyan"))
        {
            CyanDragon info = dragon.GetComponent<CyanDragon>();
            if (Game.Gold >= info.Upgrade3Cost)
            {
                Game.Gold -= info.Upgrade3Cost;
                info.Upgrade3Active = true;
            }
        }
        TextHandler.UpdateResourceTexts();
    }

    /***************************************************
     * END BUTTONS
     ***************************************************/
    public void ButtonPlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    /***************************************************
     * SET GOs
     ***************************************************/
    private void Start()
    {
        upgrade1Button = Upgrade1Button;
        upgrade2Button = Upgrade2Button;
        upgrade3Button = Upgrade3Button;
    }
}
