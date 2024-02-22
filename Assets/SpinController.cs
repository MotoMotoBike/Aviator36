using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpinController : MonoBehaviour
{
    [SerializeField] private Text totalStarsText;
    [SerializeField] private float speed;
    public int winValue = 0;
    [SerializeField] private GameObject Wheel;
    private bool spinFinished = true;

    private void Start()
    {
        GameData.OnTotalStarsChanged += UpdateTotalStarsValue;
        UpdateTotalStarsValue();
    }
    private void OnDestroy()
    {
        GameData.OnTotalStarsChanged -= UpdateTotalStarsValue;
    }
    
    private void Update()
    {
        if (speed > 0)
        {
            Wheel.transform.Rotate(transform.forward * -speed);
            speed -= Time.deltaTime;
        }
        else
        {
            if (spinFinished == false)
            {
                spinFinished = true;
                GameData.TotalStars += winValue;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        winValue = Convert.ToInt32(other.gameObject.name);
    }

    public void DoSpeen(int price)
    {
        if(GameData.TotalStars < price) return;
        GameData.TotalStars -= price;
        speed = Random.Range(3f, 5f);
        spinFinished = false;
    }

    void UpdateTotalStarsValue()
    {
        totalStarsText.text = GameData.TotalStars.ToString();
    }
}
