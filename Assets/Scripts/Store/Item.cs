using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Store/Item", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _icon;
}