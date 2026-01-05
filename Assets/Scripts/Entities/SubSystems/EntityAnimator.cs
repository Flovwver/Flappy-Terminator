using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EntityAnimator : MonoBehaviour
{
    private readonly string _isAttack = "IsAttack";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartAttackAnimation()
    {
        _animator.SetBool(_isAttack, true);
    }

    public void StopAttackAnimation()
    {
        _animator.SetBool(_isAttack, false);
    }
}
