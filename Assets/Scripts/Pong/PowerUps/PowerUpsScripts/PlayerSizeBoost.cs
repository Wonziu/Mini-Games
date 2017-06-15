using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSizeBoost : PowerUp
{
    public float SizeBoost;

    public override void Execute(Ball b)
    {
        var scale = b.LastPlayerHit.transform.localScale;
        scale.x += SizeBoost;
        
        b.LastPlayerHit.transform.localScale = scale;
    }
}
