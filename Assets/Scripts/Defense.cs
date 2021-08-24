using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDef(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender selectDefender)
    {
        defender = selectDefender;
    }

    private void AttemptToPlaceDef(Vector2 gridPos)
    {
        var ResourceDisplay = FindObjectOfType<ResourceDisplay>();
        int defenderCost = defender.GetResourceCost();
        if(ResourceDisplay.ResourcePoolCheck(defenderCost))
        {
            SpawnDefender(gridPos);
            ResourceDisplay.SpendResource(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 girdPos = SnapToGrid(worldPos);
        return girdPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
        
    private void SpawnDefender(Vector2 defenderPos)
    {
        Defender newDefender = Instantiate(defender,
            defenderPos,
            Quaternion.identity) as Defender;
        //Debug.Log(worldPos);
        newDefender.transform.parent = defenderParent.transform;
    }
}
