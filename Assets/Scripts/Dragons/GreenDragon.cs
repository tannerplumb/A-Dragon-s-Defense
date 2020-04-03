using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenDragon : MonoBehaviour
{
    [System.NonSerialized] public string Name = "Green Dragon";
    [System.NonSerialized] public int Level = 1;
    [System.NonSerialized] public float AttackSpeed = 1f;
    [System.NonSerialized] public int Kills = 0;
    [System.NonSerialized] public int KillsToLevel = 100;
    [System.NonSerialized] public int Upgrade1Cost = 150;
    [System.NonSerialized] public bool Upgrade1Active = false;
    [System.NonSerialized] public int Upgrade2Cost = 300;
    [System.NonSerialized] public bool Upgrade2Active = false;
    [System.NonSerialized] public int Upgrade3Cost = 450;
    [System.NonSerialized] public bool Upgrade3Active = false;

    private DragonRadiusCollision radiusCol;
    private float attackTimer = 0f;

    public GameObject bullet;

    private void Awake()
    {
        radiusCol = gameObject.transform.GetChild(0).gameObject.GetComponent<DragonRadiusCollision>();
    }

    private void Update()
    {
        // Attack timer should decrease, even if enemy is not in range
        if (attackTimer > 0) attackTimer -= Time.deltaTime * Game.GameSpeed; 

        if (radiusCol.objectsInRadius.Count > 0)
        {
            HandleAttacking();
        }

        if (KillsToLevel <= 0)
        {
            Level += 1;
            KillsToLevel = 100 + (Level * 10);
        }

        if (Game.SelectedDragon == gameObject)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            TextHandler.levelText.text = "Level " + Level;
            TextHandler.killsToLevelText.text = "Kills Till Level: " + KillsToLevel;
            TextHandler.killsText.text = "Kills: " + Kills;

            if (!Upgrade1Active)
            {
                if (Game.Gold < Upgrade1Cost)
                {
                    ButtonHandler.upgrade1Button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    ButtonHandler.upgrade1Button.GetComponent<Button>().interactable = true;
                }
            }
            if (!Upgrade2Active)
            {
                if (Game.Gold < Upgrade2Cost)
                {
                    ButtonHandler.upgrade2Button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    ButtonHandler.upgrade2Button.GetComponent<Button>().interactable = true;
                }
            }
            if (!Upgrade3Active)
            {
                if (Game.Gold < Upgrade3Cost)
                {
                    ButtonHandler.upgrade3Button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    ButtonHandler.upgrade3Button.GetComponent<Button>().interactable = true;
                }
            }
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        UpdateUpgradeWindow();
    }

    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void HandleAttacking()
    {
        if (attackTimer <= 0)
        {
            GameObject fireball = radiusCol.objectsInRadius[0].gameObject;

            foreach(GameObject fb in radiusCol.objectsInRadius)
            {
                if (fb.GetComponent<FireballTimer>().time > fireball.GetComponent<FireballTimer>().time)
                {
                    fireball = fb.gameObject;
                }
            }

            RotateTowards(fireball.transform.position);
            CreateLine(fireball);
            AttackFireball(fireball);

            attackTimer = AttackSpeed;
            if (Upgrade1Active && Upgrade2Active && Upgrade3Active) attackTimer = AttackSpeed * .55f * ((100f - (Level * 2)) / 100f);
            else if (Upgrade1Active && Upgrade2Active) attackTimer = AttackSpeed * .75f * ((100f - (Level * 2)) / 100f);
            else if (Upgrade1Active) attackTimer = AttackSpeed * .9f * ((100f - (Level * 2)) / 100f);
            else attackTimer = AttackSpeed * ((100f - (Level * 2)) / 100f);


            TextHandler.UpdateResourceTexts();
        }
    }

    private void CreateLine(GameObject fireball)
    {
        GameObject go = Instantiate(bullet);
        LineRenderer line = go.gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.material = new Material(Shader.Find("Standard"));
        line.startColor = new Color32(0, 0, 255, 255);
        line.endColor = new Color32(0, 0, 255, 255);
        line.positionCount = 2;
        float distance = 3f;
        line.SetPosition(0, gameObject.transform.position + (gameObject.transform.forward * distance));
        line.SetPosition(1, fireball.transform.position);
    }

    private void AttackFireball(GameObject fireball)
    {
        if (fireball.name.Contains("Red"))
        {
            Destroy(fireball);
            Kills += 1;
            KillsToLevel -= 1;
            Game.Gold += 1;
        }
        else if (fireball.name.Contains("Yellow"))
        {
            GameObject newFireball = Instantiate(fireball.GetComponent<YellowFireball>().FireballToSpawn);
            newFireball.transform.position = fireball.transform.position;
            newFireball.GetComponent<RedFireball>().curPos = fireball.GetComponent<YellowFireball>().curPos;
            newFireball.GetComponent<FireballTimer>().time = fireball.GetComponent<FireballTimer>().time;

            Destroy(fireball);
            Kills += 1;
            KillsToLevel -= 1;
            Game.Gold += 2;
        }
        else if (fireball.name.Contains("Blue"))
        {
            GameObject newFireball = Instantiate(fireball.GetComponent<BlueFireball>().FireballToSpawn);
            newFireball.transform.position = fireball.transform.position;
            newFireball.GetComponent<YellowFireball>().curPos = fireball.GetComponent<BlueFireball>().curPos;
            newFireball.GetComponent<FireballTimer>().time = fireball.GetComponent<FireballTimer>().time;

            Destroy(fireball);
            Kills += 1;
            KillsToLevel -= 1;
            Game.Gold += 3;
        }
        else if (fireball.name.Contains("Green"))
        {
            GameObject newFireball = Instantiate(fireball.GetComponent<GreenFireball>().FireballToSpawn);
            newFireball.transform.position = fireball.transform.position;
            newFireball.GetComponent<BlueFireball>().curPos = fireball.GetComponent<GreenFireball>().curPos;
            newFireball.GetComponent<FireballTimer>().time = fireball.GetComponent<FireballTimer>().time;

            Destroy(fireball);
            Kills += 1;
            KillsToLevel -= 1;
            Game.Gold += 4;
        }
        else if (fireball.name.Contains("White"))
        {
            GameObject newFireball = Instantiate(fireball.GetComponent<WhiteFireball>().FireballToSpawn);
            newFireball.transform.position = fireball.transform.position;
            newFireball.GetComponent<GreenFireball>().curPos = fireball.GetComponent<WhiteFireball>().curPos;
            newFireball.GetComponent<FireballTimer>().time = fireball.GetComponent<FireballTimer>().time;

            Destroy(fireball);
            Kills += 1;
            KillsToLevel -= 1;
            Game.Gold += 5;
        }
        else if (fireball.name.Contains("Purple"))
        {
            fireball.GetComponent<PurpleFireball>().Health -= 1;
        }

        TextHandler.UpdateResourceTexts();
    }

    private void UpdateUpgradeWindow()
    {
        if (Game.SelectedDragon == gameObject)
        {
            // Upgrade Button 1
            if (!Upgrade1Active) ButtonHandler.upgrade1Button.SetActive(true);
            else ButtonHandler.upgrade1Button.SetActive(false);

            // Upgrade 2 Button
            if (Upgrade1Active && !Upgrade2Active) ButtonHandler.upgrade2Button.SetActive(true);
            else ButtonHandler.upgrade2Button.SetActive(false);

            // Upgrade 3 Button
            if (Upgrade1Active && Upgrade2Active && !Upgrade3Active) ButtonHandler.upgrade3Button.SetActive(true);
            else ButtonHandler.upgrade3Button.SetActive(false);

            // Costs
            TextHandler.upgrade1CostText.text = Upgrade1Cost.ToString() + " Gold";
            TextHandler.upgrade2CostText.text = Upgrade2Cost.ToString() + " Gold";
            TextHandler.upgrade3CostText.text = Upgrade3Cost.ToString() + " Gold";

            // Upgrade 1 Text
            if (Upgrade1Active)
            {
                TextHandler.upgrade1CostText.faceColor = new Color32(255, 255, 255, 0);
                TextHandler.upgrade1DescText.faceColor = new Color32(255, 255, 255, 0);
            }
            else
            {
                TextHandler.upgrade1CostText.faceColor = new Color32(255, 255, 255, 255);
                TextHandler.upgrade1DescText.faceColor = new Color32(255, 255, 255, 255);
            }
            
            // Upgrade 2 Text
            if (Upgrade2Active)
            {
                TextHandler.upgrade2CostText.faceColor = new Color32(255, 255, 255, 0);
                TextHandler.upgrade2DescText.faceColor = new Color32(255, 255, 255, 0);
            }
            else
            {
                TextHandler.upgrade2CostText.faceColor = new Color32(255, 255, 255, 255);
                TextHandler.upgrade2DescText.faceColor = new Color32(255, 255, 255, 255);
            }

            // Upgrade 3 Text
            if (Upgrade3Active)
            {
                TextHandler.upgrade3CostText.faceColor = new Color32(255, 255, 255, 0);
                TextHandler.upgrade3DescText.faceColor = new Color32(255, 255, 255, 0);
            }
            else
            {
                TextHandler.upgrade3CostText.faceColor = new Color32(255, 255, 255, 255);
                TextHandler.upgrade3DescText.faceColor = new Color32(255, 255, 255, 255);
            }
        }
    }
}
