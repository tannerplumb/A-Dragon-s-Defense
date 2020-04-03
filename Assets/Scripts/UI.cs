using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject MapSelectPanel;
    public static GameObject mapSelectPanel;

    public GameObject MapBackground;
    public static GameObject mapBackground;

    public GameObject GameInfoPanel;
    public static GameObject gameInfoPanel;

    public GameObject DragonSelectPanel;
    public static GameObject dragonSelectPanel;

    public GameObject DragonUpgradePanel;
    public static GameObject dragonUpgradePanel;

    public GameObject TooltipPanel;
    public static GameObject tooltipPanel;

    public Sprite Map1;
    public Sprite Map2;
    public Sprite Map3;
    public static Sprite map1;
    public static Sprite map2;
    public static Sprite map3;

    public GameObject EndScreenPanel;
    public static GameObject endScreenPanel;

    void Awake()
    {
        mapSelectPanel = MapSelectPanel;
        mapBackground = MapBackground;
        gameInfoPanel = GameInfoPanel;
        dragonSelectPanel = DragonSelectPanel;
        dragonUpgradePanel = DragonUpgradePanel;
        tooltipPanel = TooltipPanel;
        map1 = Map1;
        map2 = Map2;
        map3 = Map3;
        endScreenPanel = EndScreenPanel;

        UpdateMap();
    }

    public static void UpdateMap()
    {
        Image map = mapBackground.GetComponent<Image>();
        switch (Game.MapSelection)
        {
            case 1:
                //map.color = Color.green;
                map.sprite = map1;
                break;
            case 2:
                //map.color = Color.magenta;
                map.sprite = map2;
                break;
            case 3:
                //map.color = Color.cyan;
                map.sprite = map3;
                break;
            default:
                //map.color = Color.grey;
                break;
        }
    }

    public static void CloseUpgradeWindow()
    {
        dragonSelectPanel.SetActive(true);
        dragonUpgradePanel.SetActive(false);
    }

    public static void OpenUpgradeWindow()
    {
        dragonSelectPanel.SetActive(false);
        dragonUpgradePanel.SetActive(true);
    }

    public static void OpenEndScreen()
    {
        endScreenPanel.SetActive(true);
    }

    public static void CloseEndScreen()
    {
        endScreenPanel.SetActive(false);
    }

    public static void OpenTooltip()
    {
        tooltipPanel.SetActive(true);
    }

    public static void CloseTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
