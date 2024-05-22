using System;
using UnityEngine;

[Serializable]
public struct FXData
{
    public GameObject Pref;
}

/// <summary>
/// 사운드 관련 데이터를 넣는 부분
/// </summary>
[CreateAssetMenu(fileName = "CommonVFXsAsset", menuName = "FXManager/Data/CommonVFXs", order = 1)]
public class CommonVFXs : ScriptableObject
{
    [Header("[효과 오브젝트]")]
    [Space()]
    [SerializeField] private CommonVFXs.VFXTypeToData _vfxTypeToData;
    
    private static CommonVFXs _commonVfXsInstance;

    private GameObject FindPrefab(VFXType type)
    {
        FXData fxData;
        return this._vfxTypeToData.TryGetValue(type, out fxData) ? fxData.Pref : null;
    }

    public static GameObject GetPrefab(VFXType type)
    {
        if (CommonVFXs._commonVfXsInstance == null)
            CommonVFXs._commonVfXsInstance = (CommonVFXs)Resources.Load<CommonVFXs>("CommonVFXsAsset");

        return CommonVFXs._commonVfXsInstance.FindPrefab(type);
    }

    public CommonVFXs()
    {
    }

    [Serializable]
    public class VFXTypeToData : SerializableDictionary<VFXType, FXData>
    {
        public VFXTypeToData()
        {
        }
    }
}