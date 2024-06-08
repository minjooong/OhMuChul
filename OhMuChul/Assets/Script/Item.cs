using System.Collections;
using System.Collections.Generic;
/*using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/



/*
using UnityEngine;

public class Item : MonoBehaviour
{
    public int protectionCount = 2; // 보호 횟수
    public float appearanceInterval = 30f; // 등장 간격

    private void Start()
    {
        // 시작할 때 아이템을 비활성화
        gameObject.SetActive(false);

        // 등장 간격마다 아이템이 등장하도록 설정
        InvokeRepeating("Appear", appearanceInterval, appearanceInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProtectPlayer(collision.gameObject);
        }
    }

    private void ProtectPlayer(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.EnableProtection(); // 플레이어 보호 활성화
        }
        protectionCount--;

        // 보호 횟수가 모두 소진되면 아이템을 제거
        if (protectionCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Appear()
    {
        // 등장할 때만 아이템을 활성화
        gameObject.SetActive(true);
    }
}
*/

/*
using UnityEngine;

public class Item : MonoBehaviour
{
    public int protectionCount = 2; // 보호 횟수
    public float appearanceDelay = 30f; // 등장 딜레이
    public float appearanceInterval = 30f; // 등장 간격

    private void Start()
    {
        // 시작할 때 아이템을 비활성화
        gameObject.SetActive(false);

        // 등장 딜레이 후에 등장 시작
        InvokeRepeating("Appear", appearanceDelay, appearanceInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProtectPlayer(collision.gameObject);
        }
    }

    private void ProtectPlayer(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.EnableProtection(); // 플레이어 보호 활성화
        }
        protectionCount--;

        // 보호 횟수가 모두 소진되면 아이템을 제거
        if (protectionCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Appear()
    {
        // 등장할 때만 아이템을 활성화
        gameObject.SetActive(true);
    }
}
*/

using UnityEngine;

public class Item : MonoBehaviour
{
    public int protectionCount = 2; // 보호 횟수
    public float appearanceDelay = 30f; // 등장 딜레이
    public float appearanceInterval = 30f; // 등장 간격

    private void Start()
    {
        // 시작할 때 아이템을 비활성화
        gameObject.SetActive(false);

        // 등장 딜레이 후에 등장 시작
        InvokeRepeating("Appear", appearanceDelay, appearanceInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ProtectPlayer(collision.gameObject);
        }
    }

    private void ProtectPlayer(GameObject player)
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.EnableProtection(); // 플레이어 보호 활성화
        }
        protectionCount--;

        // 보호 횟수가 모두 소진되면 아이템을 제거
        if (protectionCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Appear()
    {
        // 등장할 때만 아이템을 활성화
        gameObject.SetActive(true);
    }
}
