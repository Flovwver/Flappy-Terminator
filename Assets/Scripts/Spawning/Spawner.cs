using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IRemovable
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;

    private List<T> _actives;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: t => t.gameObject.SetActive(true),
            actionOnRelease: t => t.gameObject.SetActive(false),
            actionOnDestroy: t => Destroy(t),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 100);

        _actives = new List<T>();
    }

    public void Reset()
    {
        for (int i = _actives.Count - 1; i >= 0; i--)
        {
            _actives[i].Remove();
        }
    }

    public T Spawn(Vector3 spawnPoint)
    {
        var t = _pool.Get();
        t.transform.position = spawnPoint;
        t.OnRemove += OnRelease;

        _actives.Add(t);

        return t;
    }

    private void OnRelease(IRemovable t)
    {
        t.OnRemove -= OnRelease;
        _pool.Release((T)t);
    }
}
