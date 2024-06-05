using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private float startTime;
    private bool gameEnded = false;

    void Start()
    {
        startTime = Time.time;
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

        // 게임이 끝났을 때 경과 시간을 계산합니다.
        float endTime = Time.time;
        float elapsedTime = endTime - startTime;

        // 경과 시간을 PlayerPrefs를 통해 저장합니다.
        PlayerPrefs.SetFloat("CurrentScore", elapsedTime);

    }
}
