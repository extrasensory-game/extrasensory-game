using System;
using ExtrasensoryGame;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    private IMode _mode;
    public ClientGenerator ClientGenerator;
	public ResourceManager ResourceManager;
	[SerializeField]
	private UIManager _uiManager;
	[SerializeField]
	private Game _game;
	[SerializeField]
	private GameObject clientPrefab;

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
		_mode.Init(_game);
    }

    private IMode GetStartMode()
    {
        return new WaitClientMode(_uiManager.NextClientPanel);
    }

    private IMode GetNextMode(IMode mode)
    {
        if (mode is WaitClientMode)
            return new ClientMode();
        if (mode is ClientMode)
        {
            var rnd = new System.Random();
            if (rnd.Next(0, 2) == 0)
                return new SpiritMode(
                    ResourceManager.GetNextClient(),
                    ResourceManager.GetRandomSpirit(),
                    _uiManager.ClientPanel, clientPrefab);
            else
                return new FoolMode(ResourceManager.GetNextClient());
        }
        if (mode is SpiritMode)
            return new WaitClientMode(_uiManager.NextClientPanel);
        throw new NotImplementedException();
    }
}