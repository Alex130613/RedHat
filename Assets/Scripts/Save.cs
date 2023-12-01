using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour {
    public int number;
    bool save = false;
    public GameObject PS;
    void Start() {
        LoadS();
    }
    void Update() {
        PS.SetActive(save);
    }
    public void SetSave(bool s) {
        save = s;
        SaveS();
    }
    public bool GetSave() {
        return save;
    }
    void LoadS() {
        if (File.Exists(Application.persistentDataPath + "/Saving" + number + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Saving" + number + ".dat", FileMode.Open);
            SaveD data = (SaveD)bf.Deserialize(file);
            file.Close();
            save = data.Save;
        }
    }
    void SaveS()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Saving"+number+".dat");
        SaveD data = new SaveD();
        data.Save= save;
        bf.Serialize(file, data);
        file.Close();
    } 
}

[Serializable]
class SaveD
{
    public bool Save;
}