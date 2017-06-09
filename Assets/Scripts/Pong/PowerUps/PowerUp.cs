using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject
{
    public Sprite PowerUpImage;

    public abstract void Execute(Ball b);
}