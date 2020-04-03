using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTimer : MonoBehaviour
{
    public float time = 0;
    private float multiplier;

    void Start()
    {
        if (gameObject.name.Contains("Red"))
        {
            multiplier = gameObject.GetComponent<RedFireball>().MoveSpeed;
        }
        else if (gameObject.name.Contains("Yellow"))
        {
            multiplier = gameObject.GetComponent<YellowFireball>().MoveSpeed;
        }
        else if (gameObject.name.Contains("Blue"))
        {
            multiplier = gameObject.GetComponent<BlueFireball>().MoveSpeed;
        }
        else if (gameObject.name.Contains("Green"))
        {
            multiplier = gameObject.GetComponent<GreenFireball>().MoveSpeed;
        }
        else if (gameObject.name.Contains("White"))
        {
            multiplier = gameObject.GetComponent<WhiteFireball>().MoveSpeed;
        }
        else if (gameObject.name.Contains("Purple"))
        {
            multiplier = gameObject.GetComponent<PurpleFireball>().MoveSpeed;
        }
    }

    void Update()
    {
        time += Time.deltaTime * multiplier;
    }
}
