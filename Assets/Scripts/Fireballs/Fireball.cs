using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    FIRE,
    ICE
}

public class Fireball : MonoBehaviour
{
    public float MoveSpeed { get; set; }
    public int LivesToRemove { get; set; }
    public Element Type { get; set; }

    private int curPos = 0;

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
