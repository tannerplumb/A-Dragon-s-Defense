using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = .05f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    /*
    public GameObject firedFrom;
    public GameObject goingToward;

    void Update()
    {
        if (goingToward == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = firedFrom.transform.position;
            transform.rotation = firedFrom.transform.rotation;
            transform.position = Vector3.MoveTowards(transform.position, goingToward.transform.position, Time.deltaTime * 1f);
        }
    }
    */
}
