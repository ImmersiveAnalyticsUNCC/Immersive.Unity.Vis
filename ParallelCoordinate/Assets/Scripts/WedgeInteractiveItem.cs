using DataStarter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WedgeInteractiveItem : MonoBehaviour {
    
    [SerializeField] private VRInteractiveItem m_InteractiveItem;

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;
        m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }


    //Handle the Over event
    private void HandleOver()
    {
        GetComponent<Wedge>().lookedAt();
    }


    //Handle the Out event
    private void HandleOut()
    {
        GetComponent<Wedge>().lookedAway();
    }


    //Handle the Click event
    private void HandleClick()
    {
        Debug.Log("Show click wedge");
        GetComponent<Wedge>().clicked();
    }


    //Handle the DoubleClick event
    private void HandleDoubleClick()
    {
        Debug.Log("Show double click");
    }
}
