using System;
using UnityEngine;

public class ScoreZone : MonoBehaviour, IInteractable, IRemovable
{
    public event Action<IRemovable> OnRemove;

    public void Remove()
    {
        OnRemove?.Invoke(this);
    }
}
