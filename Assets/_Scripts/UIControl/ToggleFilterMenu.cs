using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFilterMenu : MonoBehaviour
{
    [SerializeField] private GameObject filterMenu;

    public void ToggleMenu()
    {
        if (filterMenu == null) return;

        if (!filterMenu.activeSelf)
        {
            filterMenu.SetActive(true);
        }
        else
        {
            filterMenu.SetActive(false);
        }
    }
}
