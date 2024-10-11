using UnityEngine;

public class ChopWood : MonoBehaviour
{
    public PlayerData playerData;

    public void ChopChop() {
        playerData.playerWood += 1;
    }
}
