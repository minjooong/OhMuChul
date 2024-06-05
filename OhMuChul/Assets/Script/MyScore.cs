using UnityEngine;
using UnityEngine.UI;

public class MyScore : MonoBehaviour
{
    public Text scoreText; // 마지막 점수를 표시할 Text UI

    void Start()
    {
        // 저장된 마지막 점수 불러오기
        float lastScore = PlayerPrefs.GetFloat("CurrentScore", 0f);
        scoreText.text = "점수: " + lastScore.ToString("F2");
    }
}
