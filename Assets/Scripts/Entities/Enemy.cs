using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour, ITouchDamager, IRemovable
{
    [SerializeField] private bool _isShoot = true;
    [SerializeField] private float _shootInterval = 1f;
    
    private Shooter _shooter;

    public event Action<IRemovable> OnRemove;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {
        StartCoroutine(ShootRoutine());
    }

    public void Remove()
    {
        OnRemove?.Invoke(this);
    }

    public void SetBulletSpawner(BulletSpawner bulletSpawner)
    {
        _shooter.SetBulletSpawner(bulletSpawner);
    }

    private IEnumerator ShootRoutine()
    {
        while (_isShoot && enabled)
        {
            _shooter.Shoot(transform.up);
            yield return new WaitForSeconds(_shootInterval);
        }
    }
}
