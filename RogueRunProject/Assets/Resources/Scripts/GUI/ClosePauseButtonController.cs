using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClosePauseButtonController : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		GameObject.Find ("Main Camera").GetComponent<GameController>().Unpause();
	}

}
