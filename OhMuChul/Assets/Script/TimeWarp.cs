using System.Collections;
using UnityEngine;
using GameLogic.Manager;
using UnityEngine.UI;

public class TimeWarp : MonoBehaviour
{
    public Image vignetteImage; // 비네팅 효과를 적용할 UI 이미지

    private void Start()
    {
        // 시작할 때 아이템을 활성화
        gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.TIMEWARP));
            SoundManager.GlobalMusicVolume = 0.1f;
            StartCoroutine(GameManager.TemporaryIncreaseSpawnRate(3f));
            StartCoroutine(TimeSlow(collision.gameObject));
            this.gameObject.AddComponent<ItemFollow>();
        }
    }

    private IEnumerator TimeSlow(GameObject player)
    {
        Debug.Log("timewarp");

        // 비네팅 효과를 적용
        if (vignetteImage != null)
        {
            StartCoroutine(FadeInVignette());
        }

        // 전체 시간을 0.5배속으로 조절
        Time.timeScale = 0.5f;
        float originalFixedDeltaTime = Time.fixedDeltaTime;
        Time.fixedDeltaTime = 0.5f * 0.02f;

        // 플레이어 속도를 2배로 조절
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.SetSpeedMultiplier(2f);
        }

        // 8초간 유지
        yield return new WaitForSecondsRealtime(8f);

        // 비네팅 효과를 제거
        if (vignetteImage != null)
        {
            StartCoroutine(FadeOutVignette());
        }

        // 전체 시간을 원래대로 복귀
        Time.timeScale = 1f;
        Time.fixedDeltaTime = originalFixedDeltaTime;

        // 플레이어 속도를 원래대로 복귀
        if (playerScript != null)
        {
            playerScript.SetSpeedMultiplier(1f);
        }
        Debug.Log("time slow end");

        SoundManager.GlobalMusicVolume = 1f;

        Destroy(gameObject);
    }

    private IEnumerator FadeInVignette()
    {
        float duration = 1f;
        float elapsed = 0f;
        Color color = vignetteImage.color;
        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(0f, 0.5f, elapsed / duration);
            vignetteImage.color = color;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        color.a = 0.5f;
        vignetteImage.color = color;
    }

    private IEnumerator FadeOutVignette()
    {
        float duration = 1f;
        float elapsed = 0f;
        Color color = vignetteImage.color;
        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(0.5f, 0f, elapsed / duration);
            vignetteImage.color = color;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        color.a = 0f;
        vignetteImage.color = color;

        // 코루틴을 즉시 종료하여 비네팅 효과를 즉시 사라지게 함
        yield break;
    }
}
