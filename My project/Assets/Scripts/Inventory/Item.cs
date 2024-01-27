using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public Sprite sprite;

    public Item(int id, string name, Sprite sprite)
    {
        this.id = id;
        this.name = name;
        this.sprite = sprite;
    }
}
