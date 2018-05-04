using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public string equippedItem { get; private set; }

    private Dictionary<string,int> _items;
    public ManagerStatus status { 
        get;
        private set;
    }

    public void Startup() {
        Debug.Log("Inventory manager starting ...");
        status = ManagerStatus.Started;
        _items = new Dictionary<string,int>();
    }

    public void DisplayItems() {
        string displayedItems = "Items: ";
        foreach(KeyValuePair<string,int> item in _items) {
            displayedItems += item.Key + "(" + item.Value + ")";
        }
        Debug.Log(displayedItems);
    }

    public void AddItem(string name) {
        if(_items.ContainsKey(name)) {
            _items[name] += 1;
        } else {
            _items[name] = 1;
        }
    
        DisplayItems();
    }

    public List<string> GetItemList() {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name) {
        if(_items.ContainsKey(name)) {
            return _items[name];
        }
        return 0;
    }

    public bool EquipItem(string name) {
        if(_items.ContainsKey(name) && equippedItem != name) {
            equippedItem = name;
            Debug.Log("Equipped " + name);
            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped ");
        return false;
    }
}