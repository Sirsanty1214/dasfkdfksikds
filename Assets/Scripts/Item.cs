using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Item", menuName = "AR/Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public string ItemDescription;
    public GameObject Item3DModel;
}