using System;
using ExtrasensoryGame;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    private IMode _mode;
    public ClientGenerator ClientGenerator;
    public ResourceManager ResourceManager;
    [SerializeField]
    private GameObject _uiManager;

    void Start()
    {
        this.SetMode(this.GetStartMode());
    }

    void Update()
    {
        _mode.Update();
        if (_mode.IsFinished())
        {
            this.SetMode(this.GetNextMode(_mode));
        }
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
        return new WaitClientMode(_uiManager.GetComponent<UIManager>().NextClientPanel);
    }

    private IMode GetNextMode(IMode mode)
    {
        if (mode is WaitClientMode)
            return new SpiritMode(ClientGenerator.GetClient(), ResourceManager.GetRandomSpirit(),
                _uiManager.GetComponent<UIManager>().ClientPanel);
        else if (mode is SpiritMode)
            return new EndMode(_uiManager.GetComponent<UIManager>().RestartPanel);
        throw new NotImplementedException();
    }
}