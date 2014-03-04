using UnityEngine;
using System.Collections;

public class WeaponAreaController : MonoBehaviour
{

    private PlayerController _player;

    [SerializeField]
    private float _animationTime;

    public float AnimationTime
    {
        get
        {
            return _animationTime;
        }

        set
        {
            _animationTime = value;
        }

    }

    private bool _isAnimating;
    private float _animatedTime;

    // Use this for initialization
    void Start()
    {
        _player = this.transform.parent.GetComponent<PlayerController>();
        this.renderer.enabled = false;
        _animatedTime = 0;
        _isAnimating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAnimating)
        {
            _animatedTime += Time.deltaTime;

            if (_animatedTime >= _animationTime)
            {
                _isAnimating = false;
                this.renderer.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (!enemy)
        {
            return;
        }


        Destroy(other.gameObject);
        _player.AttackEnemy(enemy.Damage, enemy.StaminaReward);
        _player.Gold += enemy.Gold;

        this.renderer.enabled = true;
        this._isAnimating = true;
        this._animatedTime = 0;

    }
}