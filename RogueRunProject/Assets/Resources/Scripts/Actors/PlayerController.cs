using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    [HideInInspector]
    public Vector3 mPos;
    public float moveSpeed;

    private LogController _logController;

    #region Vitals

    public float StaminaDrainRate;

    private float _currentHp;

    public float CurrentHp
    {

        get
        {
            return _currentHp;
        }

        set
        {
            _currentHp = value;
        }
    }

    private float _maxHp;

    public float MaxHp
    {

        get
        {
            return _maxHp;
        }

        set
        {
            _maxHp = value;
        }
    }

    [SerializeField]
    [HideInInspector]
    private float _hpPercentage;

    public float HpPercentage
    {

        get
        {
            _hpPercentage = CurrentHp / MaxHp;
            return _hpPercentage;
        }

        private set
        {
            _hpPercentage = value;
        }
    }

    private float _currentStamina;

    public float CurrentStamina
    {

        get
        {
            return _currentStamina;
        }

        set
        {
            _currentStamina = value;
        }
    }

    private float _maxStamina;

    public float MaxStamina
    {

        get
        {
            return _maxStamina;
        }

        set
        {
            _maxStamina = value;
        }
    }

    [SerializeField]
    [HideInInspector]
    private float _staminaPercentage;

    public float StaminaPercentage
    {

        get
        {
            _staminaPercentage = CurrentStamina / MaxStamina;
            return _staminaPercentage;
        }

        private set
        {
            _staminaPercentage = value;
        }
    }

    #endregion


    #region "Other Stats"

    private int _baseAttackPower;

    public int AttackPower
    {
        get
        {
            return _baseAttackPower; // other mods go here eventually
        }
    }

    public int Gold;
    public int CurrentXP;
    public int XPToNextLevel;
    public int CurrentLevel;

    [SerializeField]
    public string XpDisplay
    {
        get
        {
            return "XP: " + CurrentXP + " / " + XPToNextLevel;
        }
    }

    #endregion

    private ScreenFlashController _screenFlashController;
	private GameController _gameController;

	public IList<PurchasableItemController> Inventory;

    void Start()
    {
        // Debug
        _currentHp = _maxHp = 100;
        _currentStamina = _maxStamina = 100;
        _baseAttackPower = 5;
        Gold = 0;
        XPToNextLevel = 30;
        CurrentLevel = 1;

        _screenFlashController = GameObject.Find("FlashEffect").GetComponent<ScreenFlashController>();
		_gameController = GameObject.Find("Main Camera").GetComponent<GameController>();
		Inventory = new List<PurchasableItemController>();
        _logController = GameObject.Find("LogDisplayLabel").GetComponent<LogController>();
    }

    void HandleInputs()
    {


        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxis("Horizontal");
            int direction = h < 0 ? -1 : 1;
            float currentSpeed = moveSpeed * direction;
            MoveHorizontal(transform.position.x + currentSpeed);

        }
        //else if (Input.GetButton("Fire1"))
        //{
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MoveHorizontal(mousePos.x);
        //}

    }

    void MoveHorizontal(float xPos)
    {
        Vector3 newPosition = new Vector3();
        newPosition.Set(xPos, transform.position.y, transform.position.z);

        if (newPosition.x < -2.7)
        {
            newPosition.Set(-2.6f, transform.position.y, transform.position.z);
        }
        else if (newPosition.x > 2.55)
        {
            newPosition.Set(2.55f, transform.position.y, transform.position.z);
        }

        transform.position = newPosition;
    }

    void FixedUpdate()
    {
		if(_gameController.IsPaused) 
		{
			return;
		}
        HandleInputs();
        HandleVitals();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        
    }

    void HandleVitals()
    {
        if (CurrentStamina >= 0)
        {
            CurrentStamina -= StaminaDrainRate;
        }
        else
        {
            CurrentHp -= StaminaDrainRate;
        }

        if (this.CurrentHp <= 0)
        {
            Die();
        }

    }

    public void AttackEnemy(EnemyController enemy)
    {
        string logMessage = "You defeated " + enemy.DisplayName + ". ";
        logMessage += "+" + enemy.GoldReward + " coins!";
        if (this.AttackPower < enemy.Damage)
        {
            this.CurrentHp -= enemy.Damage;
            _screenFlashController.FlashScreen(Color.red, 5);
            logMessage += "\nBut you took " + enemy.Damage + " damage!";

        }

        CurrentXP += enemy.Damage;
        CurrentStamina = Mathf.Min(CurrentStamina + enemy.StaminaReward, MaxStamina);


        

        if (CurrentXP >= XPToNextLevel)
        {
            LevelUp();
        }
        _logController.AppendLine(logMessage);
    }

    public void RecoverStamina(int amount)
    {
        CurrentStamina = Mathf.Min(CurrentStamina + amount, MaxStamina);
    }

	public void RecoverHealth(int amount)
	{
		CurrentHp = Mathf.Min(CurrentHp + amount, MaxHp);
	}

    void LevelUp()
    {
        XPToNextLevel += (int)(XPToNextLevel * (1.1 + CurrentLevel / 3));
        _screenFlashController.FlashScreen(Color.white, 5);

        _baseAttackPower += 1;
        MaxHp += 5;
        //CurrentHp = MaxHp;
        CurrentLevel++;
    }

    void Die()
    {
        Application.LoadLevel(0);
    }
}