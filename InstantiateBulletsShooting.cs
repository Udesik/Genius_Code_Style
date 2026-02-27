using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private float _fireRate = 1f;

    private void Start()
    {
        StartCoroutine(ShootingRoutine());
    }

    private IEnumerator ShootingRoutine()
    {
        var wait = new WaitForSeconds(_fireRate);

        while (true)
        {
            if (_target != null)
            {
                Shoot();
            }
            
            yield return wait;
        }
    }

    private void Shoot()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.LookRotation(direction));
        
        if (bullet.TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = direction * bulletSpeed;
        }
    }
}