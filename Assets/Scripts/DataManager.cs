using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string CurrentPlayer;
    public string BestPlayer;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string CurrentPlayer;
        public string BestPlayer;
        public int HighScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.CurrentPlayer = CurrentPlayer;
        data.BestPlayer = BestPlayer;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            data.CurrentPlayer = CurrentPlayer;
            BestPlayer = data.BestPlayer;
            HighScore = data.HighScore;
        }
    }
}
