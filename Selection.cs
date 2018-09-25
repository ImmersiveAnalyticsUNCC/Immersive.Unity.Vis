using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : List<Transform> {

    public string[] currentData = new string[0];

    List<D3Unity3D> selection = new List<D3Unity3D>();
    List<D3Unity3D> extraItems = new List<D3Unity3D>();
    List<string> extraData = new List<string>();

    public void SelectAll(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.GetComponent<D3Unity3D>() != null)
            {
                selection.Add(child.GetComponent<D3Unity3D>());
            }
        }
    }

    public List<D3Unity3D> GetSelection()
    {
        return selection;
    }

    public void BindData(string[] data)
    {
        // Clear old overflow lists
        extraItems = new List<D3Unity3D>();
        extraData = new List<string>();

        D3Unity3D[] selectionArray = selection.ToArray();
        // More selected items than data
        if (selectionArray.Length > data.Length)
        {
            for (int i = 0; i < data.Length; i ++)
            {
                selectionArray[i].data = data[i];
            }
            for (int i = data.Length; i < selectionArray.Length; i++)
            {
                extraItems.Add(selectionArray[i]);
            }
        }
        // More data than items
        else if (data.Length > selectionArray.Length)
        {
            for (int i = 0; i < selectionArray.Length; i++)
            {
                selectionArray[i].data = data[i];
            }
            for (int i = selectionArray.Length; i < data.Length; i++)
            {
                extraData.Add(data[i]);
            }
        }
        // Equal data and items
        else
        {
            for (int i = 0; i < data.Length; i++)
            {
                selectionArray[i].data = data[i];
            }
        }

        // Register that we've updated our data
        // Note: Need to do a clone here, otherwise we'll be pointing to the same array in memory, and will never update again
        currentData = (string[]) data.Clone();
    }
}
