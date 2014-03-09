using UnityEngine;
using System.Collections;

public class SpearTrapController : MonoBehaviour {

	public int DamageDealt;
	
	private PurchasableItemController _purchasableItem;
	
	// Use this for initialization
	void Start () {
		_purchasableItem = gameObject.GetComponent<PurchasableItemController>();
		DungeonController dungeon = GameObject.Find("Main Camera").GetComponent<GameController>().ActiveDungeon;
		DamageDealt = Random.Range(dungeon.TrapDetails.TrapMinDamage, dungeon.TrapDetails.TrapMaxDamage);
	}
	
	// Update is called once per frame
	void Update () {
		if (_purchasableItem.IsPurchased)
		{
			GameObject.Find("Player").GetComponent<PlayerController>().RecoverHealth(-DamageDealt);
			_purchasableItem.LogPurchase(@"You triggered a spear trap!\nYou take " + DamageDealt + " damage!");
			Destroy(gameObject);    
		}
	}
}
