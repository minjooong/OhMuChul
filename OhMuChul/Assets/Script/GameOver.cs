using GameLogic.Manager;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.GAMEOVER));

    }

}
