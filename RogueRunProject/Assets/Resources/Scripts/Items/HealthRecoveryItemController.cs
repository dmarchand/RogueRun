using UnityEngine;
using System.Collections;

public class HealthRecoveryItemController : MonoBehaviour {
	
	public int HealthRecovered;
	
	private PurchasableItemController _purchasableItem;
	
	// Use this for initialization
	void Start () {
		_purchasableItem = gameObject.GetComponent<PurchasableItemController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_purchasableItem.IsPurchased)
		{
			GameObject.Find("Player").GetComponent<PlayerController>().RecoverHealth(HealthRecovered);
			Destroy(gameObject);
		}
	}
}
