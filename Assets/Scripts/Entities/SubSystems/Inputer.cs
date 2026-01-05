using UnityEngine;

public class Inputer : MonoBehaviour
{
    private bool _isDash;
    private bool _isAttack;

    public bool IsAttack => _isAttack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isDash = true;

        if (Input.GetKeyDown(KeyCode.LeftControl))
            _isAttack = true;
        else if (Input.GetKeyUp(KeyCode.LeftControl))
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
