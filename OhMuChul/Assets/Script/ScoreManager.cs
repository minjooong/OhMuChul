using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private bool gameEnded = false;
    private TimerDisplay timerDisplay;

    void Start()
    {
        timerDisplay = FindObjectOfType<TimerDisplay>();
    }

    void Update()
    {
        // 게임 종료 조건을 체크합니다.
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null && playerHealth.currentHealth == 0 && !gameEnded)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;

        // TimerDisplay의 GameOver 호출
        timerDisplay.GameOver();

    }
}
