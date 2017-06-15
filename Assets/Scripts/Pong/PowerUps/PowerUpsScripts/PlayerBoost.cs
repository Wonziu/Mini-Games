using UnityEngine;

[CreateAssetMenu]
public class PlayerBoost : PowerUp
{
    public float PlayerBoostSpeed;

    public override void Execute(Ball b)
    {
        b.LastPlayerHit.PlayerBoostSpeed = PlayerBoostSpeed;
    }
}