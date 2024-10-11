using UnityEngine;
using System.Collections.Generic;

public class GameObjectCycle : MonoBehaviour
{
    public List<GameObject> gameObjectsToCycle;
    private int currentIndex = 2;

    private const string unlockedObjectsKey = "UnlockedObjects";

    void Start()
    {
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
                }
            }
        }
    }

    public void CycleNextGameObject()
    {
        currentIndex = (currentIndex + 1) % gameObjectsToCycle.Count;

        SetGameObjectActive(currentIndex);

        SaveUnlockedObjects();
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