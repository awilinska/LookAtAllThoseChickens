using UnityEngine;

public class PlantedFields : MonoBehaviour
{
    public Material plantedFieldMaterial;

    private void Start()
    {
        Field[] fields = FindObjectsOfType<Field>();

        foreach (Field field in fields)
        {
            string plantedVegetableType = PlayerPrefs.GetString("Field" + field.GetInstanceID());

            if (!string.IsNullOrEmpty(plantedVegetableType))
            {
                Renderer fieldRenderer = field.GetComponent<Renderer>();
                if (fieldRenderer != null)
                {
                    fieldRenderer.material = plantedFieldMaterial;
                }
                field.plant.SetActive(true);
            }
        }
    }
}