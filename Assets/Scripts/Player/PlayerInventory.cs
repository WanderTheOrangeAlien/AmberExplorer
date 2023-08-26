using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{

    public static PlayerInventory Instance;

    public Dictionary<string, int> ItemList;

    [TextArea]
    public string monitor;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        ItemList = new Dictionary<string, int>();

    }

    private void Update()
    {
        monitor = "";

        foreach (var item in ItemList)
        {
            monitor += $"{item.Key}: {item.Value} +\n";
        }
    }

    private void Start()
    {
        AmberComponent.OnAmberCollected += (AmberScriptableObject amberData) =>
        {         
            Instance.AddItem(amberData.itemID, 1);
        };
    }


    public void AddItem(string id, int amount)
    {
        if(!GameManager.Instance.ItemExists(id)) //Invalid ID
        {
            Debug.LogError($"{id} is an invalid item ID");
            return;
        }

        if (!ItemList.ContainsKey(id)) //The Item hasnt been added
        {
            ItemList.Add(id, amount);
            Debug.Log($"Added new Item id:{id}, amount:{amount}");
        }
        else //The Item is already in the inventory
        {
            ItemList[id] += amount;
            Debug.Log($"Added Item id:{id}, amount:{amount}. Current amount: {ItemList[id]}");
        }
        
    }

    public Item GetItemInfo(string id)
    {
        if(ItemList.ContainsKey(id))
        {
            return GameManager.Instance.GameItems.Find(x => x.id == id);
        }
        else
        {
            Debug.LogError($"{id} is an invalid item ID");
            return null;
        }
    }

}

public struct ItemStack
{
    string id;
    int amount;
}


