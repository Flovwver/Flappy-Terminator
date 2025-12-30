using UnityEngine;

public sealed class BulletSpawner : Spawner<Bullet>
{
    public Bullet Spawn(Vector3 spawnPoint, Vector3 direction)
    {
        var bullet = Spawn(spawnPoint);

        return bullet;
    }
}
