using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollController : MonoBehaviour
{
    GameObject itemObject;

    static Dictionary<string, Dictionary<string, Sprite>> spriteMstDic
        = new Dictionary<string, Dictionary<string, Sprite>>();

    string atlasName = "item";
    string itemName = "item_";

    void Start()
    {
        itemObject = Resources.Load("Item") as GameObject;
        Image itemImage = itemObject.GetComponent<Image>();
        RectTransform itemRectTransform = itemObject.GetComponent<RectTransform>();
        Debug.Log(itemObject);

        loadSprite(atlasName);
       Debug.Log( getSprite(atlasName, "item_45"));

        //Texture texture = Resources.Load("Collections/item") as Texture;

         for (int i = 0; i < getLength(atlasName); i++)
         {
            itemImage.sprite = getSprite(atlasName, itemName + i);
            RectTransform item = GameObject.Instantiate(itemRectTransform) as RectTransform;
            item.SetParent(transform, false);

            // var item = GameObject.Instantiate(itemRectTransform) as RectTransform;
            // item.SetParent(transform, false);

            //var text = item.GetComponentInChildren<Text>();
            //text.text = "item:" + i.ToString();
        }
    }

    //読み込み;
    static void loadSprite(string atlasName)
    {
        if (spriteMstDic.ContainsKey(atlasName)) return;

        Sprite[] s = Resources.LoadAll<Sprite>(atlasName);
        int len = s.Length;
        Debug.Log("roadFileLength :" + len);
        if (len > 0)
        {

            Dictionary<string, Sprite> sDic = new Dictionary<string, Sprite>();

            for (int i = 0; i < len; i++)
            {
                sDic[s[i].name] = s[i];
            }
            spriteMstDic[atlasName] = sDic;

            Debug.Log(atlasName + "アトラスを読み込みました");
        }
    }

   public static Sprite getSprite(string atlasName, string spriteName)
    {
        //既に登録されているならそのまま返す;
        if (spriteMstDic.ContainsKey(atlasName))
        {
            Dictionary<string, Sprite> sDic = spriteMstDic[atlasName];
            if (sDic.ContainsKey(spriteName))
            {
                return sDic[spriteName];
            }
            else
            {
                Debug.Log(atlasName + "に" + spriteName + "は含まれていません");
                return null;
            }
        }
        else
        {
            // 読み込んでおく
            loadSprite(atlasName);
            //再度呼び出してみる;
            return getSprite(atlasName, spriteName);
        }
    }

    static int getLength(string atlasName)
    {
        Sprite[] sprite = Resources.LoadAll<Sprite>(atlasName);
        return sprite.Length;
    }
}
