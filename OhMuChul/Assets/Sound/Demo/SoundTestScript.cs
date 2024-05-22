using System;
using System.Collections;
using System.Collections.Generic;
using GameLogic.Manager;
using UnityEngine;
using UnityEngine.UI;

public class SoundTestScript : MonoBehaviour
{
    
    public AudioClip TestAudio;
    
    [Space]
    // 글로벌 볼륨 조절 슬라이더
    public Slider globalVolume;
    // 배경음 볼륨 조절 슬라이더
    public Slider bgmVolume;
    // 효과음 볼륨 조절 슬라이더
    public Slider sfxVolume;

    private void Start()
    {
        // 슬라이더 값 초기화
        globalVolume.value = SoundManager.GlobalVolume;
        bgmVolume.value = SoundManager.GlobalMusicVolume;
        sfxVolume.value = SoundManager.GlobalSfxVolume;
    }

    public void PlayTest()
    {
        // 오디오 클립을 바로 받아와서 사용 가능
        SoundManager.PlayMusic(TestAudio);
    }
    
    public void PlayLogoBGM()
    {
        // CommonSounds 를 활용하여 출력 (인트로 배경음 출력)
        SoundManager.PlayMusic(CommonSounds.GetClip(MusicType.INTRO_BGM));
    }

    public void PlayMainBGM()
    {
        // CommonSounds 를 활용하여 출력 (메인 배경음 출력)
        SoundManager.PlayMusic(CommonSounds.GetClip(MusicType.MAIN_BGM));
    }

    public void PlayButtonSFX()
    { 
        // CommonSounds 를 활용하여 출력 (버튼 효과음 출력)
        SoundManager.PlaySfx(CommonSounds.GetClip(SfxType.COMMON_BUTTON));
    }

    public void PauseAll()
    {
        //배경음, 효과음 둘다 일시정지
        SoundManager.PauseAll(); 
    }

    public void ResumeAll()
    {
        //배경음, 효과음 둘다 일시정지 해제
        SoundManager.ResumeAll();
    }

    public void StopAll()
    {
        //배경음, 효과음 둘다 중지
        SoundManager.StopAll();
    }
    public void ChangeGlobalVolume()
    {
        //배경음, 효과음 둘다 영향을 주는 글로벌 볼륨 조절 부분
        SoundManager.GlobalVolume = globalVolume.value;
    }
    public void ChangeBGMVolume()
    {
        //배경음에 영향을 주는 글로벌 볼륨 조절 부분
        SoundManager.GlobalMusicVolume = bgmVolume.value;
    }
    public void ChangeSFXVolume()
    {
        //효과음에 영향을 주는 글로벌 볼륨 조절 부분
        SoundManager.GlobalSfxVolume = sfxVolume.value;
    }
}
