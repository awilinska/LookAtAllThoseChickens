using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public Button plantButton;
    public Button harvestButton;
    public Button beetButton;
    public Button daikonButton;
    public Button lettuceButton;
    public Button parsnipButton;
    public Button radishButton;
    public Button tomatoButton;
    public GameObject vegetable;
    public GameObject plant;
    public Material plantedFieldMaterial;
    public Material emptyFieldMaterial;
    public PlayerData playerData;

    private bool playerInside;
    private Vegetable plantedVegetable;
    private int plantingDay = -1;
    private bool isGrowing = false;

    public TimeManager timeManager;

    private void Start()
    {
        plantButton.onClick.AddListener(SelectVegetableForField);
        plantButton.gameObject.SetActive(false);

        harvestButton.onClick.AddListener(HarvestVegetable);
        harvestButton.gameObject.SetActive(false);

        beetButton.onClick.AddListener(() => SelectVegetable("Beet", 5));
        daikonButton.onClick.AddListener(() => SelectVegetable("Daikon", 3));
        lettuceButton.onClick.AddListener(() => SelectVegetable("Lettuce", 4));
        parsnipButton.onClick.AddListener(() => SelectVegetable("Parsnip", 2));
        radishButton.onClick.AddListener(() => SelectVegetable("Radish", 6));
        tomatoButton.onClick.AddListener(() => SelectVegetable("Tomato", 7));

        LoadPlantedVegetable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            if (!string.IsNullOrEmpty(plantedVegetable?.type))
            {
                if (isGrowing)
                {
                    harvestButton.gameObject.SetActive(false);
                }
                else
                {
                    harvestButton.gameObject.SetActive(true);
                }
                plantButton.gameObject.SetActive(false);
            }
            else
            {
                plantButton.gameObject.SetActive(true);
                harvestButton.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            plantButton.gameObject.SetActive(false);
            harvestButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isGrowing && plantingDay >= 0)
        {
            int currentDay = timeManager.inGameDay;
            if (currentDay >= plantingDay + plantedVegetable.growthTime)
            {
                isGrowing = false;
                Debug.Log(plantedVegetable.type + " has fully grown in this field!");
                plant.SetActive(false);
                vegetable.SetActive(true);
            }
        }
    }

    private void SelectVegetableForField()
    {
        if (playerInside)
        {
            if (!string.IsNullOrEmpty(plantedVegetable?.type))
            {
                Debug.Log("This field has already been planted with " + plantedVegetable.type + ".");
            }
            else
            {
                Debug.Log("Please select a vegetable type before planting.");
            }
        }
    }

    private void SelectVegetable(string vegetableType, int growthTimeInDays)
    {
        if (playerInside)
        {
            if (string.IsNullOrEmpty(plantedVegetable?.type))
            {
                plantedVegetable = new Vegetable
                {
                    type = vegetableType,
                    growthTime = growthTimeInDays
                };
                isGrowing = true;
                plantingDay = timeManager.inGameDay;
                Renderer fieldRenderer = GetComponent<Renderer>();
                if (fieldRenderer != null)
                {
                    fieldRenderer.material = plantedFieldMaterial;
                }
                plant.SetActive(true);
                plantButton.gameObject.SetActive(false);
                harvestButton.gameObject.SetActive(false);

                PlayerPrefs.SetString("Field" + GetInstanceID(), vegetableType);
                PlayerPrefs.SetInt("PlantingDay" + GetInstanceID(), plantingDay);
                PlayerPrefs.SetInt("IsGrowing" + GetInstanceID(), isGrowing ? 1 : 0);
                PlayerPrefs.Save();
                Debug.Log(vegetableType + " selected for planting in this field.");
            }
            else
            {
                Debug.Log("This field has already been planted with " + plantedVegetable.type + ".");
            }
        }
    }

private void LoadPlantedVegetable()
{
    if (PlayerPrefs.HasKey("Field" + GetInstanceID()))
    {
        plantedVegetable = new Vegetable
        {
            type = PlayerPrefs.GetString("Field" + GetInstanceID())
        };

        if (PlayerPrefs.HasKey("PlantingDay" + GetInstanceID()))
        {
            plantingDay = PlayerPrefs.GetInt("PlantingDay" + GetInstanceID());
        }

        if (PlayerPrefs.HasKey("IsGrowing" + GetInstanceID()))
        {
            isGrowing = PlayerPrefs.GetInt("IsGrowing" + GetInstanceID()) == 1;
        }
    }
}

        public void HarvestVegetable()
    {
        if (!string.IsNullOrEmpty(plantedVegetable?.type) && plantingDay >= 0)
        {
            int currentDay = timeManager.inGameDay;
            if (currentDay >= plantingDay + plantedVegetable.growthTime)
            {
                playerData.AddVegetableToInventory(plantedVegetable.type);
                PlayerPrefs.DeleteKey("Field" + GetInstanceID());
                PlayerPrefs.DeleteKey("PlantingDay" + GetInstanceID());
                PlayerPrefs.DeleteKey("IsGrowing" + GetInstanceID());
                Renderer fieldRenderer = GetComponent<Renderer>();
                if (fieldRenderer != null)
                {
                    fieldRenderer.material = emptyFieldMaterial;
                }
                vegetable.SetActive(false);

                if (isGrowing)
                {
                    harvestButton.gameObject.SetActive(false);
                }
                else
                {
                    // The vegetable is fully grown, activate the harvestButton
                    //harvestButton.gameObject.SetActive(true);
                }
                plantButton.gameObject.SetActive(true);

                plantedVegetable = null;
                plantingDay = -1;
                harvestButton.gameObject.SetActive(false);
            }
        }
    }
}

