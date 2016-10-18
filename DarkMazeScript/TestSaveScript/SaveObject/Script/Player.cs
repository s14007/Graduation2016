using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
    private static Player m_instance;

    private string name;
    private int level;
    private CalculateExperiencePoint calcExp;
    private List<Item> items;

    Player()
    {
        name = "主人公";
        level = 1;
        calcExp = CalculateExperiencePoint.Instance;
        items = new List<Item>();
    }

    public static Player Instance
    {
        get
        {
            if (m_instance == null) m_instance = new Player();
            return m_instance;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    //アイテムリストを返す
    public List<Item> ItemList
    {
        get
        {
            return items;
        }
    }

    //アイテムをプレイヤーのアイテムリストに追加
    public void addItem(Item addItem)
    {
        if(!wasDiscover(addItem.ItemName)) items.Add(addItem);
    }

    //プレイヤーがアイテムをすでに発見しているかどうか
    public bool wasDiscover(string name)
    {
        foreach(Item item in items)
        {
            if (item.ItemName == name)
            {
                Debug.Log(name + " は、既に発見されているアイテムなので、数量を追加します。");
                //発見されているのでアイテム数量を増やす
                item.addItemQuantity();
                return true;
            }
        }

        return false;
    }
}


public class CalculateExperiencePoint {
    private static CalculateExperiencePoint m_instance;

    private Player player;
    private double totalExp;
    private double currentNextLevelExp;
    private double nextLevelExp;
    private double magnification;

    CalculateExperiencePoint()
    {
        nextLevelExp = 15000000000.0d;
        magnification = 1.004d;
        Debug.Log(nextLevelExp);
        toExpNextLevel(795);
    }

    public static CalculateExperiencePoint Instance
    {
        get
        {
            if (m_instance == null) m_instance = new CalculateExperiencePoint();
            return m_instance;
        }
    }

    public void toExpNextLevel(int currentLevel)
    {
        double defaultExp = 237.9950752 * magnification;
        double defaultLevel = (double)currentLevel * 13;
        Debug.Log(defaultExp);
        Debug.Log(defaultLevel);

        nextLevelExp = (defaultExp * defaultLevel) / 2;
        currentNextLevelExp = nextLevelExp;
        Debug.Log(nextLevelExp);
    }
}
