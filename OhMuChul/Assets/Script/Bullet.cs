using UnityEngine;
using GameLogic.Manager;


public class Bullet : MonoBehaviour
{
    public int damageAmount = 1; // 총알이 주는 데미지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌한 오브젝트가 플레이어인지 확인
        if (collision.CompareTag("Player"))
        {
            // 플레이어에게 데미지를 줌
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.HIT));

                playerHealth.TakeDamage(damageAmount);
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
