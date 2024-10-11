using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    public GameObject uiElement; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            uiElement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            uiElement.SetActive(false);
        }
    }
}

