using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StringMenuItemSelector : MenuItemSelector
{
    public string selectedString = null;

    public override void selectItem(string selectedItem)
    {
        selectedString = selectedItem;
    }

}
