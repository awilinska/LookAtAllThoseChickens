using TMPro;
using UnityEngine;

public class FeedingController : MonoBehaviour
{
    public PlayerData playerData;
    public int chickensFeed = 0;
    public int allChickens;
    public TextMeshProUGUI feedDisplay;
    public TextMeshProUGUI allDisplay;

    void Update() {
        allChickens = playerData.playerChickens + playerData.playerChicks;
        allDisplay.text = allChickens.ToString();

        feedDisplay.text = chickensFeed.ToString();
    }

    public void FeedBeet() {
        if (chickensFeed < allChickens) {
            if (playerData.beet >= 1) {
                playerData.beet -= 1;
                chickensFeed += 1;
            }
        }
    }
    public void FeedDaikon() {
        if (chickensFeed < allChickens) {
            if (playerData.daikon >= 1) {
                playerData.daikon -= 1;
                chickensFeed += 1;
            }
        }
    }
    public void FeedLettuce() {
        if (chickensFeed < allChickens) {
            if (playerData.lettuce >= 1) {
                playerData.lettuce -= 1;
                chickensFeed += 1;
            }
        }
    }
    public void FeedParsnip() {
        if (chickensFeed < allChickens) {
            if (playerData.parsnip >= 1) {
                playerData.parsnip -= 1;
                chickensFeed += 1;
            }
        }
    }
    public void FeedRadish() {
        if (chickensFeed < allChickens) {
            if (playerData.radish >= 1) {
                playerData.radish -= 1;
                chickensFeed += 1;
            }
        }
    }
    public void FeedTomato() {
        if (chickensFeed < allChickens) {
            if (playerData.tomato >= 1) {
                playerData.tomato -= 1;
                chickensFeed += 1;
            }
        }
    }

}
