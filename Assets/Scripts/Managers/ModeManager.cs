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

    private int clientNumber = 0;

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
        {
            var nextClient = ResourceManager.GetNextClient();
            if (nextClient == null)
                return new EndMode(_uiManager.RestartPanel, _uiManager.Diablo);
            return new ClientMode(nextClient, clientPrefab, _uiManager.OpeningDoor);
        }
        if (mode is ClientMode)
        {
            var clientMode = (ClientMode)mode;
            ++clientNumber;
            if (clientNumber == 2)
                return new FoolMode(clientMode.Client, _uiManager.GlobeCollider, _uiManager.AstrologyPanel);
            else
                return new SpiritMode(clientMode.Client, ResourceManager.GetRandomSpirit(), _uiManager.ClientPanel,
                        _uiManager.Cupboard, _uiManager.RageSlider, _uiManager.ExtrasensoryEffect);
		}
		if (mode is SpiritMode) 
		{
			return new WaitClientMode ();
		}
		if (mode is FoolMode) 
		{
			return new WaitClientMode ();
		}
        throw new NotImplementedException();
    }
}