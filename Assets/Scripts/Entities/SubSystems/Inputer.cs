using UnityEngine;

public class Inputer : MonoBehaviour
{
    private bool _isDash;
    private bool _isAttack;

    private readonly KeyCode _dashKey = KeyCode.Space;
    private readonly KeyCode _attackKey = KeyCode.LeftControl;

    public bool IsAttack => _isAttack;

    private void Update()
    {
        if (Input.GetKeyDown(_dashKey))
            _isDash = true;

        if (Input.GetKeyDown(_attackKey))
            _isAttack = true;
        else if (Input.GetKeyUp(_attackKey))
            _isAttack = false;
    }

    public bool GetIsDash() => GetBoolAsTrigger(ref _isDash);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
