using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour 
{

    public static MainCanvasManager Instance;

    [SerializeField]
    private DevicePanelCanvas _lobbyCanvas;
    public DevicePanelCanvas LobbyCanvas
    {
        get { return _lobbyCanvas; }
    }

    [SerializeField]
    private HostDashboardCanvas _hostDashboardCanvas;
    public HostDashboardCanvas HostDashboardCanvas
    {
        get { return _hostDashboardCanvas; }
    }

	private void Awake () 
    {
        Instance = this;
	}
}
