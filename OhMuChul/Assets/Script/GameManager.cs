using UnityEngine;
using System.Collections;
using GameLogic.Manager;


public class GameManager : MonoBehaviour
{
    private readonly float ITEM_SPAWN_TIME = 25f;
    private readonly float TIMEWARP_SPAWN_TIME = 10f;//37f;
    public static GameManager instance;
    public GameObject player;
    private Transform areaTransform; // Area의 위치

    public float minStillSpawnDelay = 2f; // 가만히 있을 때 최소 스폰 딜레이
    public float maxStillSpawnDelay = 3f; // 가만히 있을 때 최대 스폰 딜레이
    public float minMovingSpawnDelay = 0.1f; // 움직일 때 최소 스폰 딜레이
    public float maxMovingSpawnDelay = 1.3f; // 움직일 때 최대 스폰 딜레이

    private Rigidbody2D playerRigidbody;

    public GameObject itemPrefab; // 아이템 프리팹
    public GameObject timeWarpPrefab;
    public Transform itemSpawnPoint; // 아이템 등장 위치

    private float item_lastUpdateTime = 0f;
    private float timeWarp_lastUpdateTime = 0f;

    private void Start()
    {
        item_lastUpdateTime = ITEM_SPAWN_TIME;
        timeWarp_lastUpdateTime = TIMEWARP_SPAWN_TIME;

        Time.timeScale = 1f;
        SoundManager.GlobalMusicVolume = 1f;
    }

    private void Update()
    {
        item_lastUpdateTime -= Time.deltaTime;
        timeWarp_lastUpdateTime -= Time.deltaTime;
        if (item_lastUpdateTime <= 0)
        {
            SpawnItem();
            item_lastUpdateTime = ITEM_SPAWN_TIME;
        }
        if (timeWarp_lastUpdateTime <= 0)
        {
            SpawnTimeWarp();
            timeWarp_lastUpdateTime = TIMEWARP_SPAWN_TIME;
        }
    }

    private void SpawnItem()
    {
        Debug.Log("Item enter");

        //TODO: 스폰 위치 변경 
        Vector3 spawnPosition = new Vector3(areaTransform.position.x + 15, -1f, areaTransform.position.z);
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnTimeWarp()
    {
        Debug.Log("TimeWarp enter");

        //TODO: 스폰 위치 변경 
        Vector3 spawnPosition = new Vector3(areaTransform.position.x + 15, -1f, areaTransform.position.z);
        Instantiate(timeWarpPrefab, spawnPosition, Quaternion.identity);

        // Increase enemy spawn rate temporarily
        StartCoroutine(TemporaryIncreaseSpawnRate(6f)); // 6 seconds for example
    }

    private IEnumerator TemporaryIncreaseSpawnRate(float duration)
    {

        float originalMinStillSpawnDelay = minStillSpawnDelay;
        float originalMaxStillSpawnDelay = maxStillSpawnDelay;
        float originalMinMovingSpawnDelay = minMovingSpawnDelay;
        float originalMaxMovingSpawnDelay = maxMovingSpawnDelay;
        yield return new WaitForSeconds(0.8f);

        // Set faster spawn delays
        minStillSpawnDelay = 0.5f;
        maxStillSpawnDelay = 0.7f;
        minMovingSpawnDelay = 0.05f;
        maxMovingSpawnDelay = 0.09f;

        // Wait for the duration
        yield return new WaitForSeconds(duration);

        // Restore original spawn delays
        minStillSpawnDelay = originalMinStillSpawnDelay;
        maxStillSpawnDelay = originalMaxStillSpawnDelay;
        minMovingSpawnDelay = originalMinMovingSpawnDelay;
        maxMovingSpawnDelay = originalMaxMovingSpawnDelay;
    }

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
        StartCoroutine(SpawnFastEnemyRandomly());
        StartCoroutine(SpawnWalkEnemyRandomly());
        StartCoroutine(SpawnTreeRandomly());
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

            SpawnEnemy();
        }
    }

    IEnumerator SpawnBombEnemyRandomly()
    {
        yield return new WaitForSeconds(15f); // 게임 플레이 20초 후에 폭탄 적 생성 시작

        while (true)
        {
            float spawnDelay = Random.Range(50 * minMovingSpawnDelay, 10 * maxMovingSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnBombEnemy();
        }
    }

    IEnumerator SpawnFastEnemyRandomly()
    {
        yield return new WaitForSeconds(20f); // 게임 플레이 20초 후에 폭탄 적 생성 시작

        while (true)
        {
            float spawnDelay = Random.Range(50 * minMovingSpawnDelay, 10 * maxMovingSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnFastEnemy();
        }
    }

    IEnumerator SpawnWalkEnemyRandomly()
    {
        yield return new WaitForSeconds(25f); // 게임 플레이 20초 후에 폭탄 적 생성 시작

        while (true)
        {
            float spawnDelay = Random.Range(50 * minMovingSpawnDelay, 10 * maxMovingSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnWalkEnemy();
        }
    }

    IEnumerator SpawnTreeRandomly()
    {
        yield return new WaitForSeconds(30f); // 게임 플레이 20초 후에 폭탄 적 생성 시작

        while (true)
        {
            float spawnDelay = Random.Range(200 * minMovingSpawnDelay, 20 * maxMovingSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            SpawnTree(); // 폭탄 적 생성
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

    public void SpawnFastEnemy()
    {
        if (ObjectPool.Instance != null)
        {
            // ObjectPool 인스턴스가 유효한 경우에만 호출
            Vector3 spawnPosition = new Vector3(areaTransform.position.x + 15, 4f, areaTransform.position.z);
            ObjectPool.Instance.ActivateFastEnemy(spawnPosition);
        }
        else
        {
            Debug.LogError("ObjectPool instance is not set!");
        }
    }

    public void SpawnWalkEnemy()
    {
        if (ObjectPool.Instance != null)
        {
            // ObjectPool 인스턴스가 유효한 경우에만 호출
            Vector3 spawnPosition = new Vector3(areaTransform.position.x + 15, -3f, areaTransform.position.z);
            ObjectPool.Instance.ActivateWalkEnemy(spawnPosition);
        }
        else
        {
            Debug.LogError("ObjectPool instance is not set!");
        }
    }

    public void SpawnTree()
    {
        if (ObjectPool.Instance != null)
        {
            // ObjectPool 인스턴스가 유효한 경우에만 호출
            Vector3 spawnPosition = new Vector3(areaTransform.position.x + 20, -0.94f, areaTransform.position.z);
            ObjectPool.Instance.ActivateTree(spawnPosition);
        }
        else
        {
            Debug.LogError("ObjectPool instance is not set!");
        }
    }
}
