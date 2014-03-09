using UnityEngine;
using System.Collections;

public class WeaponAreaController : MonoBehaviour
{

    PlayerController _player;
    DungeonController _dungeon;

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
        _dungeon = GameObject.Find("Main Camera").GetComponent<GameController>().ActiveDungeon;
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
        if (enemy)
        {
            CollideWithEnemy(enemy);
            return;
        }

        ShopkeeperController shopkeeper = other.GetComponent<ShopkeeperController>();
        if (shopkeeper)
        {
            CollideWithShop(shopkeeper);
        }

    }

    void CollideWithShop(ShopkeeperController shopkeeper)
    {
        _dungeon = GameObject.Find("Main Camera").GetComponent<GameController>().ActiveDungeon;
        _dungeon.GenerateShop();

        Destroy(shopkeeper.gameObject);

        
    }

    void CollideWithEnemy(EnemyController enemy)
    {

        Destroy(enemy.gameObject);
        _player.AttackEnemy(enemy);
        _player.Gold += enemy.GoldReward;

        this.renderer.enabled = true;
        this._isAnimating = true;
        this._animatedTime = 0;
    }
}