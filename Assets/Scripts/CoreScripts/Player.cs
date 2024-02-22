using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] byte _maxHealth;
    private Camera _camera;
    private byte _health = 3;

    public Action<int> OnHealthChanged;

    public byte Health {
        get => _health;
        private set { 
            _health = value;
            if (_health > _maxHealth) _health = _maxHealth;
            if (OnHealthChanged != null) OnHealthChanged.Invoke(_health);
        }
    }
    
    void Start()
    {
        _health = _maxHealth;
        _camera = Camera.main;
        GameData.Score = 0;
        GameData.Stars = 0;
        GameData.HasFreeSpin = false;
    }

    void Update()
    {
        SetPlayerPosByVector3(GetFingerPosition());
    }

    private void FixedUpdate()
    {
        GameData.Score = (int)Time.timeSinceLevelLoad;
    }

    Vector3 GetFingerPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider != null)
                return hit.point;
        }

        return Vector3.zero;
    }

    void SetPlayerPosByVector3(Vector3 inputPos)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = inputPos.x;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Enemy")){
            DealDamage();
        }else if (collision.gameObject.CompareTag("SmallHeal")){
            Heal(1);
        }else if (collision.gameObject.CompareTag("Diamond")) {
            GameData.Stars += 10;
        }else if (collision.gameObject.CompareTag("Star")) {
            GameData.Stars += 1;
        }else if (collision.gameObject.CompareTag("BonusSpin")) {
            GameData.HasFreeSpin = true;
        }
    }

    void DealDamage()
    {   
        Health--;

        if(_health == 0)
        {
            GetComponent<AppNavigationTool>().LoadScene(2);// ����� ��� �������� ������������, �� ��� ������� ������ �������� ����� ��� ���������
        }
    }

    void Heal(byte value)
    {
        Health += value;
    }
}

