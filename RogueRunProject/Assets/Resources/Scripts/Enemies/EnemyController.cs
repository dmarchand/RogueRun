using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private float _damage;

    public float Damage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }

    }
    public float gold;


    // Use this for initialization
    void Start()
    {

    }
}