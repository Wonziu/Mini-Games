using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    public PowerUp PowerUp;

    void OnTriggerEnter2D(Collider2D coll)
    {
        PowerUp.Execute(coll.GetComponent<Ball>());
        gameObject.SetActive(false);
    }
}