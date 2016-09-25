using System;
using ExtrasensoryGame;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public SpiritMode SpiritMode { get { return this._mode as SpiritMode; } }

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
        return new WaitClientMode();
    }

    private IMode GetNextMode(IMode mode)
    {
        if (mode is WaitClientMode)
            return new ClientMode(ResourceManager.GetNextClient(), clientPrefab);
        if (mode is ClientMode)
        {
            var clientMode = (ClientMode)mode;
            var rnd = new System.Random();
            if (rnd.Next(0, 2) == 0)
                return new SpiritMode(
                    clientMode.Client,
                    ResourceManager.GetRandomSpirit(),
                    _uiManager.ClientPanel,
                    _uiManager.Cupboard,
                    _uiManager.RageSlider);
            else
				return new FoolMode(clientMode.Client, _uiManager.GlobeCollider, _uiManager.AstrologyPanel);
        }
        if (mode is SpiritMode)
            return new WaitClientMode();
        throw new NotImplementedException();
    }
}