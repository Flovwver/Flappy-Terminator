using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
[RequireComponent(typeof(CollisionHandler))]
public class Enemy : MonoBehaviour, ITouchDamager, IRemovable
{
    [SerializeField] private bool _isShoot = true;
    [SerializeField] private float _shootInterval = 1f;
    
    private Shooter _shooter;
    private CollisionHandler _handler;
    private Coroutine _shootRoutine;

    public event Action<IRemovable> OnRemove;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _handler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _shootRoutine = StartCoroutine(ShootRoutine());
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Remove()
    {
        if (_shootRoutine == null)
        {
            StopCoroutine(_shootRoutine);
            _shootRoutine = null;
        }    

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
            yield return new WaitForSeconds(_shootInterval);
            _shooter.Shoot(transform.up);
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is ITouchDamager)
        {
            Remove();
        }
    }
}
