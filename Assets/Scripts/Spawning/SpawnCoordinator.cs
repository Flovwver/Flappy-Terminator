using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
[RequireComponent(typeof(ScoreZoneSpawner))]
[RequireComponent(typeof(BulletSpawner))]
public class SpawnCoordinator : MonoBehaviour
{
    [SerializeField] private float _delay;

    private EnemySpawner _enemySpawner;
    private ScoreZoneSpawner _scoreZoneSpawner;
    private BulletSpawner _bulletSpawner;

    private void Awake()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
        _scoreZoneSpawner = GetComponent<ScoreZoneSpawner>();
        _bulletSpawner = GetComponent<BulletSpawner>();
    }

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    public void Reset()
    {
        StopAllCoroutines();
        StartCoroutine(GenerateEnemies());
        //_enemySpawner.Reset();
        //_scoreZoneSpawner.Reset();
    }

    private IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled) 
        {
            _enemySpawner.SpawnGroup(transform.position, _bulletSpawner);
            _scoreZoneSpawner.Spawn(transform.position);
            yield return wait;
        }
    }
}
