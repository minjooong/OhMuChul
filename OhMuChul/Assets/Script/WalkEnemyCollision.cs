using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemyCollision : MonoBehaviour
{
    public float knockbackForce = 25f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 플레이어인지 확인
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player collision detected");

            // 플레이어에게 데미지를 줌
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

            // 충돌 지점을 기준으로 반대 방향으로 날려보냄
            Rigidbody2D enemyRigidbody = GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // 충돌한 플레이어의 위치를 가져옴
                Vector2 collisionPoint = collision.GetContact(0).point;
                Vector2 enemyPosition = transform.position;
                Vector2 knockbackDirection = (enemyPosition - collisionPoint).normalized;

                // x 방향은 반대로, y 방향은 위로 고정
                knockbackDirection = new Vector2(Mathf.Sign(knockbackDirection.x), 1).normalized;

                enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogError("Rigidbody2D component not found on WalkEnemy");
            }
        }
    }
}
