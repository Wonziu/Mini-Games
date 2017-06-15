using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D hit)
    {
        gameObject.SetActive(false);
    }
}
