using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public InputField userName; // new variable declared
    public List<string> userNames;
    public string selectedUser;

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

    public void Start()
    {
        LoadNames();
    }

    public void ChoosePlayer()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class SaveData
    {
        public List<string> userNames = new List<string>();

    }

    public void SaveName(string name)
    {
        selectedUser = name;
        SaveData data = new SaveData();
        Instance.userNames.Add(name);
        data.userNames = userNames;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNames(){

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string jsonToFile = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonToFile);

            userNames = data.userNames;
        }
    }
}
