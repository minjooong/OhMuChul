using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Area"))
        {
            return;
        }

        Player playerScript = GameManager.instance.player.GetComponent<Player>();
        Vector2 playerDir = playerScript.moveInput;

        // 플레이어의 이동 방향이 오른쪽인 경우에만 오른쪽으로 이동
        if (playerDir.x > 0)
        {
            float moveAmount = 108f; // 이동할 양
            Vector3 moveVector = Vector3.right * moveAmount;

            // Ground 또는 Sky 태그를 가진 경우에 따라 이동
            if (gameObject.CompareTag("Ground") || gameObject.CompareTag("Sky"))
            {
                transform.Translate(moveVector);
            }
        }
    }
}
