using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 발사 위치
    public float fireRate = 2f; // 발사 간격
    public float moveSpeed = 4f; // 이동 속도
    public bool isFastEnemy = false; // FastEnemy 여부
    public bool isWalkEnemy = false; // FastEnemy 여부
    private int burstCount = 0; // 현재 몇 번의 burst를 발사했는지 추적
    private int fireCount = 0; // 현재 burst 내에서 몇 발을 발사했는지 추적
    private float nextFireTime;

    private void Update()
    {
        Move(); // 적 이동
        if (isFastEnemy) FastFire();
        else if (!isWalkEnemy) Fire();
    }

    void Move()
    {
        // 오른쪽에서 왼쪽으로 이동
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

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

    void Fire()
    {
        // 일정한 간격으로 총알 발사
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // 다음 발사 시간 설정
        }
    }
    void FastFire()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            fireCount++;

            if (fireCount >= 3)
            {
                // 3발 발사 후, fireCount를 초기화하고 burstCount를 증가
                fireCount = 0;
                burstCount++;

                // 다음 발사 시간 설정: 기본 발사 간격의 5배
                nextFireTime = Time.time + (1f / fireRate) * 5f;
            }
            else
            {
                // 다음 발사 시간 설정: 기본 발사 간격
                nextFireTime = Time.time + 1f / fireRate;
            }

            // burstCount가 3발씩 끊어 발사하는 한 사이클을 완료했는지 확인
            if (burstCount >= 1)
            {
                // burstCount 초기화 (다음 사이클 시작)
                burstCount = 0;
            }
        }
    }

    void Shoot()
    {
        // 총알을 생성하고 발사 위치로 이동시킴
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // 총알을 아래 방향으로 발사
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f; // 총알 속도 및 방향 설정
    }

    public void Deactivate()
    {
        gameObject.SetActive(false); // Enemy 오브젝트를 비활성화합니다.
    }

}
