using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSign : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("EnemyArea"))
        {
            return;
        }
        // 적의 위치
        Vector3 enemyPosition = transform.position;
        // 플레이어의 위치
        Vector3 playerPosition = GameManager.instance.player.transform.position;

        // 플레이어의 X 좌표가 적의 X 좌표보다 작으면 플레이어는 적의 왼쪽에 있음
        if (playerPosition.x > enemyPosition.x)
        {
            Deactivate();
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false); // tree 오브젝트를 비활성화합니다.
    }
}
