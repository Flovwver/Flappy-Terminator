using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Inputer))]
[RequireComponent(typeof(EntityAnimator))]
[RequireComponent(typeof(Shooter))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _shootCooldown = 0.5f;

    private float _shootTimer = 0f;

    private Mover _mover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _handler;
    private Inputer _inputer;
    private EntityAnimator _entityAnimator;
    private Shooter _shooter;

    public event Action GameOver;

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<CollisionHandler>();
        _mover = GetComponent<Mover>();
        _inputer = GetComponent<Inputer>();
        _entityAnimator = GetComponent<EntityAnimator>();
        _shooter = GetComponent<Shooter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void FixedUpdate()
    {
        if (_inputer.GetIsDash())
        {
            _mover.Dash();
        }

        if (_inputer.IsAttack)
        {
            if (_shootTimer <= 0)
            {
                _shootTimer = _shootCooldown;
                _shooter.Shoot(transform.up);
            }

            _entityAnimator.StartAttackAnimation();
        }
        else
            _entityAnimator.StopAttackAnimation();
        

        if (_shootTimer > 0f)
        {
            _shootTimer -= Time.fixedDeltaTime;
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is ITouchDamager)
        {
            GameOver?.Invoke();
        }

        else if (interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }
}
