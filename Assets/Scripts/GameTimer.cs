using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Level duration in seconds")]
    float levelTime = 10;

    bool triggeredLevelFinished;

    void Update()
    {
        if (triggeredLevelFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
