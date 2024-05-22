using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VFXTestScript : MonoBehaviour
{
    // 출력하는 위치 값 설정
    public Vector3 spawnPos;
    // 효과음 생성할 위치
    public Transform _effectTrans;
    // 움직임 예시 오브젝트 (SKKU)
    public Transform _skku;
    
    public void Update()
    {
        // 마우스 클릭 입력
        if (Input.GetMouseButtonDown(0))
        {
            // 터치하는 부분에 UI가 있다면 출력하지 않는다라는 부분
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
            // 마우스 포지션을 화면에 보이도록 포지션 변경
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // 변경된 포지션으로 터치 효과 출력
            // 위치 값에서 Z축이 뒤에 있으면 안 보이니까 0값으로 초기화
            // 회전 값은 기본
            FXManager.SpawnFx(VFXType.TOUCH_EFFECT, new Vector3(pos.x, pos.y, 0f) , Quaternion.identity);
        }
    }

    public void OnTouchEffect()
    {
        // SKKU 오브젝트 위치에 터치 이펙트를 출력하는 코드
        GameObject obj = FXManager.SpawnFx(VFXType.DEATH_EFFECT, _effectTrans);
        obj.transform.position = _skku.position;
        obj.transform.rotation = Quaternion.identity;
    }
}
