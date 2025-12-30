using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Bullet : MonoBehaviour, ITouchDamager, IRemovable
{
    public event Action<IRemovable> OnRemove;
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public void SetMoveDirection(Vector3 direction)
    {
        _mover.SetMoveDirection(direction);
    }

    public void Remove()
    {
        OnRemove?.Invoke(this);
    }
}
