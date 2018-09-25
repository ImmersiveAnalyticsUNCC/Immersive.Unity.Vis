using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Bar : MonoBehaviour {

    public float animateSpeed = 1.0f;

    D3Unity3D d3u;

    private void Awake()
    {
        d3u = GetComponent<D3Unity3D>();
    }

    private void Update()
    {
        float dataPoint;
        if (float.TryParse(d3u.data, out dataPoint))
        {
            // Since the bar has to center, but the scale has to move the full value, I'm changing the y position at half the speed to synchronize
            // This makes the bar look stationary while growing and shrinking
            Vector3 targetPos = new Vector3(transform.position.x, transform.parent.position.y + (dataPoint / 2.0f), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, animateSpeed * Time.deltaTime * 0.5f);

            Vector3 targetScale = new Vector3(transform.localScale.x, dataPoint, transform.localScale.z);
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, animateSpeed * Time.deltaTime);
        }
    }
}
