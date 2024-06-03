using System.Collections.Generic;
using System;

/// <summary>
/// 유저 데이터 클래스
/// </summary>
[Serializable]
public class UserData
{
    //COMMENT: 1. 저장할 데이터 변수 선언을 해줍니다. 
    
    // 플레이어 이름
    public string playerName;
    // 스코어
    public int score;

    public UserData()
    {
        Init();
    }

    public void Init()
    {
        //COMMENT: 2. 저장할 데이터 변수 초기화를 해줍니다.
        
        //해당 생성자에서 데이터 초기화를 해준다.
        playerName = "Nick Name";
        score = 0;
    }
}

