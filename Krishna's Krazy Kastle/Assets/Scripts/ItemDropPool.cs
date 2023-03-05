using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropPool : MonoBehaviour
{
    public GameObject itemDropPrefab;
    public List<Item> itemList = new List<Item>();

    Item RollItemDrop()
    {
        int randomNumber = Random.Range(1, 101);
        List<Item> possibleItems = new List<Item>();
        foreach (Item item in itemList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Item droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;   
    }

    public void InstantiateItem(Vector3 spawnPosition)
    {
        Item droppedItem = RollItemDrop();
        if (droppedItem != null)
        {
            GameObject itemGameObject = Instantiate(itemDropPrefab, spawnPosition, Quaternion.identity);
            itemGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.itemSprite;
        }
    }
}
