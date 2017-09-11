using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemController : MonoBehaviour {

	public Text itemText;
	public string itemName;
	public Button itemButton;
	public MenuItemSelector selector;

	void Update () {
		itemText.text = itemName;
	}

	public void disableButton()
	{
		itemButton.interactable = false;
	}

	public void selectItem()
	{
		selector.selectItem (itemName);
	}
}
