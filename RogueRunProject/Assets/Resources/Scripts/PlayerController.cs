using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [HideInInspector]
    public Vector3 mPos;
    public float moveSpeed;

    #region HP

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

    #endregion






    void Start()
    {
        // Debug
        _currentHp = _maxHp = 100;
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
        else if (Input.GetButton("Fire1"))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MoveHorizontal(mousePos.x);
        }

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

        HandleInputs();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        
    }

    void ReceiveDamage(float damage)
    {

        this.CurrentHp -= damage;

        if (this.CurrentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Application.LoadLevel(0);
    }
}