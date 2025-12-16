using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isJump;
    private bool _isInteract;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(ConstantsData.InputData.HORIZONTAL_AXIS);

        if (Input.GetKeyDown(KeyCode.W))
            _isJump = true;

        if (Input.GetKeyDown(KeyCode.F))
            _isInteract = true;
    }

    public bool GetIsJump() => GetBoolAsTrigger(ref _isJump);

    public bool GetIsInteract() => GetBoolAsTrigger(ref _isInteract);
    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
