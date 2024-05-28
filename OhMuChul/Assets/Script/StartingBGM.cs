using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Manager;
using UnityEngine;
using UnityEngine.UI;

public class StartingBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            SoundManager.PlayMusic(CommonSounds.GetClip(MusicType.INTRO_BGM));
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
