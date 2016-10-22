using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemDetailView : MonoBehaviour {
    private GameObject description;
    private Image itemImage;
    private Text textItemName;
    private Text textItemInformation;
    private Text textItemAttackPoint;
    private Text textItemDifensePoint;

    string atlasName = "item";

    // Use this for initialization
    void Start () {
        description = GameObject.Find("Description");
        itemImage = GameObject.Find("itemImage").GetComponent<Image>();
        textItemName = GameObject.Find("itemNameText").GetComponent<Text>();
        textItemInformation = GameObject.Find("itemInformationText").GetComponent<Text>();
        textItemAttackPoint = GameObject.Find("itemAttackPoint").GetComponent<Text>();
        textItemDifensePoint = GameObject.Find("itemDifensePoint").GetComponent<Text>();
        close();
	}
	
	// Update is called once per frame
	void Update () {
	    if (description.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            description.SetActive(false);
            Debug.Log("click!");
        }
	}

    public void display(string itemImagePath)
    {
        //spriteをScrollControllerに聞いてとってくる
        Sprite itemSprite = ScrollController.getSprite(atlasName, itemImagePath);
        //画像をセットする
        itemImage.sprite = itemSprite;
        //itemName
        textItemName.text = itemSprite.name;

        description.SetActive(true);
        
        //itemImage.enabled = true;
        //textItemName.enabled = true;
        //textItemInformation.enabled = true;
        //textItemAttackPoint.enabled = true;
        //textItemDifensePoint.enabled = true;
    }

    public void close()
    {
        description.SetActive(false);
        
        //itemImage.enabled = false;
        //textItemName.enabled = false;
        //textItemInformation.enabled = false;
        //textItemAttackPoint.enabled = false;
        //textItemDifensePoint.enabled = false;
    }
 }
