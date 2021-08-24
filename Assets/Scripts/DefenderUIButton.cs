using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenderUIButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    TextMeshProUGUI costText;

    private void Start()
    {
        LabelButtonCost();
    }

    private void LabelButtonCost()
    {
        costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText)
        {
            //Debug.LogError(name + "has no cost text, add something!");
        }
        else
        {
            costText.text = defenderPrefab.GetResourceCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderUIButton>();
        foreach(DefenderUIButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<Defense>().SetSelectedDefender(defenderPrefab);
    }
}
