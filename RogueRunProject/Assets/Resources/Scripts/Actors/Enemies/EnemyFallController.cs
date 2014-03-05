using UnityEngine;
using System.Collections;

public class EnemyFallController : MonoBehaviour {

    public float fallSpeed;
	GameController _gameController;

	// Use this for initialization
	void Start () {
		_gameController = GameObject.Find("Main Camera").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(_gameController.IsPaused) 
		{
			return;
		}

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallSpeed, this.transform.position.z);

        CheckBounds();
	}

    void CheckBounds()
    {
        if (this.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
