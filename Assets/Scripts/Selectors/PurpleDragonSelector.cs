using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Tower Radius should turn Red if the tower is over a spot where it can't be placed (i.e. on another tower, on track, or off screen)


public class PurpleDragonSelector : MonoBehaviour
{
    public GameObject dragonToCreate;
    public GameObject backgroundRadius;

    public static int dragonCost = 510;
    private string description = "Uses acid to slow fireballs that are hit.";

    private Vector3 SpritePos;
    private bool Dragging = false;

    private Vector3 mousePos;

    private bool canPlace = true;
    private Color placeableColor = new Color(100, 100, 100, .5f);
    private Color notPlaceableColor = new Color(255, 0, 0, .7f);

    private List<GameObject> collisions = new List<GameObject>();

    private void Start()
    {
        SpritePos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        mousePos = Input.mousePosition;

        if (Dragging)
        {
            // Handle Movement of Icon with Mouse
            transform.localPosition = new Vector3(mousePos.x - 263f, mousePos.y - 76f, -6912f);
        }

        if (collisions.Count > 0)
        {
            canPlace = false;
        }
        else
        {
            canPlace = true;
        }

        if (!canPlace)
        {
            backgroundRadius.GetComponent<SpriteRenderer>().color = notPlaceableColor;
        }
        else
        {
            backgroundRadius.GetComponent<SpriteRenderer>().color = placeableColor;
        }

        if (Game.Gold > dragonCost)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .2f);
        }
    }

    private void OnMouseDown()
    {
        if (Game.Gold > dragonCost)
        {
            Dragging = true;
            backgroundRadius.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    private void OnMouseUp()
    {
        Dragging = false;
        transform.position = SpritePos;
        backgroundRadius.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = false;

        if (canPlace)
        {
            // if can afford
            GameObject newDragon = Instantiate(dragonToCreate);
            Vector3 curMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newDragon.transform.localPosition = new Vector3(curMousePos.x, curMousePos.y, 1);
            Game.Gold -= dragonCost;
            TextHandler.UpdateResourceTexts();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        collisions.Add(col.gameObject);
        //Debug.Log(col.gameObject.name + " added.");
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        collisions.Remove(col.gameObject);
        //Debug.Log(col.gameObject.name + " removed.");
    }

    private void OnMouseOver()
    {
        TextHandler.tooltipText.text = description;
        UI.OpenTooltip();
    }
    private void OnMouseExit()
    {
        UI.CloseTooltip();
    }
}