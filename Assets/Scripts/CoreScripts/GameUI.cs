using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text starsText;
    [SerializeField] Text totalStarsText;
    [SerializeField] Player player;
    [SerializeField] GameObject[] healtsIndicators;
    
    void Start()
    {
        GameData.OnScoreChanged += UpdateScore;
        GameData.OnStarsChanged += UpdateStars;
        GameData.OnTotalStarsChanged += UpdateTotalStars;
        UpdateTotalStars();
        UpdateStars();
        UpdateScore();
        if (player == null)
        {
            Debug.Log("Player not assigned");
            return;
        }
        player.OnHealthChanged += UpdateHealth;
    }
    private void OnDestroy()
    {
        GameData.OnScoreChanged -= UpdateScore;
        GameData.OnStarsChanged -= UpdateStars;
        GameData.OnTotalStarsChanged -= UpdateTotalStars;
        if(player != null) player.OnHealthChanged -= UpdateHealth;
    }
    void UpdateScore()
    {
        if (scoreText == null) return;
        scoreText.text = GameData.Score.ToString();
    }
    void UpdateStars()
    {
        if (starsText == null) return;
        starsText.text = GameData.Stars.ToString();
    }
    void UpdateTotalStars()
    {
        if (totalStarsText == null) return;
        totalStarsText.text = GameData.TotalStars.ToString();
    }
    void UpdateHealth(int newHealthValue)
    {
        healtsIndicators.ToList().ForEach(indicator => indicator.SetActive(false));
        for (int i = 0; i < newHealthValue; i++)
        {
            healtsIndicators[i].SetActive(true);
        }
    }
}
