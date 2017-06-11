using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public Sprite PowerUpImage;

    public abstract void Execute(Ball b);
}