using System;
using System.IO;
using UnityEngine;

/// <summary>
/// 유저 데이터 저장을 하기 위해 필요한 정적 클래스
/// </summary>
public static class UserSettings
{
    private static readonly string FILE_NAME    = "SAVE_USER_DATA";
    private static readonly string KEY_USER_ID  = "UserId_";
    private static string userId;
    
    private static string dataDirPath = "";
    private static string dataFileName = "";
    
    /// <summary>
    /// 현재 유저 데이터
    /// </summary>
    public static UserData Data { get; set; }

    /// <summary>
    /// 유저 데이터 초기화 (앱 실행할 때마다 적용)
    /// </summary>
    public static void Init(bool includeLoad = true)
    {
        userId          = $"{KEY_USER_ID}";
        dataDirPath     = Application.persistentDataPath;
        dataFileName    = FILE_NAME;
        
        //유저 데이터 클래스 생성
        Data = new UserData();
        
        UnityEngine.Debug.Log($"<color=green><b>[UserSetting] Init</b></color>");
        
        if(!includeLoad)
            return;
        
        //유저 데이터 저장된 부분이 있다면 불러오기
        Load();
    }
    
    /// <summary>
    /// 유저 데이터 저장하기
    /// </summary>
    public static void Save()
    {
        if (string.IsNullOrEmpty(dataDirPath))
        {
            Init(false);
        }
        
        string json = JsonUtility.ToJson(Data, true);
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        
        UnityEngine.Debug.Log($"<color=blue><b>[UserSetting] Save [<color=white>{fullPath}</color>]</b></color>");
        
        try 
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                    writer.Write(json);
            }
        }
        catch (Exception e) 
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e);
        }
    }
    
    /// <summary>
    /// 유저 데이터 불러오기
    /// </summary>
    public static void Load()
    {  
        if (string.IsNullOrEmpty(dataDirPath))
        {
            Init();
            return;
        }
        
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        if (File.Exists(fullPath)) 
        {
            try 
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                        dataToLoad = reader.ReadToEnd();
                }
                Data = JsonUtility.FromJson<UserData>(dataToLoad);
                
                UnityEngine.Debug.Log($"<color=yellow><b>[UserSetting] Load</b></color>");
            }
            catch (Exception e) 
            {
                Debug.LogError("Error occured when trying to load file at path: " 
                               + fullPath  + " and backup did not work.\n" + e);
            }
        }
    }

    public static void Delete()
    {
        if (string.IsNullOrEmpty(dataDirPath))
        {
            Init(false);
        }
        
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try 
        {
            if (File.Exists(fullPath)) 
            {
                UnityEngine.Debug.Log($"<color=red><b>[UserSetting] Delete</b></color>");
                Directory.Delete(Path.GetDirectoryName(fullPath), true);
                
                // 데이터 초기화
                Data.Init();
                
            }
            else 
            {
                Debug.LogWarning("Tried to delete profile data, but data was not found at path: " + fullPath);
            }
        }
        catch (Exception e) 
        {
            Debug.LogError("Failed to delete profile data for profileId: " 
                           + " at path: " + fullPath + "\n" + e);
        }
    }
}
