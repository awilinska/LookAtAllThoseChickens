using UnityEngine;

public class ChickenShop : MonoBehaviour
{
    public int chickenLimit;
    public int chickens;
    public PlayerData playerData;
    public ChickenSpawner chickenSpawner;

    void Start()
    {
        chickenLimit = PlayerPrefs.GetInt("ChickenLimit", 5);
    }

    public void BuyChicken() {
        chickenLimit = PlayerPrefs.GetInt("ChickenLimit", 5);

        if (playerData.playerChickens + playerData.playerChicks < chickenLimit && playerData.playerCoins >= 30) {
            playerData.playerCoins -= 30;
            playerData.playerChickens += 1;
            chickenSpawner.SpawnChicken();
        }
    }

    public void BuyChick() {
        chickenLimit = PlayerPrefs.GetInt("ChickenLimit", 5);

        if (playerData.playerChickens + playerData.playerChicks < chickenLimit && playerData.playerCoins >= 10) {
            playerData.playerCoins -= 10;
            playerData.playerChicks += 1;
            chickenSpawner.SpawnChick();
        }
    }
}
