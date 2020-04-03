using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRadiusCollision : MonoBehaviour
{
    public List<GameObject> objectsInRadius = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fireball") 
            objectsInRadius.Add(col.gameObject);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fireball") 
            objectsInRadius.Remove(col.gameObject);
    }
}
