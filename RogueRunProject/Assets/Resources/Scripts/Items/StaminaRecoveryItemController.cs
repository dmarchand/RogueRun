using UnityEngine;
using System.Collections;

public class StaminaRecoveryItemController : MonoBehaviour {

    public int StaminaRecovered;

    private PurchasableItemController _purchasableItem;

	// Use this for initialization
	void Start () {
        _purchasableItem = gameObject.GetComponent<PurchasableItemController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_purchasableItem.IsPurchased)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().RecoverStamina(StaminaRecovered);
            _purchasableItem.LogPurchase("You acquired a Stamina Potion and recovered " + StaminaRecovered + " stamina!");
            Destroy(gameObject);
        }
	}
}
