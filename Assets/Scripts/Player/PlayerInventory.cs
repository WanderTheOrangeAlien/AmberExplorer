using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{

    public static PlayerInventory Instance;

    public Dictionary<string, int> ItemList;

    public int amberAmount;

    [TextArea]
    public string monitor;

    private static bool isEventListenerInitialized; //To prevent from subscribing more than one listener to the event

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

    private void Start()
    {
        if(!isEventListenerInitialized)
        {
            isEventListenerInitialized = true;
            AmberComponent.OnAmberCollected += (AmberScriptableObject amberData) =>
            {
                Instance.AddItem(amberData.itemID, 1);
            };
        }
        
    }


    private void Update()
    {
        monitor = "";
        amberAmount = 0;

        //Sum up all the ambers and check if the amount is equal or greater thatn 5
        foreach (var item in ItemList)
        {
            monitor += $"{item.Key}: {item.Value} +\n";
            amberAmount += item.Value;
        }

        if (amberAmount >= 5 && !GameManager.Instance.isGameOver)
        {
            TimerController.StopTimer();
            GameManager.Instance.GameOver(GameOverCause.AmberCollected);
            
        }
    }


    public void AddItem(string id, int amount)
    {
        if (!GameManager.Instance.ItemExists(id)) //Invalid ID
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
        if (ItemList.ContainsKey(id))
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


