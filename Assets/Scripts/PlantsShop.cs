using UnityEngine;

public class PlantsShop : MonoBehaviour
{
    public PlayerData playerData;
    public GameObjectCycle cycle;
    
    public void BuyField() {
        if (playerData.playerCoins >= 200) {
            playerData.playerCoins -= 200;
            cycle.CycleNextGameObject();
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void BuyParsnip() {
        if (playerData.playerCoins >= 30) {
            playerData.playerCoins -= 30;
            playerData.parsnip += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellParsnip() {
        if (playerData.parsnip >= 1) {
            playerData.playerCoins += 10;
            playerData.parsnip -= 1;
        }
        else 
        {
            Debug.Log("Not enough parsnip");
        }
    }

    public void BuyDaikon() {
        if (playerData.playerCoins >= 40) {
            playerData.playerCoins -= 40;
            playerData.daikon += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellDaikon() {
        if (playerData.daikon >= 1) {
            playerData.playerCoins += 20;
            playerData.daikon -= 1;
        }
        else 
        {
            Debug.Log("Not enough daikon");
        }
    }

    public void BuyLettuce() {
        if (playerData.playerCoins >= 50) {
            playerData.playerCoins -= 50;
            playerData.lettuce += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellLettuce() {
        if (playerData.lettuce >= 1) {
            playerData.playerCoins += 30;
            playerData.lettuce -= 1;
        }
        else 
        {
            Debug.Log("Not enough lettuce");
        }
    }
        
    public void BuyBeet() {
        if (playerData.playerCoins >= 60) {
            playerData.playerCoins -= 60;
            playerData.beet += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellBeet() {
        if (playerData.beet >= 1) {
            playerData.playerCoins += 45;
            playerData.beet -= 1;
        }
        else 
        {
            Debug.Log("Not enough beet");
        }
    }

    public void BuyRadish() {
        if (playerData.playerCoins >= 70) {
            playerData.playerCoins -= 70;
            playerData.radish += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellRadish() {
        if (playerData.radish >= 1) {
            playerData.playerCoins += 60;
            playerData.radish -= 1;
        }
        else 
        {
            Debug.Log("Not enough radish");
        }
    }

    public void BuyTomato() {
        if (playerData.playerCoins >= 80) {
            playerData.playerCoins -= 80;
            playerData.tomato += 1;
        }
        else 
        {
            Debug.Log("Not enough coins");
        }
    }

    public void SellTomato() {
        if (playerData.tomato >= 1) {
            playerData.playerCoins += 75;
            playerData.tomato -= 1;
        }
        else 
        {
            Debug.Log("Not enough tomato");
        }
    }
}
