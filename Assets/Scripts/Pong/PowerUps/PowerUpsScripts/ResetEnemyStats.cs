using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ResetEnemyStats : PowerUp
{
    public override void Execute(Ball b)
    {
        var e = b.LastPlayerHit.Enemy;

        e.transform.localScale = e.PlayerScale;
        e.PlayerBoostSpeed = 1;
    }
}
