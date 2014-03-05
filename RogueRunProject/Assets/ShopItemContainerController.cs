using UnityEngine;
using System.Collections;

public class ShopItemContainerController : MonoBehaviour {

    public dfSprite DisplaySprite;
    public dfLabel ItemCostLabel;
    public dfLabel ItemDescriptionLabel;
    public dfLabel ItemNameLabel;

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
}
