using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float val = 0;

    private int point = 0;
    private int total = 5;
    private void Start()
    {
        total = transform.childCount;
        point = 0;
    }

    public void Delete()
    {
        if (point < total)
        {
            transform.GetChild(point).gameObject.SetActive(false);
            point++;
            if (point >= total)
            {
                GameManager.Instance.CheckLevelUp();
            }
        }
    }
}
