using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] levels;

    private ShopWindowController _shopWindowController;
    public DungeonController ActiveDungeon;
    private dfPanel[] _shopItemContainers;
	public bool IsPaused;
	private LogController _logController;

    // Use this for initialization
    void Start()
    {
        _shopWindowController = GameObject.Find("ShopWindowPanel").GetComponent<ShopWindowController>();
        _shopItemContainers = new dfPanel[4];

        _shopItemContainers[0] = GameObject.Find("ShopItemContainer1").GetComponent<dfPanel>();
        _shopItemContainers[1] = GameObject.Find("ShopItemContainer2").GetComponent<dfPanel>();
        _shopItemContainers[2] = GameObject.Find("ShopItemContainer3").GetComponent<dfPanel>();
        _shopItemContainers[3] = GameObject.Find("ShopItemContainer4").GetComponent<dfPanel>();

		_logController = GameObject.Find("LogDisplayLabel").GetComponent<LogController>();

		IsPaused = false;

        // Debug force dungeon for now
		AdvanceToDungeon(Resources.Load<GameObject>("Prefabs/Dungeons/DebugDungeon"));
        //ActiveDungeon = ((GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Dungeons/DebugDungeon"))).GetComponent<DungeonController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void AdvanceToDungeon(GameObject dungeonPrefab) 
	{
		if(ActiveDungeon != null) 
		{
			ActiveDungeon.GenerateShop();
			Destroy(ActiveDungeon.gameObject);
		}

		GameObject spawnedDungeon = (GameObject)Instantiate(dungeonPrefab);
		ActiveDungeon = spawnedDungeon.GetComponent<DungeonController>();

		_logController.AppendLine("You entered Level " + ActiveDungeon.Depth);



	}

    public void DisplayShop(DungeonController.ShopItemInformation[] shopItems)
    {
        _shopWindowController.GetComponent<dfPanel>().IsVisible = true;

        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] == null)
            {
                _shopItemContainers[i].IsVisible = false;
                continue;
            }

            ShopItemContainerController shopItemContainer = _shopItemContainers[i].GetComponent<ShopItemContainerController>();

            PurchasableItemController itemInfo = shopItems[i].ShopItemPrefab.GetComponent<PurchasableItemController>();
            shopItemContainer.DisplaySprite.SpriteName = itemInfo.SpriteName;
            shopItemContainer.ItemNameLabel.Text = itemInfo.DisplayName;
            shopItemContainer.ItemDescriptionLabel.Text = itemInfo.Description;
            shopItemContainer.ItemCostLabel.Text = "Cost: " + itemInfo.Price;
			shopItemContainer.AttachedItemPrefab = itemInfo;
            _shopItemContainers[i].IsVisible = true;
            
        }

		IsPaused = true;
    }

    public void CloseShop()
    {
        _shopWindowController.GetComponent<dfPanel>().IsVisible = false;
		IsPaused = false;
    }
}