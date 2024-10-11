using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public int inGameHour = 6;
    public int inGameDay = 1;

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI hourText;

    public float realTimeSecondsPerInGameHour = 30.0f;
    private float timer = 0.0f;
    public GameObject newDayScreen;
    private string dayKey = "InGameDay";
    private string hourKey = "InGameHour";

    void Start()
    {
        if (PlayerPrefs.HasKey(dayKey))
        {
            inGameDay = PlayerPrefs.GetInt(dayKey);
        }

        if (PlayerPrefs.HasKey(hourKey))
        {
            inGameHour = PlayerPrefs.GetInt(hourKey);
        }

        UpdateTimeText();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= realTimeSecondsPerInGameHour)
        {
            timer -= realTimeSecondsPerInGameHour;
            inGameHour++;
            if (inGameHour >= 22)
            {
                inGameHour = 6;
                inGameDay++;
                HandleNewDay();
            }

            PlayerPrefs.SetInt(dayKey, inGameDay);
            PlayerPrefs.SetInt(hourKey, inGameHour);
            PlayerPrefs.Save();
        }

        UpdateTimeText();
    }
    void UpdateTimeText()
    {
        dayText.text = "Day " + inGameDay.ToString();
        hourText.text = "Hour " + inGameHour.ToString("00") + ":00";
    }

    private void HandleNewDay()
    {
        Time.timeScale = 0;
        newDayScreen.SetActive(true);
    }

    public void HandleEndDay()
    {
        inGameHour = 22;
    }
}