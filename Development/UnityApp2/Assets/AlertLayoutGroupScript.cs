using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertLayoutGroupScript : MonoBehaviour 
{
    public float AlertDelay = 2f;

    [SerializeField]
    private GameObject _alertListingPrefab;
    private GameObject AlertListingPrefab
    {
        get { return _alertListingPrefab; }
    }

    private List<AlertListing> _alertListings = new List<AlertListing>();
    private List<AlertListing> AlertListings
    {
        get { return _alertListings; }
    }

    private void Start()
    {
        StaticAlertManager.alertManager = this;
    }

    public void LogAlert()
    {
        MainCanvasManager.Instance.AlertPanelCanvas.transform.SetAsFirstSibling();
        AlertTriggered();

    }


    public void AlertTriggered()
    {
        AlertDelay -= Time.deltaTime;
        if (AlertDelay <= 0f)
        {
            GameObject alertListingObj = Instantiate(AlertListingPrefab);
            alertListingObj.transform.SetParent(transform, false);
            AlertListing alertListing = alertListingObj.GetComponent<AlertListing>();
            AlertListings.Add(alertListing);
            AlertDelay = 2f;
        }
    }

}
