using UnityEngine;
using System.Collections;

public class PurchasableItemController : MonoBehaviour {

    public bool IsInstantOneTimeUse;

    public int Price;
    public string DisplayName;
    public string SpriteName;
    public string Description;

    [HideInInspector]
    public bool IsPurchased;

    public bool IsTrap;

    private LogController _logController;

	// Use this for initialization
	void Start () {
        _logController = GameObject.Find("LogDisplayLabel").GetComponent<LogController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LogPurchase(string message)
    {
        _logController.AppendLine(message);
    }
}
