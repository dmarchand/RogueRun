using UnityEngine;
using System.Collections;

public class EnemyPowerDisplayController : MonoBehaviour {

    EnemyController _parentEnemy;
    TextMesh _textMesh;
    PlayerController _player;

	// Use this for initialization
	void Start () {
        _parentEnemy = transform.parent.gameObject.GetComponent<EnemyController>();
        _textMesh = this.GetComponent<TextMesh>();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        _textMesh.text = _parentEnemy.Damage.ToString();

        if (_player.AttackPower < _parentEnemy.Damage)
        {
            _textMesh.color = Color.red;
        }
	}
}
