using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _baseSpeed = 1f;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.SetPositionAndRotation(_startPosition, _maxRotation);
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    public void Dash()
    {
        _rigidbody2D.linearVelocity = new Vector2(_jumpSpeed, _tapForce) * _baseSpeed;
        transform.rotation = _maxRotation;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            Debug.LogWarning("Bullet's direction is equal zero");
            return;
        }

        direction.Normalize();
        _rigidbody2D.linearVelocity = direction * _baseSpeed;

        if (TryGetComponent(out Bullet _))
        {
            Debug.Log("Velocity set: " + _rigidbody2D.linearVelocity);
        }
    }
}
