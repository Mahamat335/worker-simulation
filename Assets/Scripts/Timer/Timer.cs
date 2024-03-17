using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeRemaining = 120f; // 2 dakika
    public GameObject endGame;

    void Update()
    {
        if (timeRemaining > 0)
        {
            if (Resource.Instance.gameplay)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining < 0)
                    timeRemaining = 0;
                UpdateTimerUI();
            }
        }
        else
        {
            // Süre bittiğinde yapılacak işlemler buraya yazılabilir
            TimeIsUp();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeIsUp()
    {
        // Süre bittiğinde yapılacak işlemler buraya yazılabilir
        Debug.Log("Süre Bitti!");
        endGame.SetActive(true);
        Resource.Instance.gameplay = false;
    }
}
