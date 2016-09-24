using UnityEngine;

public class ModeManager : MonoBehaviour
{
    private IMode _mode;

    void Start()
    {
        this.SetMode(this.GetStartMode());
    }

    void Update()
    {
        _mode.Update();
    }

    private void SetMode(IMode mode)
    {
        if (_mode != null)
            _mode.Deinit();
        _mode = mode;
        _mode.Init();
    }

    private IMode GetStartMode()
    {
        return new GhostMode();
    }
}