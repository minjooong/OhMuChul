using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{
    private void Start()
    {
        // 시작할 때 아이템을 활성화
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TimeSlow(collision.gameObject));
            this.gameObject.AddComponent<ItemFollow>();
        }
    }

    private IEnumerator TimeSlow(GameObject player)
    {
        Debug.Log("timewarp");

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

        // 5초간 유지
        yield return new WaitForSecondsRealtime(8f);

        // 전체 시간을 원래대로 복귀
        Time.timeScale = 1f;
        Time.fixedDeltaTime = originalFixedDeltaTime;

        // 플레이어 속도를 원래대로 복귀
        if (playerScript != null)
        {
            playerScript.SetSpeedMultiplier(1f);
        }
        Debug.Log("time slow end");
        Destroy(this.gameObject);
    }
}
