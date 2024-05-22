using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// VFX 출력을 도와주는 매니저
/// </summary>
public class FXManager : MonoBehaviour
{

    /// <summary>
    /// 파티클 타입의 게임 오브젝트를 보여줄 때 사용
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    /// <param name="_parent">파티클 생성 위치 (부모)</param>
    /// <returns></returns>
    public static GameObject SpawnFx(GameObject obj, Transform _parent)
    {
        GameObject go                   = Instantiate(obj, _parent);
        go.transform.position           = Vector3.zero;
        go.transform.localPosition      = Vector3.zero;

        go.SetActive(true);
        return go;
    }
    /// <summary>
    /// 파티클 타입의 게임 오브젝트를 보여줄 때 사용
    /// </summary>
    /// <param name="type">파티클 타입</param>
    /// <param name="_parent">파티클 생성 위치 (부모)</param>
    /// <returns></returns>
    public static GameObject SpawnFx(VFXType type, Transform _parent)
    {
        GameObject go                   = Instantiate(CommonVFXs.GetPrefab(type), _parent);
        go.transform.position           = Vector3.zero;
        go.transform.localPosition      = Vector3.zero;

        go.SetActive(true);
        return go;
    }
    /// <summary>
    /// 파티클 타입의 게임 오브젝트를 보여줄 때 사용
    /// </summary>
    /// <param name="obj">파티클 오브젝트</param>
    /// <param name="position">파티클 위치 값</param>
    /// <param name="rotation">파티클 회전 값</param>
    public static void SpawnFx(GameObject obj, Vector3 position, Quaternion rotation, Transform _parent = null)
    {
        Transform _trans = Instantiate(obj, position, rotation).transform;
        _trans.SetParent(_parent);
        _trans.gameObject.SetActive(true);
    }
    /// <summary>
    /// 파티클 타입의 게임 오브젝트를 보여줄 때 사용
    /// </summary>
    /// <param name="type">파티클 타입</param>
    /// <param name="position">파티클 위치 값</param>
    /// <param name="rotation">파티클 회전 값</param>
    public static void SpawnFx(VFXType type, Vector3 position, Quaternion rotation, Transform _parent = null)
    {
        Transform _trans = Instantiate(CommonVFXs.GetPrefab(type), position, rotation).transform;
        _trans.SetParent(_parent);
        _trans.gameObject.SetActive(true);
    }

    private static FXManager instance = null;
        
    private static FXManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (FXManager)FindObjectOfType(typeof(FXManager));
                if (instance == null)
                {
                    // Create gameObject and add component
                    instance = (new GameObject("FXManager")).AddComponent<FXManager>();
                }
            }
            return instance;
        }
    }
}
