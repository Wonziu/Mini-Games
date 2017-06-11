using UnityEngine;

public class PowerUpHolder : MonoBehaviour
{
    public PowerUp PowerUp;
    public bool isPowerUpActive;

    void OnTriggerEnter2D(Collider2D coll)
    {
        PowerUp.Execute(coll.GetComponent<Ball>());
        gameObject.SetActive(false);
        isPowerUpActive = false;
    }
}