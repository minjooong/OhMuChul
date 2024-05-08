using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 플레이어인지 확인
        if (collision.CompareTag("Player"))
        {
            // 플레이어의 색상을 노란색으로 변경
            collision.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (collision.CompareTag("Ground"))
        {
            // 땅에 충돌하면 총알 삭제
            Destroy(gameObject);
        }
    }
}
