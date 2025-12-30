using UnityEngine;

public sealed class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private float _distanceBetweenEnemies;
    [SerializeField] private float _spawnAngle;

    public void SpawnGroup(Vector3 spawnPosition, BulletSpawner bulletSpawner)
    {
        int skippedEnemy = Random.Range(0, _enemiesCount);

        for (int i = 0; i < _enemiesCount; i++)
        {
            if (i == skippedEnemy)
                continue;

            Vector3 spawnRotation = new(0f, 0f, _spawnAngle);
            Vector3 spawnPoint = spawnPosition;
            spawnPoint.y = _lowerBound;
            spawnPoint.y += _distanceBetweenEnemies * i;

            var enemy = Spawn(spawnPoint);

            enemy.transform.rotation = Quaternion.Euler(spawnRotation);

            enemy.SetBulletSpawner(bulletSpawner);
        }
    }
}
