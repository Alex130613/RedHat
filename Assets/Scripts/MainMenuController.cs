using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public GameObject CButton;
    int s;
    void Start() {
        LoadGame();
        CButton.SetActive(s!=0);
    } 
    public void Continue() {
        Application.LoadLevel("Game");
    }
    public void StartNew() {
        SaveGame(0);
        Application.LoadLevel("Game"); }

    public void Exit() {
        Application.Quit();
    }


    public void SaveGame(int number)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/RedHatData.dat");
        SaveData data = new SaveData();
        if (data.ISave < number) s = data.ISave = number;
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/RedHatData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/RedHatData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            s = data.ISave;
        }
        else
        {
            s = 0;
        }
    }
}
