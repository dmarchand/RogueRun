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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
