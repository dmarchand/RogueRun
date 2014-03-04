using UnityEngine;
using System.Collections;

public class TextMeshLayerController : MonoBehaviour {

    public string LayerName;

	// Use this for initialization
	void Start () {
        renderer.sortingLayerName = LayerName;
        renderer.sortingOrder = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
