using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject enemy;
    private Transform areaTransform; // Area의 오른쪽 끝 위치

    public float minStillSpawnDelay = 2f; // 가만히 있을 때 최소 스폰 딜레이
    public float maxStillSpawnDelay = 3f; // 가만히 있을 때 최대 스폰 딜레이
    public float minMovingSpawnDelay = 0.1f; // 움직일 때 최소 스폰 딜레이
    public float maxMovingSpawnDelay = 1.5f; // 움직일 때 최대 스폰 딜레이

    private Rigidbody2D playerRigidbody;

    void Awake()
    {
        instance = this;
        GameObject areaObject = GameObject.Find("Area"); // Area 오브젝트의 이름을 가정하고 찾습니다.
        areaTransform = areaObject.transform; // Area 오브젝트의 Transform을 할당합니다.

        // 플레이어의 Rigidbody 컴포넌트를 가져옵니다.
        playerRigidbody = player.GetComponent<Rigidbody2D>();

        // 랜덤한 시간 간격으로 SpawnEnemy 코루틴을 시작합니다.
        StartCoroutine(SpawnEnemyRandomly());
    }

    IEnumerator SpawnEnemyRandomly()
    {
        while (true)
        {
            float spawnDelay;

            // 플레이어가 가만히 있는지 아닌지에 따라 스폰 딜레이를 결정합니다.
            if (playerRigidbody.velocity.x < 0.1f)
            {
                spawnDelay = Random.Range(minStillSpawnDelay, maxStillSpawnDelay);
            }
            else // 플레이어가 움직이는 경우
            {
                spawnDelay = Random.Range(minMovingSpawnDelay, maxMovingSpawnDelay);
            }

            yield return new WaitForSeconds(spawnDelay);

            SpawnEnemy(); // 적 생성
        }
    }

    public void SpawnEnemy()
    {
        if (ObjectPool.Instance != null)
        {
            // ObjectPool 인스턴스가 유효한 경우에만 호출합니다.
            Vector3 spawnPosition = new Vector3(areaTransform.position.x + 16, 4f, areaTransform.position.z);
            ObjectPool.Instance.ActivateEnemy(spawnPosition);
        }
        else
        {
            Debug.LogError("ObjectPool instance is not set!");
        }
    }
}
