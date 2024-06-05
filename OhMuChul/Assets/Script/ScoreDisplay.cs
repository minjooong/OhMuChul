using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [System.Serializable]
    public class ScoreEntry
    {
        public string name;
        public float score;

        public ScoreEntry(string name, float score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public List<ScoreEntry> scoreEntries = new List<ScoreEntry>();
    public Text[] scoreTexts;
    public InputField nameInputField;
    public Button submitButton;

    private float currentScore;

    void Start()
    {
        // PlayerPrefs에서 현재 점수를 가져옵니다.
        currentScore = PlayerPrefs.GetFloat("CurrentScore", 0);

        // 초기 상위 점수 리스트 설정
        LoadScores();

        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        string playerName = nameInputField.text;
        AddScoreEntry(playerName, currentScore);

        // 이름과 점수 입력 후, 입력 UI를 비활성화
        nameInputField.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }

    void AddScoreEntry(string name, float newScore)
    {
        scoreEntries.Add(new ScoreEntry(name, newScore));
        scoreEntries.Sort((x, y) => y.score.CompareTo(x.score));

        if (scoreEntries.Count > 5)
        {
            scoreEntries.RemoveAt(5);
        }

        SaveScores();
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scoreEntries.Count)
            {
                scoreTexts[i].text = (i + 1) + ": " + scoreEntries[i].name + " - " + scoreEntries[i].score.ToString("F2");
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ": ";
            }
        }
    }

    void LoadScores()
    {
        scoreEntries.Clear();
        for (int i = 0; i < 5; i++)
        {
            string nameKey = "HighScoreName" + i;
            string scoreKey = "HighScoreValue" + i;

            if (PlayerPrefs.HasKey(nameKey) && PlayerPrefs.HasKey(scoreKey))
            {
                string name = PlayerPrefs.GetString(nameKey);
                float score = PlayerPrefs.GetFloat(scoreKey);
                scoreEntries.Add(new ScoreEntry(name, score));
            }
        }

        UpdateScoreDisplay();
    }

    void SaveScores()
    {
        for (int i = 0; i < scoreEntries.Count; i++)
        {
            PlayerPrefs.SetString("HighScoreName" + i, scoreEntries[i].name);
            PlayerPrefs.SetFloat("HighScoreValue" + i, scoreEntries[i].score);
        }

        PlayerPrefs.Save();
    }
}
