using GameLogic.Manager;
using UnityEngine;


public class Playing1BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlayMusic(CommonSounds.GetClip(MusicType.MAIN_BGM));
    }
}
