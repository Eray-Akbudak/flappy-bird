using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{   public static DataController ornek;
    private const string High_Score = "High Score";


    void Awake()
    {
        TekilNesne();
        Oyunilkdefabasladi();


    }

    private void Oyunilkdefabasladi()
    {
        if (PlayerPrefs.HasKey("Oyunilkdefabasladý"))
        {
            PlayerPrefs.SetInt(High_Score, 0);
            PlayerPrefs.SetInt("Oyunilkdefabasladi", 0);
        }
    }

    void TekilNesne()
    {
        if (ornek != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);

        }

      
    }
        public void setHighScore(int score)
        {
            PlayerPrefs.SetInt(High_Score, score);

        }
        public int getHighScore()
        {
            return PlayerPrefs.GetInt(High_Score);
        }

}
