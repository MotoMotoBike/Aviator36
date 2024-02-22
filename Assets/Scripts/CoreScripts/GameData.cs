using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static Action OnScoreChanged;
    public static Action OnStarsChanged;
    public static Action OnTotalStarsChanged;
    private static int _score = 0;
    private static int _stars = 0;
    
    public static int SkinID
    {
        get => PlayerPrefs.GetInt("SkinID",1);
        set => PlayerPrefs.SetInt("SkinID", value);
    }
    
    public static bool HasFreeSpin = false;
    
    public static int Stars {
        get => _stars;
        set{
            _stars = value;
            if(OnStarsChanged != null) OnStarsChanged.Invoke();
        }
    }
    public static int Score {
        get => _score;
        set{
            _score = value;
            if(OnScoreChanged != null) OnScoreChanged.Invoke();
        }
    }
    public static int HiScore
    {
        get => PlayerPrefs.GetInt("HiScore",0);
        set => PlayerPrefs.SetInt("HiScore", value);
    }
    public static int TotalStars
    {
        get => PlayerPrefs.GetInt("TotalStars",0);
        set {
            PlayerPrefs.SetInt("TotalStars", value); 
            if(OnTotalStarsChanged != null) OnTotalStarsChanged.Invoke();
        }
    }
    
}
