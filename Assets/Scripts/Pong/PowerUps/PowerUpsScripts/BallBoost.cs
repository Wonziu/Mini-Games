using UnityEngine;

[CreateAssetMenu]
public class BallBoost : PowerUp
{
    public float BallBoostSpeed;

    public override void Execute(Ball b)
    {
        b.BallBoostSpeed = BallBoostSpeed;
        b.UpdateVelocity();       
    }
}