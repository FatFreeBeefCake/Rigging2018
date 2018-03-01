using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Data
{
    public int totalScore;

    public float health;

    public string playerName;

    public Vector3 checkPoint;

    public int gold = 100;

    public List<GameObject> puchases;


    private static Data _Instance;

    public static Data Instance
    {
        get
        {
            if (_Instance == null)
            {

                Data.GetData();
            }
            return _Instance;
        }
    }

    public static Data GetData()

    {
        return JsonUtility.FromJson<Data>(PlayerPrefs.GetString("GameData"));

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("GameData")))
        {
            _Instance = new Data();
        } else
        {
            _Instance = JsonUtility.FromJson<Data>(PlayerPrefs.GetString("GameData"));
        }

    }

    public void SetData(Data data)
    {
        PlayerPrefs.SetString("GameData", JsonUtility.ToJson(data));
    }

    }


