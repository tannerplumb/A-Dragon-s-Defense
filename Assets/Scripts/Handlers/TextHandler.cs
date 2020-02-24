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

    void Start()
    {
        goldText = GoldText;
        livesText = LivesText;
        roundText = RoundText;
        UpdateResourceTexts();
    }

    public static void UpdateResourceTexts()
    {
        goldText.text = Game.Gold.ToString();
        livesText.text = Game.Lives.ToString();
        roundText.text = "Round " + Game.Round.ToString();
    }
}
