
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // PlayScene이라는 이름의 씬을 로드
        SceneManager.LoadScene("PlayScene");
    }
    public void OnHomeButtonClicked()
    {
        // PlayScene이라는 이름의 씬을 로드
        SceneManager.LoadScene("StartScene");
    }
}
