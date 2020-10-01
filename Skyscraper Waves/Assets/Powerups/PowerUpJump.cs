using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PowerUpJump : PowerUp
{
    public float jumpForce = 1200f;
    public float duration = 5f;

    protected override void PowerUpPayload()  // Checklist item 1
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        playerBrain.SetMaxJumpForce(jumpForce, false);      
    }

    protected override void PowerUpHasExpired ()     // Checklist item 2
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        playerBrain.SetMaxJumpForce(jumpForce, true);

        base.PowerUpHasExpired ();
    }

    private void Update ()                            // Checklist item 3
    {
        if (powerUpState == PowerUpState.IsCollected)
        {
            duration -= Time.deltaTime;
            if (duration < 0)
            {
                PowerUpHasExpired ();
            }
        }
    }
}
