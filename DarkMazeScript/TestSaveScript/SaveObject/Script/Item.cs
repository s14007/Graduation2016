using UnityEngine;
using System.Collections;

public class Item
{
    private string itemName;
    private int itemQuantity;

    public Item(string name)
    {
        itemName = name;
        itemQuantity = 1;
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    public int ItemQuantity
    {
        get
        {
            return itemQuantity;
        }

        set
        {
            itemQuantity = value;
        }
    }

    public void addItemQuantity()
    {
        itemQuantity += 1;
    }
}
