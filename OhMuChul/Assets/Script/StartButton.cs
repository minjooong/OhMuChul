using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start 버튼에 연결된 메서드
    public void OnStartButtonClicked()
    {
        // PlayScene이라는 이름의 씬을 로드
        SceneManager.LoadScene("PlayScene");
    }
}
