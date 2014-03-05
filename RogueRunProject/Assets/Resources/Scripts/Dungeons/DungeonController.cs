using UnityEngine;
using System.Collections;

public class DungeonController : MonoBehaviour {


    private LaneManagerController _laneManager;

    public EntitySpawnInformation[] Entities;
    public ShopSlotInformation[] ShopItems;

    public float MinimumSpawnTime;
    public float MaximumSpawnTime;

    private float _nextSpawnTime;
    private float _elapsedTime;

    private GameController _gameController;

	// Use this for initialization
	void Start () {
        _laneManager = GameObject.Find("LaneManager").GetComponent<LaneManagerController>();
        _gameController = GameObject.Find("Main Camera").GetComponent<GameController>();
        SetNextSpawnTime();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawns();
	}

    void SetNextSpawnTime()
    {
        _nextSpawnTime = Random.RandomRange(MinimumSpawnTime, MaximumSpawnTime);
        _elapsedTime = 0;
    }

    void UpdateSpawns()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _nextSpawnTime)
        {

            GameObject entityToSpawn = GetEntityToSpawn();
            LaneController laneToSpawnIn = GetLaneToSpawnIn();
            Instantiate(entityToSpawn, laneToSpawnIn.transform.position, Quaternion.identity);

            SetNextSpawnTime();
        }
    }

    LaneController GetLaneToSpawnIn()
    {
        return _laneManager.lanes[Random.Range(0, _laneManager.lanes.Count)];
    }

    GameObject GetEntityToSpawn()
    {

        int roll = Random.Range(0, 100);

        int cumulative = 0;
        for (int i = 0; i < Entities.Length; i++)
        {
            cumulative += Entities[i].SpawnChance;
            if (roll < cumulative)
            {
                return Entities[i].Entity;
            }
        }

        throw new System.Exception("Probabilities for spawning entity didn't add up...");
    }

    public void GenerateShop()
    {
        ShopItemInformation[] rolledShopItems = new ShopItemInformation[4];

        for (int i = 0; i < ShopItems.Length; i++)
        {
            int roll = Random.Range(0, 100);
            int cumulative = 0;
            ShopItemInformation[] slotItems = ShopItems[i].ShopSlotItems;
            for (int q = 0; i < slotItems.Length; q++)
            {
                cumulative += slotItems[q].SpawnChance;
                if (roll < cumulative)
                {
                    rolledShopItems[ShopItems[i].Slot] = slotItems[q];
                    break;
                }
            }
        }

        _gameController.DisplayShop(rolledShopItems);
    }

    [System.Serializable]
    public class EntitySpawnInformation
    {
        public GameObject Entity;
        public int SpawnChance;
    }

    [System.Serializable]
    public class ShopSlotInformation
    {
        public ShopItemInformation[] ShopSlotItems;
        public int Slot;
    }

    [System.Serializable]
    public class ShopItemInformation
    {
        public int SpawnChance;
        public GameObject ShopItemPrefab;
    }
}
