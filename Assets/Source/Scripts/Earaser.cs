using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earaser : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.GetComponent<Target>())
        {
            other.transform.GetComponent<Target>().Delete();
        }
    }
}
