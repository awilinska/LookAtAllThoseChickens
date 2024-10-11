using UnityEngine;
using System.Collections.Generic;

public class DestroyChickens : MonoBehaviour
{
    public string chickenTag = "Chicken";

    public void DestroyRandomChickensWithTag(int numberOfChickensToDestroy)
    {
        GameObject[] chickenObjects = GameObject.FindGameObjectsWithTag(chickenTag);

        if (chickenObjects.Length < numberOfChickensToDestroy)
        {
            Debug.LogWarning("Not enough chickens to destroy.");
            return;
        }

        List<GameObject> remainingChickens = new List<GameObject>(chickenObjects);

        for (int i = 0; i < numberOfChickensToDestroy; i++)
        {
            int randomIndex = Random.Range(0, remainingChickens.Count);
            GameObject chickenToDestroy = remainingChickens[randomIndex];

            Destroy(chickenToDestroy);

            remainingChickens.RemoveAt(randomIndex);
        }
    }
}