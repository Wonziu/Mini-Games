using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CreateShield : PowerUp
{
    public override void Execute(Ball b)
    {
        b.LastPlayerHit.EnableShield();
    }
}
