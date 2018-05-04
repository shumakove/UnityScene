﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour {

    void OnGUI() {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> items = Managers.Inventory.GetItemList();
        if(items.Count == 0 ) {
            GUI.Box(new Rect(posX, posY, width, height), "No items");
        } 

        foreach(string item in items) {
            int count = Managers.Inventory.GetItemCount(item);

            Texture2D image = Resources.Load<Texture2D>("Icons/" + item);
            GUI.Box(new Rect(posX, posY, width, height),
                      new GUIContent("(" + count + ")", image));
            posX += width + buffer;
        }

        string equipped = Managers.Inventory.equippedItem;
        if(equipped != null) {
            posX = Screen.width - (width + buffer);
            Texture2D image = Resources.Load("Icons/" + equipped) as Texture2D;
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("Equiped", image));

        }

        posX = 10;
        posY += height + buffer;

        foreach(string item in items) {
            if(GUI.Button(new Rect(posX,posY,width,height),"Equip " + item)) {
                Managers.Inventory.EquipItem(item);
            }
            posX += width + buffer;
        }
    }
}
