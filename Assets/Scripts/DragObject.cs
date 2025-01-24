using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DragObject", menuName = "ScriptableObjects/DragObject")]
public class DragObject : ScriptableObject
{
    public GameObject Prefab;
    public string itemName;

    public int itemScore;

    private const string itemPurchaseKey = "ItemPurchased::";

    //saving bool to playerprefs
    public bool IsPurchased
    {
        get { return PlayerPrefs.GetInt(itemPurchaseKey + itemName, 0) == 1; }
        set { PlayerPrefs.SetInt(itemPurchaseKey + itemName, value ? 1 : 0); }
    }




}
   
    
