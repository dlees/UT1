using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuListLoader : MonoBehaviour {

	public GameObject ContentPanel;
	public GameObject ListItemPrefab;
	public MenuListProvider menuListProvider;
	public StringMenuItemSelector menuItemSelector;

    public void loadMenu() {
        loadMenu(menuListProvider.getItems());
    }
    
	public void loadMenu (List<string> listItems) {
		foreach (Transform child in ContentPanel.transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		foreach (string itemString in listItems) {
			GameObject newListItem = Instantiate(ListItemPrefab) as GameObject;

			MenuItemController menuItemController = newListItem.GetComponent<MenuItemController>();
			menuItemController.itemName = itemString;
			menuItemController.selector = menuItemSelector;
            menuItemSelector.selectedString = null;

			newListItem.transform.SetParent (ContentPanel.transform);
			newListItem.transform.localScale = Vector3.one;

		}
	}

}
