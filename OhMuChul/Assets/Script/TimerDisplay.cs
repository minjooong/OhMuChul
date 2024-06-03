using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText; // 현재 플레이 시간을 표시할 Text UI
    public float playTime;
    private bool isGameOver;

    void Start()
    {
        playTime = 0f;
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            // 플레이 시간 업데이트
            playTime += Time.deltaTime;
            timerText.text = playTime.ToString("F2");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        PlayerPrefs.SetFloat("LastScore", playTime);
        PlayerPrefs.Save();
    }
}
