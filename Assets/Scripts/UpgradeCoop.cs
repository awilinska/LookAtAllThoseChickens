using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UpgradeCoop : MonoBehaviour
{
    public List<GameObject> gameObjectsToCycle;
    public List<int> upgradePrices;
    public List<int> woodRequirements;
    private int currentIndex = 0;

    private const string unlockedObjectsKey = "UnlockedObject";
    public PlayerData playerData;
    public TextMeshProUGUI upgradePriceText;
    public TextMeshProUGUI woodRequirementText;

    void Start()
    {

        bool anyActive = false;

        string unlockedObjects = PlayerPrefs.GetString(unlockedObjectsKey);
        if (!string.IsNullOrEmpty(unlockedObjects))
        {
            string[] unlockedObjectIndices = unlockedObjects.Split(',');
            foreach (string indexStr in unlockedObjectIndices)
            {
                int index;
                if (int.TryParse(indexStr, out index) && index >= 0 && index < gameObjectsToCycle.Count)
                {
                    gameObjectsToCycle[index].SetActive(true);
                    if (index != 0)
                    {
                        anyActive = true;
                    }
                }
            }
        }

        if (!anyActive)
        {
            gameObjectsToCycle[0].SetActive(true);
        }
    }
    void Update() {
        upgradePriceText.text = upgradePrices[currentIndex].ToString() + " coins";
        woodRequirementText.text = woodRequirements[currentIndex].ToString() + " wood";
    }

    public void Upgrade()
    {
        if (currentIndex < upgradePrices.Count && 
        playerData.playerCoins >= upgradePrices[currentIndex] &&
            playerData.playerWood >= woodRequirements[currentIndex])
        {
            playerData.playerCoins -= upgradePrices[currentIndex];
            playerData.playerWood -= woodRequirements[currentIndex];
            
            gameObjectsToCycle[currentIndex].SetActive(false);

            currentIndex = (currentIndex + 1) % gameObjectsToCycle.Count;
            Debug.Log("Coop upgraded");

            SetGameObjectActive(currentIndex);

            SaveUnlockedObjects();
        }
        else {
            Debug.Log("Not enough");
        }
    }

    private void SetGameObjectActive(int index)
    {
        gameObjectsToCycle[index].SetActive(true);
    }

    private void SaveUnlockedObjects()
    {
        string unlockedObjects = "";
        for (int i = 0; i < gameObjectsToCycle.Count; i++)
        {
            if (gameObjectsToCycle[i].activeSelf)
            {
                if (!string.IsNullOrEmpty(unlockedObjects))
                {
                    unlockedObjects += ",";
                }
                unlockedObjects += i.ToString();
            }
        }

        PlayerPrefs.SetString(unlockedObjectsKey, unlockedObjects);
        PlayerPrefs.Save();
    }
}