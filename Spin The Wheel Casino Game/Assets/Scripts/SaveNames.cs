using UnityEngine;
using System.IO;
using UnityEngine.UI;
[System.Serializable]
public class SaveNames : MonoBehaviour
{
    public static SaveNames instance;
    string saveFilePath;
    SaveDataStrings saveDataWrapper;
    [SerializeField] private Button saveButton;

    //add a listener to our button and make this a singleton
    private void Awake()
    {
        instance = this;
        saveButton.onClick.AddListener(SaveTheNames);
    }

    //load the names at the start
    private void Start()
    {
        LoadTheNames();
    }

    //save the names
    public void SaveTheNames()
    {
        saveDataWrapper = new SaveDataStrings();
        saveDataWrapper.names = NamesManager.instance.stringNames;
        SaveData();
    }

    //load the names using JSON
    public void LoadTheNames()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            saveDataWrapper = JsonUtility.FromJson<SaveDataStrings>(jsonData);
            NamesManager.instance.stringNames = saveDataWrapper.names;
        }
        
    }

    //save the data using JSON
    public void SaveData()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";

        string jsonData = JsonUtility.ToJson(saveDataWrapper);
        File.WriteAllText(saveFilePath, jsonData);
    }
    //Save Strings Class
    [System.Serializable]
    class SaveDataStrings
    {
        public string[] names;
    }
}