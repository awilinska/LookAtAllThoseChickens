using UnityEngine;
using TMPro;
using System;

public class PlayerData : MonoBehaviour
{
    public int playerCoins;
    public int playerWood;
    public int playerChickens;
    public int playerChicks;
    public TextMeshProUGUI coinsDisplay;
    public TextMeshProUGUI woodDisplay;
    public TextMeshProUGUI chickensDisplay;
    public int beet;
    public int daikon;
    public int lettuce;
    public int parsnip;
    public int radish;
    public int tomato;

    public TextMeshProUGUI beetDisplay;
    public TextMeshProUGUI daikonDisplay;
    public TextMeshProUGUI lettuceDisplay;
    public TextMeshProUGUI parsnipDisplay;
    public TextMeshProUGUI radishDisplay;
    public TextMeshProUGUI tomatoDisplay;


    void Start()
    {
        playerCoins = PlayerPrefs.GetInt("playerCoins", 30);
        playerWood = PlayerPrefs.GetInt("playerWood", 0);
        playerChickens = PlayerPrefs.GetInt("playerChickens", 0);
        playerChicks = PlayerPrefs.GetInt("playerChicks", 0);

        beet = PlayerPrefs.GetInt("beet", 0);
        daikon = PlayerPrefs.GetInt("daikon", 0);
        lettuce = PlayerPrefs.GetInt("lettuce", 0);
        parsnip = PlayerPrefs.GetInt("parsnip", 0);
        radish = PlayerPrefs.GetInt("radish", 0);
        tomato = PlayerPrefs.GetInt("tomato", 0);
    }

    void Update()
    {
        string tagToCount = "Chicken";
        GameObject[] chickenObjects = GameObject.FindGameObjectsWithTag(tagToCount);
        int chickenCount = chickenObjects.Length;

        PlayerPrefs.SetInt("playerCoins", playerCoins);
        PlayerPrefs.SetInt("playerWood", playerWood);
        PlayerPrefs.SetInt("playerChickens", Math.Abs(playerChickens));
        PlayerPrefs.SetInt("playerChicks", Math.Abs(playerChicks));

        PlayerPrefs.SetInt("beet", beet);
        PlayerPrefs.SetInt("daikon", daikon);
        PlayerPrefs.SetInt("lettuce", lettuce);
        PlayerPrefs.SetInt("parsnip", parsnip);
        PlayerPrefs.SetInt("radish", radish);
        PlayerPrefs.SetInt("tomato", tomato);

        coinsDisplay.text = (playerCoins.ToString());
        woodDisplay.text = (playerWood.ToString());
        chickensDisplay.text = ((chickenCount).ToString());
        beetDisplay.text = (beet.ToString());
        daikonDisplay.text = (daikon.ToString());
        lettuceDisplay.text = (lettuce.ToString());
        parsnipDisplay.text = (parsnip.ToString());
        radishDisplay.text = (radish.ToString());
        tomatoDisplay.text = (tomato.ToString());
    }

    public void AddVegetableToInventory(string vegetableType)
    {
        switch (vegetableType)
        {
            case "Beet":
                beet++;
                break;
            case "Daikon":
                daikon++;
                break;
            case "Lettuce":
                lettuce++;
                break;
            case "Parsnip":
                parsnip++;
                break;
            case "Radish":
                radish++;
                break;
            case "Tomato":
                tomato++;
                break;
        }
    }
}
