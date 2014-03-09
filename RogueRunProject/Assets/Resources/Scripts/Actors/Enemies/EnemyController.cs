using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public int DamageMin;
    public int DamageMax;

    [HideInInspector]
    public int Damage;


    public int BaseGold;
    public int StaminaReward;

    public string DisplayName;

	[HideInInspector]
	public int GoldReward 
	{
		get
		{
			return BaseGold + Damage;
		}
	}


    // Use this for initialization
    void Start()
    {
        Damage = Random.Range(DamageMin, DamageMax);
    }

    void Update()
    {

    }


}