using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerBoost : PowerUp
{
    public int PlayerBoostSpeed;

    public override void Execute(Ball b)
    {
        b.LastPlayerHit.SpeedBoost += PlayerBoostSpeed;
    }
}
