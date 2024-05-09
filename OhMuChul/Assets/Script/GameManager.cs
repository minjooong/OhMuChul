using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    private Transform areaTransform; // Area의 위치

    public float minStillSpawnDelay = 2f; // 가만히 있을 때 최소 스폰 딜레이
    public float maxStillSpawnDelay = 3f; // 가만히 있을 때 최대 스폰 딜레이
    public float minMovingSpawnDelay = 0.1f; // 움직일 때 최소 스폰 딜레이
    public float maxMovingSpawnDelay = 1.5f; // 움직일 때 최대 스폰 딜레이

    private Rigidbody2D playerRigidbody;

    void Awake()
    {
        instance = this;
        GameObject areaObject = GameObject.Find("EnemyArea"); // EnemyArea 오브젝트의 이름을 가정하고 찾습니다.
        areaTransform = areaObject.transform; // EnemyArea 오브젝트의 Transform을 할당합니다.

        // 플레이어의 Rigidbody 컴포넌트를 가져옵니다.
        playerRigidbody = player.GetComponent<Rigidbody2D>();

        // 랜덤한 시간 간격으로 적 스폰 코루틴을 시작합니다.
        StartCoroutine(SpawnEnemyRandomly());
        StartCoroutine(SpawnBombEnemyRandomly());
    }

    IEnumerator SpawnEnemyRandomly()
    {
        while (true)
        {
            float spawnDelay;

            // 플레이어가 가만히 있는지 아닌지에 따라 스폰 딜레이를 결정
            if (playerRigidbody.velocity.x < 0.5f)
            {
                spawnDelay = Random.Range(minStillSpawnDelay, maxStillSpawnDelay);
            }
            else // 플레이어가 움직이는 경우
            {
                spawnDelay = Random.Range(minMovingSpawnDelay, maxMovingSpawnDelay);
            }

            yield return new WaitForSeconds(spawnDelay);

            SpawnEnemy(); // 일반 적 생성
        }
    }

    IEnumerator SpawnBombEnemyRandomly()
    {
        yield return new WaitForSeconds(20f); // 게임 플레이 20초 후에 폭탄 적 생성 시작

        while (true)
        {
            float spawnDelay = Random.Range(50 * minMovingSpawnDelay, 10 * maxMovingSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnBombEnemy(); // 폭탄 적 생성
        }
    }

    public void SpawnEnemy()
    {
        if (ObjectPool.Instance != null)
        {
            // ObjectPool 인스턴스가 유효한 경우에만 호출
            Vector3 spawnPosition = new Vector3(areaTransform.position.x + 15, 4f, areaTransform.position.z);
            ObjectPool.Instance.ActivateEnemy(spawnPosition);
        }
        else
        {
            Debug.LogError("ObjectPool instance is not set!");
        }
    }

    public void SpawnBombEnemy()
    {
        if (ObjectPool.Instance != null)
        {
            // ObjectPool 인스턴스가 유효한 경우에만 호출
            Vector3 spawnPosition = new Vector3(areaTransform.position.x + 15, 4f, areaTransform.position.z);
            ObjectPool.Instance.ActivateBombEnemy(spawnPosition);
        }
        else
        {
            Debug.LogError("ObjectPool instance is not set!");
        }
    }
}
