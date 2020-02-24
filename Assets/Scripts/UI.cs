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

    public Sprite Map1;
    public Sprite Map2;
    public Sprite Map3;
    public static Sprite map1;
    public static Sprite map2;
    public static Sprite map3;

    void Awake()
    {
        mapSelectPanel = MapSelectPanel;
        mapBackground = MapBackground;
        gameInfoPanel = GameInfoPanel;
        map1 = Map1;
        map2 = Map2;
        map3 = Map3;

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
                break;
            case 3:
                //map.color = Color.cyan;
                break;
            default:
                //map.color = Color.grey;
                break;
        }
    }
}
