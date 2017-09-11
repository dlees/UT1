using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListLoader : MonoBehaviour {

	public GameObject ContentPanel;
	public GameObject ListItemPrefab;
	public MenuListProvider menuListProvider;
	public MenuItemSelector menuItemSelector;

	public void loadMenu () {
		foreach (Transform child in ContentPanel.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		List<string> listItems = menuListProvider.getItems();

		foreach (string itemString in listItems) {
			GameObject newListItem = Instantiate(ListItemPrefab) as GameObject;

			MenuItemController menuItemController = newListItem.GetComponent<MenuItemController>();
			menuItemController.itemName = itemString;
			menuItemController.selector = menuItemSelector;

			newListItem.transform.SetParent (ContentPanel.transform);
			newListItem.transform.localScale = Vector3.one;

		}
	}

}
