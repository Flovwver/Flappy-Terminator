using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Inputer))]
public class Player : MonoBehaviour
{
    private Mover _mover;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _handler;
    private Inputer _inputer;

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
