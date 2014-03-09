using UnityEngine;
using System.Collections;

public class WeaponAreaController : MonoBehaviour
{

    PlayerController _player;
    DungeonController _dungeon;
	GameController _gameController;

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
		_gameController = GameObject.Find("Main Camera").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
		_dungeon = _gameController.ActiveDungeon;
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

        TreasureChestController treasure = other.GetComponent<TreasureChestController>();
        if (treasure)
        {
            CollideWithTreasure(treasure);
            return;
        }

        ShopkeeperController shopkeeper = other.GetComponent<ShopkeeperController>();
        if (shopkeeper)
        {
            CollideWithShop(shopkeeper);
            return;
        }

		DungeonLevelChangeController levelChange = other.GetComponent<DungeonLevelChangeController>();
		if(levelChange)
		{
			CollideWithDungeonChange(levelChange);
			return;
		}

    }

	void CollideWithDungeonChange(DungeonLevelChangeController levelChange)
	{
		if(_dungeon.NextDungeon) 
		{
			_gameController.AdvanceToDungeon(_dungeon.NextDungeon);
		}

		Destroy(levelChange.gameObject);
	}

    void CollideWithTreasure(TreasureChestController treasure)
    {
        treasure.ItemReward.IsPurchased = true;
        _player.Inventory.Add(treasure.ItemReward);
        
        Destroy(treasure.gameObject);
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