using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] float baseLives = 3;
    [SerializeField] int lifeDamage = 1;
    float lives;


    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
        Debug.Log("difficulty setting curretly is " + PlayerPrefsController.GetDifficulty());
    }
    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }
    public void ReduceLife()
    {
        lives -= lifeDamage;
        UpdateDisplay();       

        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            //FindObjectOfType<LevelLoader>().LostGameScreen();
        }
    }

}
