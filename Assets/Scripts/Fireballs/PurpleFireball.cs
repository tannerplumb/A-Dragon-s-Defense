using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleFireball : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float SlowedSpeed = 2f;
    public static int LivesToRemove = 2000;

    public GameObject FireballToSpawn;
    [System.NonSerialized] public int NumToSpawn = 10;
    [System.NonSerialized] public int Health = 75;

    public int curPos = 0;

    private void Update()
    {
        if (curPos >= Game.EndPositionIndex)
        {
            DestroyThis();
        }
        else
        {
            HandleMovement();
        }

        if (Health <= 0)
        {
            KillThis();
        }
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, Game.MapCurrentPath[curPos + 1], (MoveSpeed * Time.deltaTime * Game.GameSpeed));

        if (transform.position == Game.MapCurrentPath[curPos + 1])
        {
            curPos++;
        }
    }

    private void DestroyThis()
    {
        Game.Lives -= LivesToRemove;
        TextHandler.UpdateResourceTexts();
        if (Game.Lives <= 0)
        {
            Game.Lives = 0;
            Game.StillSpawning = false;
            Game.GameOver = true;
            Game.HandleGameOver();
        }

        Destroy(gameObject);
    }

    private void KillThis()
    {
        for (int i = 0; i < NumToSpawn; i++)
        {
            GameObject fireball = Instantiate(FireballToSpawn);
            fireball.transform.position = transform.position;
            fireball.GetComponent<WhiteFireball>().curPos = curPos;
        }

        Destroy(gameObject);
    }
}
