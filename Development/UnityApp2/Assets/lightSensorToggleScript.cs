using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSensorToggleScript : MonoBehaviour {

 
    public AlertLayoutGroupScript _alertList;

    private void Start()
    {
        _alertList.AlertTriggered();
    }

}
