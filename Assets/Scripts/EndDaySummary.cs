using UnityEngine;
using TMPro;

public class EndDaySummary : MonoBehaviour
{
    public PlayerData playerData;
    public CharacterController characterController;
    int summary;
    int chickens;
    public Vector3 targetPosition;
    public TextMeshProUGUI summaryDisplay;
    public TextMeshProUGUI chickensDisplay;
    public FeedingController feedingController;
    public DestroyChickens destroy;
    int toDestroy;

    void OnEnable()
    {
        CalculateSummaryAndDisplay();
    }

    private void CalculateSummaryAndDisplay()
    {
        string tagToCount = "Chicken";
        GameObject[] chickenObjects = GameObject.FindGameObjectsWithTag(tagToCount);
        int chickenCount = chickenObjects.Length;
        chickens = playerData.playerChickens + playerData.playerChicks;
        
        if (feedingController.chickensFeed < chickens) {
            
            toDestroy = chickens - feedingController.chickensFeed;
            
            destroy.DestroyRandomChickensWithTag(toDestroy);

            if (playerData.playerChicks >= toDestroy) {
                playerData.playerChicks -= toDestroy;
            } 
            else if (playerData.playerChickens >= toDestroy) {
                playerData.playerChickens -= toDestroy;
            } else {
                playerData.playerChicks -= toDestroy/3;
                playerData.playerChickens -= toDestroy/3;
            }
        
        } 
        else if(feedingController.chickensFeed == 0) {
            destroy.DestroyRandomChickensWithTag(chickens);
            playerData.playerChickens = 1;
        }
        
        feedingController.chickensFeed = 0;

        summary = (playerData.playerChickens * 10) + (playerData.playerChicks * 2);
        playerData.playerCoins += summary;

        summaryDisplay.text = "+" + summary.ToString();
        chickensDisplay.text = chickenCount.ToString();
            
        if (characterController != null)
        {
            characterController.enabled = false;
            characterController.transform.position = targetPosition;
            characterController.enabled = true;
        }
    }
}