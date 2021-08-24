using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in SECONDS")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    void Update()
    {
       if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timeFinished)
        {
            //Debug.Log("Level timer Expired. ");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
