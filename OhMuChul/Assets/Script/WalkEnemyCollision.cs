using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 플레이어인지 확인
        if (collision.collider.CompareTag("Player"))
        {
            // 플레이어에게 데미지를 줌
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}
