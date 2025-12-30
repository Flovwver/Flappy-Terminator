using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _target.position.x + _xOffset;
        transform.position = position;
    }
}
