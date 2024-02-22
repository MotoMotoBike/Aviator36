using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float reloadTime;
    [SerializeField] bool isRandomStartDelay;
    float _currentReload = 0;

    private void Start()
    {
        if (isRandomStartDelay)
        {
            _currentReload = Random.Range(0, reloadTime);
        }
    }
    void Update()
    {
        _currentReload += Time.deltaTime;
        if (_currentReload > reloadTime)
        {
            _currentReload = 0;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
