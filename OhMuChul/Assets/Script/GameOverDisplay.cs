using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverDisplay : MonoBehaviour
{
    public Text scoreText; // 마지막 점수를 표시할 Text UI

    void Start()
    {
        // 저장된 마지막 점수 불러오기
        float lastScore = PlayerPrefs.GetFloat("LastScore", 0f);
        scoreText.text = "점수: " + lastScore.ToString("F2");
    }

    public void OnReplayButtonClicked()
    {
        // PlayScene이라는 이름의 씬을 로드
        SceneManager.LoadScene("PlayScene");
    }
}
