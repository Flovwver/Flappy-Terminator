using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _spawnOffset = 1f;
    [SerializeField] private BulletSpawner _bulletSpawner;

    public void Shoot(Vector3 direction)
    {
        if (_bulletSpawner == null)
        {
            Debug.LogWarning("BulletSpawner is not set for Shooter.");
            return;
        }

        direction.Normalize();

        var bulletPosition = transform.position + direction * _spawnOffset;

        var bullet = _bulletSpawner.Spawn(bulletPosition);

        bullet.SetMoveDirection(direction);
    }

    public void SetBulletSpawner(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }
}
