using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // 최대 체력
    private int currentHealth; // 현재 체력

    private void Start()
    {
        // 게임 시작 시 현재 체력을 최대 체력으로 초기화
        currentHealth = maxHealth;
    }

    // 플레이어가 데미지를 받을 때 호출되는 함수
    public void TakeDamage(int damageAmount)
    {
        // 데미지만큼 체력을 감소시킴
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);
        if (currentHealth == 4)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (currentHealth == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (currentHealth == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (currentHealth == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        // 만약 현재 체력이 0 이하로 떨어졌을 때
        if (currentHealth <= 0)
        {
            // 플레이어를 파괴하거나 게임 오버 등의 처리를 수행할 수 있음
            Debug.Log("Player is dead!");
            // 예시로 여기서는 게임 오브젝트를 파괴함
            //Destroy(gameObject);
        }
    }

    // 플레이어의 체력을 회복하는 함수
    public void Heal(int healAmount)
    {
        // 현재 체력이 최대 체력보다 작을 때만 회복함
        if (currentHealth < maxHealth)
        {
            currentHealth += healAmount;

            // 회복 후 현재 체력이 최대 체력을 초과하지 않도록 함
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
    }
}
