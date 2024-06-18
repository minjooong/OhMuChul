using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject enemyPrefab;
    public int enemyPoolSize = 20;
    public GameObject bombEnemyPrefab;
    public int bombEnemyPoolSize = 3;
    public GameObject fastEnemyPrefab;
    public int fastEnemyPoolSize = 2;
    public GameObject walkEnemyPrefab;
    public int walkEnemyPoolSize = 2;
    public GameObject treePrefab;
    public int treePoolSize = 1;

    private List<GameObject> enemyPool;
    private List<GameObject> bombEnemyPool;
    private List<GameObject> fastEnemyPool;
    private List<GameObject> walkEnemyPool;
    private List<GameObject> treePool;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        InitializePool();
    }

    private void InitializePool()
    {
        enemyPool = new List<GameObject>();
        bombEnemyPool = new List<GameObject>();
        fastEnemyPool = new List<GameObject>();
        walkEnemyPool = new List<GameObject>();
        treePool = new List<GameObject>();

        CreatePool(enemyPool, enemyPrefab, enemyPoolSize);
        CreatePool(bombEnemyPool, bombEnemyPrefab, bombEnemyPoolSize);
        CreatePool(fastEnemyPool, fastEnemyPrefab, fastEnemyPoolSize);
        CreatePool(walkEnemyPool, walkEnemyPrefab, walkEnemyPoolSize);
        CreatePool(treePool, treePrefab, treePoolSize);
    }

    private void CreatePool(List<GameObject> pool, GameObject prefab, int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    private GameObject GetObjectFromPool(List<GameObject> pool)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }
        return null;
    }

    public void ActivateObject(List<GameObject> pool, Vector3 position)
    {
        GameObject obj = GetObjectFromPool(pool);
        if (obj != null)
        {
            obj.transform.position = position;
            obj.SetActive(true);
        }
    }

    public void ActivateEnemy(Vector3 position)
    {
        ActivateObject(enemyPool, position);
    }

    public void ActivateBombEnemy(Vector3 position)
    {
        ActivateObject(bombEnemyPool, position);
    }

    public void ActivateFastEnemy(Vector3 position)
    {
        ActivateObject(fastEnemyPool, position);
    }

    public void ActivateWalkEnemy(Vector3 position)
    {
        ActivateObject(walkEnemyPool, position);
    }

    public void ActivateTree(Vector3 position)
    {
        ActivateObject(treePool, position);
    }
}
