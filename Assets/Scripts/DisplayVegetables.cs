using UnityEngine;
using TMPro;

public class DisplayVegetables : MonoBehaviour
{
    public PlayerData playerData;
    
    public TextMeshProUGUI beetDisplay;
    public TextMeshProUGUI daikonDisplay;
    public TextMeshProUGUI lettuceDisplay;
    public TextMeshProUGUI parsnipDisplay;
    public TextMeshProUGUI radishDisplay;
    public TextMeshProUGUI tomatoDisplay;

    // Update is called once per frame
    void Update()
    {
        beetDisplay.text = (playerData.beet.ToString());
        daikonDisplay.text = (playerData.daikon.ToString());
        lettuceDisplay.text = (playerData.lettuce.ToString());
        parsnipDisplay.text = (playerData.parsnip.ToString());
        radishDisplay.text = (playerData.radish.ToString());
        tomatoDisplay.text = (playerData.tomato.ToString());
    }
}
