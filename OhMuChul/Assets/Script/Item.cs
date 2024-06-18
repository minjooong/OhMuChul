using UnityEngine;
using GameLogic.Manager;


public class Item : MonoBehaviour
{
    private void Start()
    {
        // 시작할 때 아이템을 비활성화
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.UMBRELLA));

            ProtectPlayer(collision.gameObject);
            this.gameObject.AddComponent<ItemFollow>();
        }
    }

    private void ProtectPlayer(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.EnableProtection(this); // 플레이어 보호 활성화
        }
    }

    private void Appear()
    {
        // 등장할 때만 아이템을 활성화
        gameObject.SetActive(true);
    }
    public void Disappear()
    {
        Destroy(this.gameObject);
    }
}
