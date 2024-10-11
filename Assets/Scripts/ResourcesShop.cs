using UnityEngine;

public class ResourcesShop : MonoBehaviour
{
    public PlayerData playerData;

    public void BuyWood() {
        if (playerData.playerCoins >= 5) {
            playerData.playerCoins -= 5;
            playerData.playerWood += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellWood() {
        if (playerData.playerWood >= 1) {
            playerData.playerCoins += 1;
            playerData.playerWood -= 1;
        }
        else 
        {
            Debug.Log("Not enough wood");
        }
    }
}
