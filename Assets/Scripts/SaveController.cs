using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    bool save = false;
    bool t = false;
    int s;
    public GameObject TextSave;
    GameObject ObjSave;
    void Start()
    {
        LoadGame();
        GameObject[] objects;
        objects = GameObject.FindGameObjectsWithTag("Save");
        GameObject O= new GameObject();
        for (int i = objects.Length - 1; i >= 0; --i)
        {
            if (s == 0) objects[i].GetComponent<Save>().SetSave(false);
            if (objects[i].GetComponent<Save>().number == s)
            {
                O = objects[i];
                i = 0;
            }
        }
        transform.position = O.transform.position;
    }
    void Update() {
        if (Input.GetButtonDown("Done"))
        {
            if (t&&!save)
            {
                Save S = ObjSave.GetComponent<Save>();
                SaveGame(S.number);
                save = true;
                S.SetSave(true);
            }
        }
        TextSave.SetActive(t && !save);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Save"))
        {
            ObjSave = other.gameObject;
            save = other.gameObject.GetComponent<Save>().GetSave();
            t = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Save"))
        {
            t = false;
            save = t;
        }
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
[Serializable]
class SaveData
{
   public int ISave;
}