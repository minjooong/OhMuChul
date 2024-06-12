using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollow : MonoBehaviour
{
    public GameObject player;  // 플레이어 오브젝트를 저장할 변수
    public Vector3 offset = new Vector3(0, 1, 0);  // 아이템이 플레이어 머리 위에 있을 오프셋

    void Start()
    {
        // 플레이어 오브젝트를 태그를 통해 찾기
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // 플레이어의 위치에 오프셋을 더해 아이템 위치 업데이트
            transform.position = player.transform.position + offset;
        }
    }
}
