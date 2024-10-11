using UnityEngine;

public class ChickenLimitManager : MonoBehaviour
{
    public GameObject coop1;
    public GameObject coop2;
    public GameObject coop3;
    public GameObject coop4;
    public GameObject coop5;
    public GameObject coop6;
    public GameObject coop7;
    public GameObject coop8;
    public GameObject coop9;
    public GameObject coop10;
    public GameObject coop11;
    public GameObject coop12;
    public GameObject coop13;
    public GameObject coop14;
    public GameObject coop15;
    public int chickenLimit;

    void Start()
    {
        chickenLimit = PlayerPrefs.GetInt("ChickenLimit", 5);
        Debug.Log(chickenLimit);
    }
    void Update()
    {
        if (coop1.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 5);
        }
        else if (coop2.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 10);
        }
        else if (coop3.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 15);
        }
        else if (coop4.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 20);
        }
        else if (coop5.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 25);
        }
        else if (coop6.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 30);
        }
        else if (coop7.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 35);
        }
        else if (coop8.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 40);
        }
        else if (coop9.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 45);
        }
        else if (coop10.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 50);
        }
        else if (coop11.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 60);
        }
        else if (coop12.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 70);
        }
        else if (coop13.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 80);
        }
        else if (coop14.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 90);
        }
        else if (coop15.activeSelf)
        {
            PlayerPrefs.SetInt("ChickenLimit", 100);
        }
    }
}
