using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public int DamageMin;
    public int DamageMax;

    [HideInInspector]
    public int Damage;


    public int Gold;
    public int StaminaReward;


    // Use this for initialization
    void Start()
    {
        Damage = Random.Range(DamageMin, DamageMax);
    }

    void Update()
    {
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