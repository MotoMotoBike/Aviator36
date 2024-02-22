using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAtDirection : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Direction direction;
    [SerializeField] float lifeTime;
    [SerializeField] bool accelerate;
    float currentLifeTime = 0;

    void ConfigureSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Start()
    {
        if (accelerate)
        {
            ConfigureSpeed(speed + ((float)GameData.Score/10));
        }
    }

    void Update()
    {
        ChekLifeTime();
        MovePosition();
    }
    
    void MovePosition()
    {
        transform.position += (direction == Direction.Up ? Vector3.up : Vector3.down) * (speed * Time.deltaTime);
    }

    void ChekLifeTime()
    {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public enum Direction
    {
        Up, Down
    }
}
