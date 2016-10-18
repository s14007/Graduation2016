using UnityEngine;
using System.Collections;

public class GameSystemController : MonoBehaviour {
    private Player player;

    void Awake()
    {
        player = Player.Instance;
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Name :" + player.Name + " Level : " + player.Level);

        discoverItem(new Item("Armour"));

        printItem();

        discoverItem(new Item("Armour"));

        printItem();

        discoverItem(new Item("Exculiver"));

        printItem();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void printItem()
    {
        foreach (Item a in player.ItemList)
        {
            Debug.Log("ItemName : " + a.ItemName + " ItemQuantity : " + a.ItemQuantity);
        }
    }

    private void discoverItem(Item discoverItem)
    {
            player.addItem(discoverItem);          
    }
}
