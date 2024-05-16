using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject enemyPrefab;
    public int enemyPoolSize = 10;
    public GameObject bombEnemyPrefab;
    public int bombEnemyPoolSize = 2;

    public GameObject fastEnemyPrefab;
    public int fastEnemyPoolSize = 2;

    private List<Enemy> enemyPool;
    private List<Enemy> bombEnemyPool;
    private List<Enemy> fastEnemyPool;

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
        enemyPool = new List<Enemy>();
        bombEnemyPool = new List<Enemy>();
        fastEnemyPool = new List<Enemy>();

        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab, transform);
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Deactivate();
            enemyPool.Add(enemy);
        }
        for (int i = 0; i < bombEnemyPoolSize; i++)
        {
            GameObject bombEnemyObj = Instantiate(bombEnemyPrefab, transform);
            Enemy bombEnemy = bombEnemyObj.GetComponent<Enemy>();
            bombEnemy.Deactivate();
            bombEnemyPool.Add(bombEnemy);
        }
        for (int i = 0; i < fastEnemyPoolSize; i++)
        {
            GameObject fastEnemyObj = Instantiate(fastEnemyPrefab, transform);
            Enemy fastEnemy = fastEnemyObj.GetComponent<Enemy>();
            fastEnemy.Deactivate();
            fastEnemyPool.Add(fastEnemy);
        }
    }

    // 비활성화된 Enemy 오브젝트를 찾아서 반환하는 메서드
    public Enemy GetEnemyFromPool()
    {
        foreach (Enemy enemy in enemyPool)
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
        }

        return null;
    }

    // 비활성화된 BombEnemy 오브젝트를 찾아서 반환하는 메서드
    public Enemy GetBombEnemyFromPool()
    {
        foreach (Enemy bombEnemy in bombEnemyPool)
        {
            if (!bombEnemy.gameObject.activeInHierarchy)
                return bombEnemy;
        }

        return null;
    }
    public Enemy GetFastEnemyFromPool()
    {
        foreach (Enemy fastEnemy in fastEnemyPool)
        {
            if (!fastEnemy.gameObject.activeInHierarchy)
                return fastEnemy;
        }

        return null;
    }

    // Enemy를 활성화하여 풀에서 가져오는 메서드
    public void ActivateEnemy(Vector3 position)
    {
        Enemy enemy = GetEnemyFromPool();
        if (enemy != null)
        {
            enemy.transform.position = position;
            enemy.gameObject.SetActive(true);
        }
    }

    // BombEnemy를 활성화하여 풀에서 가져오는 메서드
    public void ActivateBombEnemy(Vector3 position)
    {
        Enemy bombEnemy = GetBombEnemyFromPool();
        if (bombEnemy != null)
        {
            bombEnemy.transform.position = position;
            bombEnemy.gameObject.SetActive(true);
        }
    }
    public void ActivateFastEnemy(Vector3 position)
    {
        Enemy fastEnemy = GetFastEnemyFromPool();
        if (fastEnemy != null)
        {
            fastEnemy.transform.position = position;
            fastEnemy.gameObject.SetActive(true);
        }
    }
}
