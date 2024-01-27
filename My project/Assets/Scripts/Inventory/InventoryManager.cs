using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List <Item> _items;

    [SerializeField] private Transform _itemBar;
    [SerializeField] private GameObject _previewItem;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (_items == null)
                _items = new List <Item>();

            if (!CheckItem(other.GetComponent<LayingItem>().item.id))
                _items.Add(other.GetComponent<LayingItem>().item);
            Destroy(other.gameObject);
        }
    }

    public bool CheckItem(int id)
    {
        foreach (Item item in _items)
        {
            if (item.id == id)
            {
                return true;
            }
        }

        return false;
    }

    public void DestroyItem(int id)
    {
        foreach (Item item in _items)
        {
            if (item.id == id)
            {
                _items.Remove(item);
                return;
            }
        }
    }
    private void Start()
    {
        _items = new List <Item>();
    }
    private void Update()
    {
        foreach (Transform child in _itemBar)
        {
            Destroy(child.gameObject);
        }
        int x = 50, i = 0;
        foreach (Item item in _items)
        {
            GameObject clone = Instantiate(_previewItem, _itemBar);
            clone.transform.localPosition = new Vector3(x * i, 0, 0);
            clone.GetComponent<Image>().sprite = item.sprite; 
            i++;
        }
    }
}
