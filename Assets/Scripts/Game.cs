using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**************************************************************************
 * NOTES
 * 
 * STUFF TO DO BEFORE RELEASE
 * - Set MapSelection to 0
 * Editor:
 * - Make sure game boots up with only menu visible until map is clicked
 * ************************************************************************/

public class Game : MonoBehaviour
{
    public static int MapSelection = 0;

    public static bool IsPaused = true;
    public static bool GameOver = false;
    public static float GameSpeed = 1.0f;

    public static int Lives = 100;
    public static int Gold = 500;
    public static int Round = 0;

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

    public static int EndPositionIndex;

    public GameObject FireballRed;

    public List<Round> Rounds;
    public static float SpawnTimer = 0.1f;
    public static bool StillSpawning = true;
    public static int RoundBonus = 150;

    private void Awake()
    {
        CreateRounds();
    }

    public static void SetDefaults()
    {
        Lives = 100;
        Gold = 500;
        Round = 0;

        IsPaused = true;
        GameOver = false;
        StillSpawning = true;
        SpawnTimer = 0.1f;

        EndPositionIndex = MapCurrentPath.Length - 1;
    }

    private void CreateRounds()
    {
        // 2 rounds means Rounds.length = 2
        List<Round> createRounds = new List<Round>
        {
            new Round(1, new List<Spawner>
            {
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 5.0f)
            }),
            new Round(2, new List<Spawner>
            {
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 1.0f),
                new Spawner(FireballRed, 5.0f)
            })
        };

        Rounds = createRounds;
    }

    private void Update()
    {
        if (!GameOver) HandleSpawning();
        HandlePause();
    }

    private void HandleSpawning()
    {
        if (StillSpawning)
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
                SpawnTimer = Rounds[0].Fireballs[0].TimeToNextSpawn;
                Rounds[0].Fireballs.RemoveAt(0);
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
                GameSpeed = 1f;
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
            print("YOU WIN");
        }
        else
        {
            print("YOU LOSE");
        }
    }
}
