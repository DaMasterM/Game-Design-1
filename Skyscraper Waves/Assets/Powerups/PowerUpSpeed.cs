using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PowerUpSpeed : PowerUp
{
    public float speed = 15f;
    public float duration = 5f;

    protected override void PowerUpPayload()  // Checklist item 1
    {
        base.PowerUpPayload();

        // Payload is to give some health bonus
        playerBrain.SetMaxSpeed(speed, false);      
    }

    protected override void PowerUpHasExpired ()     // Checklist item 2
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        playerBrain.SetMaxSpeed(speed, true);

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
