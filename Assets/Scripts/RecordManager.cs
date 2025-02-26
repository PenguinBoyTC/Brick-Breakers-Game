using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordManager : MonoBehaviour
{
    public static RecordManager Instance;

    public int Record;
    public string BestUserName;
    public string CurrentUserName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public int Record;
        public string BestUserName;
    }

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.Record = Record;
        data.BestUserName = CurrentUserName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Record = data.Record;
            BestUserName = data.BestUserName;
        }
    }
}
