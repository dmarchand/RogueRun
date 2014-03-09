using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour {

	public GameObject TrapEffect;

	[HideInInspector]
	public PurchasableItemController TrapItemController;

	// Use this for initialization
	void Start () {
		TrapItemController = ((GameObject)Instantiate(TrapEffect)).GetComponent<PurchasableItemController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
