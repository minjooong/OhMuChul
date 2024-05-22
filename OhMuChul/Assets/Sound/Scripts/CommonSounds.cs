using System;
using UnityEngine;

[Serializable]
public struct MusicData
{
    public AudioClip clip;
}
[Serializable]
public struct SfxData
{
    public AudioClip clip;
}

/// <summary>
/// 사운드 관련 데이터를 넣는 부분
/// </summary>
[CreateAssetMenu(fileName = "CommonSoundsAsset", menuName = "SoundManager/Data/CommonSounds", order = 1)]
public class CommonSounds : ScriptableObject
{
    [Header("[배경음]")]
    [Space()]
    [SerializeField] private CommonSounds.MusicTypeToData _musicTypeToData;

    [Header("[효과음]")]
    [Space()]
    [SerializeField] private CommonSounds.SfxTypeToData _sfxTypeToData;

    private static CommonSounds _commonSoundsInstance;

    private AudioClip FindMusicClip(MusicType type)
    {
        MusicData musicData;
        return this._musicTypeToData.TryGetValue(type, out musicData) ? musicData.clip : null;
    }
    private AudioClip FindSfxClip(SfxType type)
    {
        SfxData sfxData;
        return this._sfxTypeToData.TryGetValue(type, out sfxData) ? sfxData.clip : null;
    }

    public static AudioClip GetClip(MusicType type)
    {
        if (CommonSounds._commonSoundsInstance == null)
            CommonSounds._commonSoundsInstance = (CommonSounds)Resources.Load<CommonSounds>("CommonSoundsAsset");

        return CommonSounds._commonSoundsInstance.FindMusicClip(type);
    }
    public static AudioClip GetClip(SfxType type)
    {
        if (CommonSounds._commonSoundsInstance == null)
            CommonSounds._commonSoundsInstance = (CommonSounds)Resources.Load<CommonSounds>("CommonSoundsAsset");

        return CommonSounds._commonSoundsInstance.FindSfxClip(type);
    }

    public CommonSounds()
    {
    }

    [Serializable]
    public class MusicTypeToData : SerializableDictionary<MusicType, MusicData>
    {
        public MusicTypeToData()
        {
        }
    }

    [Serializable]
    public class SfxTypeToData : SerializableDictionary<SfxType, SfxData>
    {
        public SfxTypeToData()
        {
        }
    }
}