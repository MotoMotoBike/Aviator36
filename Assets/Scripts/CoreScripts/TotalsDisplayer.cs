using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalsDisplayer : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text bestScore;
    [SerializeField] Text newStars;
    [SerializeField] Text totalStars;
    [SerializeField] GameObject noHiScorePaner;
    [SerializeField] GameObject hiScorePaner;
    [SerializeField] GameObject SpinsPanel;
    
    void Start()
    {
        if (GameData.HasFreeSpin)
        {
            SpinsPanel.SetActive(true);
        }
        var hiScore = GameData.HiScore;
        
        if(GameData.Score > hiScore)
        {
            if(hiScorePaner != null) hiScorePaner.SetActive(true);
            GameData.HiScore = GameData.Score;
            hiScore = GameData.Score;
        }
        else
        {
            if(noHiScorePaner != null) noHiScorePaner.SetActive(true);
        }
        GameData.TotalStars += GameData.Stars;
        
        if(score != null) score.text = GameData.Score.ToString();
        if(bestScore != null) bestScore.text = hiScore.ToString();
        if(totalStars != null) totalStars.text = GameData.TotalStars.ToString();
        if(newStars != null) newStars.text = GameData.Stars.ToString();
    }
}
