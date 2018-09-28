using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Wedge : MonoBehaviour {
    
    public string label = "";
    public bool expanded = false;
    public Color defaultColor;
    public float value = 0f;

    public void lookedAt()
    {
        Contract();
        transform.parent.GetComponent<ChemicalGraph>().valueText.text = "" + value;
        transform.parent.GetComponent<ChemicalGraph>().ContractMatchingWedges(label);
    }

    public void lookedAway()
    {
        Expand();
        transform.parent.GetComponent<ChemicalGraph>().ExpandMatchingWedges(label);
    }

    public void clicked()
    {
        string oldSelection = transform.parent.GetComponent<ChemicalGraph>().selectedLabel;

        transform.parent.GetComponent<ChemicalGraph>().selectedLabel = label;
        transform.parent.GetComponent<ChemicalGraph>().selectedValue = "" + value;
        if (transform.parent.GetComponent<ChemicalGraph>().sibling1.generated)
        {
            transform.parent.GetComponent<ChemicalGraph>().sibling1.selectedLabel = label;
        }
        if (transform.parent.GetComponent<ChemicalGraph>().sibling2.generated)
        {
            transform.parent.GetComponent<ChemicalGraph>().sibling2.selectedLabel = label;
        }
        transform.parent.GetComponent<ChemicalGraph>().UpdateHoverText();

        // Expand (deselect) the previous wedge if we'd seleceted one earlier
        if (oldSelection != "")
        {
            foreach(Transform childWedge in transform.parent.GetComponent<ChemicalGraph>().transform)
            {
                if (childWedge.name == "Wedge(Clone)")
                {
                    string childLabel = childWedge.GetComponent<Wedge>().label;
                    if (oldSelection.Equals(childLabel))
                    {
                        childWedge.transform.gameObject.GetComponent<Wedge>().Expand();
                        break;
                    }
                }
            }
            transform.parent.GetComponent<ChemicalGraph>().ExpandMatchingWedges(oldSelection);
        }
    }

    public void Contract()
    {
        if(transform.parent.GetComponent<ChemicalGraph>().selectedLabel != label)
        {
            GetComponent<Image>().color = new Color(0, 0, 1, 1);
            if (expanded == false)
            {
                transform.localScale = new Vector3(0.8f, 0.8f, 1);
                expanded = true;
            }
        }
    }

    public void Expand()
    {
        if (transform.parent.GetComponent<ChemicalGraph>().selectedLabel != label)
        {
            GetComponent<Image>().color = defaultColor;
            transform.localScale = new Vector3(1, 1, 1);
            expanded = false;
        }
    }
}
