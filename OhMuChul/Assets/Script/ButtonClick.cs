using UnityEngine;
using UnityEngine.SceneManagement;
using GameLogic.Manager;

public class ButtonClick : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        // PlayScene이라는 이름의 씬을 로드
        SceneManager.LoadScene("PlayScene");
        SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.COMMON_BUTTON));

    }
    public void OnHomeButtonClicked()
    {
        // PlayScene이라는 이름의 씬을 로드
        SceneManager.LoadScene("StartScene");
        SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.COMMON_BUTTON));

    }
}
