using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePoint; // 발사 위치
    public float fireRate = 2f; // 발사 간격

    private float nextFireTime;


    private void Update()
    {
        Fire();
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
