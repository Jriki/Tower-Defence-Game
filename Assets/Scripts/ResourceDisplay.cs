using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourceText;
    [SerializeField] int resource = 100;

    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resourceText.text = resource.ToString();
    }

    public bool ResourcePoolCheck(int amount)
    {
        return resource >= amount;
    }

    public void AddResource(int amount)
    {
        resource += amount;
        UpdateDisplay();
    }

    public void SpendResource(int amount)
    {
        if (resource >= amount)
        {
            resource -= amount;
            UpdateDisplay();
        }
    }

}
