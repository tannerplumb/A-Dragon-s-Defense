using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFireball : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public int LivesToRemove = 3;
    public GameObject FireballToSpawn;

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
}
