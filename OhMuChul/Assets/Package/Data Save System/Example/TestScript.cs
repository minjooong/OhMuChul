using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public UserData userData;
    
    /// <summary>
    /// 초기화 하는 메소드
    /// </summary>
    public void Init()
    {
        UserSettings.Init();
        
        userData = UserSettings.Data;
    }
    
    /// <summary>
    /// 데이터를 저장하는 메소드
    /// </summary>
    public void Save()
    {
        UserSettings.Data = userData;
        
        UserSettings.Save();
    }
    
    /// <summary>
    /// 데이터를 불러오는 메소드
    /// </summary>
    public void Load()
    {
        UserSettings.Load();
        
        userData = UserSettings.Data;
    }
    
    /// <summary>
    /// 데이터를 지우는 메소드
    /// </summary>
    public void Delete()
    {
        UserSettings.Delete();
  
        userData = UserSettings.Data;
    }
}
