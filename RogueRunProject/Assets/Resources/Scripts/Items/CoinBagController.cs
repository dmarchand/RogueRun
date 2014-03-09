using UnityEngine;
using System.Collections;

public class CoinBagController : MonoBehaviour {

	public int CoinsObtained;
	
	private PurchasableItemController _purchasableItem;
	
	// Use this for initialization
	void Start () {
		_purchasableItem = gameObject.GetComponent<PurchasableItemController>();
		DungeonController dungeon = GameObject.Find("Main Camera").GetComponent<GameController>().ActiveDungeon;
		CoinsObtained = Random.Range(dungeon.CoinRewardRange.MinCoins, dungeon.CoinRewardRange.MaxCoins);
	}
	
	// Update is called once per frame
	void Update () {
		if (_purchasableItem.IsPurchased)
		{
			GameObject.Find("Player").GetComponent<PlayerController>().Gold += CoinsObtained;
			_purchasableItem.LogPurchase("You acquired a Coing Bag and found " + CoinsObtained + " coins!");
			Destroy(gameObject);    
		}
	}
}
