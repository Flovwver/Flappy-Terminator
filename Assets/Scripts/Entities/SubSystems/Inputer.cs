using UnityEngine;

public class Inputer : MonoBehaviour
{
    private bool _isDash;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isDash = true;
    }

    public bool GetIsDash() => GetBoolAsTrigger(ref _isDash);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
