using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BallBoost : PowerUp
{
    public int BallBoostSpeed;

    public override void Execute(Ball b)
    {
        b.BallBoostSpeed = BallBoostSpeed;
        b.UpdateVelocity();
        
    }
}
