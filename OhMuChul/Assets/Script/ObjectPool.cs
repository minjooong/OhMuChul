using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject enemyPrefab;
    public int poolSize = 10;
    private List<Enemy> pool;

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
        pool = new List<Enemy>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab, transform);
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Deactivate();
            pool.Add(enemy);
        }
    }

    // 비활성화된 Enemy 오브젝트를 찾아서 반환하는 메서드
    public Enemy GetEnemyFromPool()
    {
        foreach (Enemy enemy in pool)
        {
            if (!enemy.gameObject.activeInHierarchy)
                return enemy;
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

    // Enemy를 비활성화하여 풀에 반환하는 메서드
    public void DeactivateEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

    }

}
