using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 발사 위치
    public float fireRate = 2f; // 발사 간격
    public float moveSpeed = 4f; // 이동 속도

    private float nextFireTime;

    private void Update()
    {
        Move(); // 적 이동
        Fire(); // 적 발사
    }

    void Move()
    {
        // 오른쪽에서 왼쪽으로 이동
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // sky 태그를 기준으로 생성되고 사라지도록
        if (transform.position.x < GameObject.FindGameObjectWithTag("Sky").transform.position.x)
        {
            Destroy(gameObject);
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

    void Shoot()
    {
        // 총알을 생성하고 발사 위치로 이동시킴
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // 총알을 아래 방향으로 발사
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f; // 총알 속도 및 방향 설정
    }
}
