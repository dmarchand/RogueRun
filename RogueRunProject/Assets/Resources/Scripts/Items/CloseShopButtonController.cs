using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloseShopButtonController : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		GameObject.Find ("Main Camera").GetComponent<GameController>().CloseShop();
	}

}
