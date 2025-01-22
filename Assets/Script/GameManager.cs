using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private SaveData saveData;
    private string savePath;


    void Awake()
    {
        if (instance == null)
        {
            savePath = Path.Combine(Application.persistentDataPath, "SaveData.json");
            Debug.Log($"Save path: {Application.persistentDataPath}");
            saveData = Load();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddGold()
    {
        saveData.goldCount++;
    }

    public void AddKill()
    {
        saveData.killCount++;
    }

    public int GetGold()
    {
        return saveData.goldCount;
    }

    public int GetKill()
    {
        return saveData.killCount;
    }


    public void Save() {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
    }

    public SaveData Load() {
        if (File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return new SaveData();
    }

    public void GotoGarden() {
        SceneManager.LoadScene("GardenScene");
    }

    public void GotoBeach() {
        SceneManager.LoadScene("BeachScene");
    }

    public void GotoHome() {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
