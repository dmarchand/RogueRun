using UnityEngine;
using System.Collections;

public class EnemyFallController : MonoBehaviour {

    public float fallSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - fallSpeed, this.transform.position.z);
	}
}
