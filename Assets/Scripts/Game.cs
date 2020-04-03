using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    // Game Variables
    public static bool IsPaused = true;
    public static bool GameOver = false;
    public static bool IsFastForward = false;
    public static float GameSpeed = 1.0f;
    public static float NormalSpeed = 1.0f;
    public static float FastForwardSpeed = 3.0f;

    public static int MapSelection = 0;
    public static GameObject SelectedDragon = null;

    // Player Variables
    public static int Lives;
    public static int Gold;
    public static int Round;

    // Map Variables
    public static Vector3[] MapCurrentPath;
    public static Vector3[] Map1Path =
    {
        new Vector3(-6.77f, 4.33f),
        new Vector3(-2.25f, 4.33f),
        new Vector3(-2.25f, 0.8f),
        new Vector3(-5.19f, 0.8f),
        new Vector3(-5.19f, -2.65f),
        new Vector3(5.09f, -2.65f),
        new Vector3(5.09f, 2.86f),
        new Vector3(1.61f, 2.86f),
        new Vector3(1.61f, -0.23f),
        new Vector3(-0.14f, -0.23f),
        new Vector3(-0.14f, 5.13f)
    };
    public static Vector3[] Map2Path =
    {
        new Vector3(-6.9f, 2.9f),
        new Vector3(-5.5f, 2.8f),
        new Vector3(-5.3f, 2.1f),
        new Vector3(-5.0f, 1.7f),
        new Vector3(-4.4f, 1.6f),
        new Vector3(-3.9f, 1.7f),
        new Vector3(-3.5f, 2.0f),
        new Vector3(-3.1f, 2.4f),
        new Vector3(-3.1f, 3.1f),
        new Vector3(-3.3f, 3.6f),
        new Vector3(-3.8f, 3.9f),
        new Vector3(-4.5f, 3.9f),
        new Vector3(-5.0f, 3.6f),
        new Vector3(-5.3f, 3.3f),
        new Vector3(-5.4f, 2.8f),
        new Vector3(-5.3f, 2.1f),
        new Vector3(-4.9f, 1.8f),
        new Vector3(-4.6f, 1.4f),
        new Vector3(-4.6f, 0.3f),
        new Vector3(-3.5f, -1.0f),
        new Vector3(-2.8f, -1.3f),
        new Vector3(-1.6f, -1.2f),
        new Vector3(-0.8f, -0.6f),
        new Vector3(-0.4f, 0.0f),
        new Vector3(0.5f, 0.0f),
        new Vector3(1.0f, 0.6f),
        new Vector3(1.2f, 1.5f),
        new Vector3(1.0f, 2.1f),
        new Vector3(0.7f, 2.5f),
        new Vector3(0.0f, 2.6f),
        new Vector3(-0.7f, 2.5f),
        new Vector3(-1.2f, 2.0f),
        new Vector3(-1.3f, 1.5f),
        new Vector3(-1.3f, 0.8f),
        new Vector3(-0.9f, 0.2f),
        new Vector3(-0.1f, -0.1f),
        new Vector3(0.8f, 0.2f),
        new Vector3(1.2f, 0.9f),
        new Vector3(1.2f, 1.7f),
        new Vector3(1.0f, 2.3f),
        new Vector3(1.2f, 2.7f),
        new Vector3(2.2f, 2.8f),
        new Vector3(3.1f, 2.5f),
        new Vector3(3.5f, 2.1f),
        new Vector3(3.8f, 1.6f),
        new Vector3(4.0f, 0.9f),
        new Vector3(4.1f, -0.3f),
        new Vector3(3.5f, -0.5f),
        new Vector3(3.2f, -0.8f),
        new Vector3(3.2f, -1.3f),
        new Vector3(3.3f, -1.8f),
        new Vector3(3.8f, -2.1f),
        new Vector3(4.5f, -2.1f),
        new Vector3(5.0f, -1.8f),
        new Vector3(5.1f, -1.4f),
        new Vector3(6.8f, -1.3f)
    };
    public static Vector3[] Map3Path = 
    {
        new Vector3(-6.9f, 1.2f),
        new Vector3(-0.4f, -0.1f),
        new Vector3(0.1f, -2.0f),
        new Vector3(-2.4f, -1.9f),
        new Vector3(-3.7f, -0.7f),
        new Vector3(-0.7f, 3.5f),
        new Vector3(3.1f, -0.3f),
        new Vector3(4.1f, 2.2f),
        new Vector3(2.4f, 4.0f),
        new Vector3(6.0f, 3.6f),
        new Vector3(6.0f, -1.1f),
        new Vector3(5.1f, -3.3f),
    };
    public GameObject Map1Bounds;
    public static GameObject map1Bounds;
    public GameObject Map2Bounds;
    public static GameObject map2Bounds;
    public GameObject Map3Bounds;
    public static GameObject map3Bounds;

    public static int EndPositionIndex;

    // Fireball Variables
    public GameObject FireballRed;
    public GameObject FireballYellow;
    public GameObject FireballBlue;
    public GameObject FireballGreen;
    public GameObject FireballWhite;
    public GameObject FireballPurple;

    // Round Variables
    public List<Round> Rounds;
    public static float SpawnTimer = 0.1f;
    public static bool StillSpawning = true;
    public static int RoundBonus = 150;

    private void Awake()
    {
        CreateRounds();
        map1Bounds = Map1Bounds;
        map2Bounds = Map2Bounds;
        map3Bounds = Map3Bounds;
    }

    private void Start()
    {
        //if (DebugMode) { DebugStart(); }
    }

    public static void SetDefaults()
    {
        Lives = 100;
        Gold = 650;
        Round = 0;

        IsPaused = true;
        GameOver = false;
        StillSpawning = true;
        SpawnTimer = 0.1f;

        // Set Bounds
        if (MapSelection == 1)
        {
            map1Bounds.SetActive(true);
            map2Bounds.SetActive(false);
            map3Bounds.SetActive(false);
        }
        else if (MapSelection == 2)
        {
            map1Bounds.SetActive(false);
            map2Bounds.SetActive(true);
            map3Bounds.SetActive(false);
        }
        else if (MapSelection == 3)
        {
            map1Bounds.SetActive(false);
            map2Bounds.SetActive(false);
            map3Bounds.SetActive(true);
        }

        EndPositionIndex = MapCurrentPath.Length - 1;

        TextHandler.UpdateResourceTexts();
    }

    private void CreateRounds()
    {
        List<Round> createRounds = new List<Round>
        {
            new Round(1, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f)
            }),
            new Round(2, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f)
            }),
            new Round(3, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f)
            }),
            new Round(4, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f)
            }),
            new Round(5, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f)
            }),
            new Round(6, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f)
            }),
            new Round(7, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f)
            }),
            new Round(8, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f)
            }),
            new Round(9, new List<Spawner>
            {
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f)
            }),
            new Round(10, new List<Spawner>
            {
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f)
            }),
            new Round(11, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f)
            }),
            new Round(12, new List<Spawner>
            {
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f)
            }),
            new Round(13, new List<Spawner>
            {
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f)
            }),
            new Round(14, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f)
            }),
            new Round(15, new List<Spawner>
            {
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballRed, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballYellow, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f)
            }),
            new Round(16, new List<Spawner>
            {
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f)
            }),
            new Round(17, new List<Spawner>
            {
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f)
            }),
            new Round(18, new List<Spawner>
            {
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f)
            }),
            new Round(19, new List<Spawner>
            {
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballBlue, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballGreen, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f),
                new Spawner(FireballWhite, 0.75f)
            }),
            new Round(20, new List<Spawner>
            {
                new Spawner(FireballPurple, 10f),
                new Spawner(FireballPurple, 10f),
                new Spawner(FireballPurple, 10f),
                new Spawner(FireballPurple, 10f),
                new Spawner(FireballPurple, 10f)
            })
        };

        Rounds = createRounds;
    }

    private void Update()
    {
        if (!GameOver && !IsPaused) HandleSpawning();
        HandlePause();
        HandleClicking();
    }

    private void HandleSpawning()
    {
        if (StillSpawning && !IsPaused)
        {
            SpawnTimer -= Time.deltaTime * GameSpeed;
        }
        else
        {
            GameObject[] ExistingFireballs = GameObject.FindGameObjectsWithTag("Fireball");
            if (ExistingFireballs.Length < 1)
            {
                GameOver = true;
                HandleGameOver();
            }
        }

        if (SpawnTimer <= 0.0f) SpawnNextFireball();
    }

    private void SpawnNextFireball()
    {
        if (Round == 0)
        {
            // spawn first and setup things
            GameObject go = Instantiate(Rounds[0].Fireballs[0].Fireball);
            go.transform.position = MapCurrentPath[0];
            SpawnTimer = Rounds[0].Fireballs[0].TimeToNextSpawn;
            Rounds[0].Fireballs.RemoveAt(0);
            Round = 1;
            TextHandler.UpdateResourceTexts();
        }
        else
        {
            // continue on
            if (Rounds[0].Fireballs.Count > 0)
            {
                GameObject go = Instantiate(Rounds[0].Fireballs[0].Fireball);
                go.transform.position = MapCurrentPath[0];
                SpawnTimer = Rounds[0].Fireballs[0].TimeToNextSpawn;
                Rounds[0].Fireballs.RemoveAt(0);
                TextHandler.UpdateResourceTexts();
            }
            else
            {
                Rounds.RemoveAt(0);
                if (Rounds.Count > 0)
                {
                    Round = Rounds[0].RoundNumber;
                    Gold += RoundBonus;
                    TextHandler.UpdateResourceTexts();
                }
                else
                {
                    StillSpawning = false;
                    SpawnTimer = 99999f;
                    TextHandler.UpdateResourceTexts();
                }
            }
        }
    }

    private void HandlePause()
    {
        if (!GameOver)
        {
            if (IsPaused)
            {
                GameSpeed = 0f;
            }
            else
            {
                if (!IsFastForward)
                {
                    GameSpeed = NormalSpeed;
                }
                else
                {
                    GameSpeed = FastForwardSpeed;
                }
            }
        }
        else
        {
            GameSpeed = 0f;
        }
    }

    public static void HandleGameOver()
    {
        if (Lives > 0)
        {
            TextHandler.endScreenText.text = "You Win";
        }
        else
        {
            TextHandler.endScreenText.text = "You Lose";
        }
        UI.OpenEndScreen();
    }

    private void HandleClicking()
    {
        if (UI.mapSelectPanel.activeSelf == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonDown(0))
            {
                string dname = hit.collider.gameObject.name;
                //print(dname);
                if (dname.Contains("Dragon(Clone)"))
                {
                    SelectedDragon = hit.collider.gameObject;
                    UI.OpenUpgradeWindow();
                }
                else if (dname.Contains("Map") || dname.Contains("Radius"))
                {
                    SelectedDragon = null;
                    UI.CloseUpgradeWindow();
                }
            }
        }
    }






    public static bool DebugMode = false;

    private void DebugStart()
    {
        //MapSelection = 1;
        //MapCurrentPath = Map1Path;
        //UI.UpdateMap();
        //SetDefaults();
    }

    private void OnGUI()
    {
        if (DebugMode)
        {
            GUI.Label(new Rect(0, 0, 500, 200), Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
        }
    }
}
