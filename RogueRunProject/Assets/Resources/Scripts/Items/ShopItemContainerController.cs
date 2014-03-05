using UnityEngine;
using System.Collections;

public class ShopItemContainerController : MonoBehaviour {

    public dfSprite DisplaySprite;
    public dfLabel ItemCostLabel;
    public dfLabel ItemDescriptionLabel;
    public dfLabel ItemNameLabel;

	public PurchasableItemController AttachedItemPrefab;

	// Use this for initialization
	void Start () {
        DisplaySprite = transform.Find("ShopDisplaySprite").GetComponent<dfSprite>();
        ItemCostLabel = transform.Find("ItemCostLabel").GetComponent<dfLabel>();
        ItemDescriptionLabel = transform.Find("ItemDescriptionLabel").GetComponent<dfLabel>();
        ItemNameLabel = transform.Find("ItemNameLabel").GetComponent<dfLabel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

		if(player.Gold >= AttachedItemPrefab.Price) 
		{
			player.Gold -= AttachedItemPrefab.Price;
			GameObject attachedItemObject = (GameObject)Instantiate(AttachedItemPrefab.gameObject);
			PurchasableItemController purchasedInstance = attachedItemObject.GetComponent<PurchasableItemController>();
			purchasedInstance.IsPurchased = true;

			if(!purchasedInstance.IsInstantOneTimeUse) 
			{
				player.Inventory.Add(purchasedInstance);
			}

			GameObject.Find ("Main Camera").GetComponent<GameController>().CloseShop();
		}
	}
}
