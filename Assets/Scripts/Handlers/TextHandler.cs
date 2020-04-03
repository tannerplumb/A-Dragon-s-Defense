using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHandler : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    public static TextMeshProUGUI goldText;
    public TextMeshProUGUI LivesText;
    public static TextMeshProUGUI livesText;
    public TextMeshProUGUI RoundText;
    public static TextMeshProUGUI roundText;

    public TextMeshProUGUI GreenDragonCostText;
    public TextMeshProUGUI PurpleDragonCostText;
    public TextMeshProUGUI ForestDragonCostText;
    public TextMeshProUGUI CyanDragonCostText;

    public TextMeshProUGUI Upgrade1CostText;
    public TextMeshProUGUI Upgrade2CostText;
    public TextMeshProUGUI Upgrade3CostText;
    public TextMeshProUGUI Upgrade1DescText;
    public TextMeshProUGUI Upgrade2DescText;
    public TextMeshProUGUI Upgrade3DescText;
    public static TextMeshProUGUI upgrade1CostText;
    public static TextMeshProUGUI upgrade2CostText;
    public static TextMeshProUGUI upgrade3CostText;
    public static TextMeshProUGUI upgrade1DescText;
    public static TextMeshProUGUI upgrade2DescText;
    public static TextMeshProUGUI upgrade3DescText;

    public TextMeshProUGUI LevelText;
    public static TextMeshProUGUI levelText;
    public TextMeshProUGUI KillsText;
    public static TextMeshProUGUI killsText;
    public TextMeshProUGUI KillsToLevelText;
    public static TextMeshProUGUI killsToLevelText;

    public TextMeshProUGUI TooltipText;
    public static TextMeshProUGUI tooltipText;

    public TextMeshProUGUI EndScreenText;
    public static TextMeshProUGUI endScreenText;

    void Start()
    {
        goldText = GoldText;
        livesText = LivesText;
        roundText = RoundText;

        GreenDragonCostText.text = GreenDragonSelector.dragonCost + " gold";
        PurpleDragonCostText.text = PurpleDragonSelector.dragonCost + " gold";
        ForestDragonCostText.text = ForestDragonSelector.dragonCost + " gold";
        CyanDragonCostText.text = CyanDragonSelector.dragonCost + " gold";

        upgrade1CostText = Upgrade1CostText;
        upgrade2CostText = Upgrade2CostText;
        upgrade3CostText = Upgrade3CostText;
        upgrade1DescText = Upgrade1DescText;
        upgrade2DescText = Upgrade2DescText;
        upgrade3DescText = Upgrade3DescText;

        levelText = LevelText;
        killsText = KillsText;
        killsToLevelText = KillsToLevelText;

        tooltipText = TooltipText;

        endScreenText = EndScreenText;

        UpdateResourceTexts();
    }

    public static void UpdateResourceTexts()
    {
        goldText.text = Game.Gold.ToString();
        livesText.text = Game.Lives.ToString();
        roundText.text = "Round " + Game.Round.ToString();
    }
}
