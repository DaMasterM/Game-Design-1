using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    protected UnityStandardAssets._2D.PlatformerCharacter2D playerBrain;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        StartClimbing(other.gameObject);
    }
    
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        StopClimbing(other.gameObject);
    }

    private void StartClimbing(GameObject player)
    {
        //Get a reference to the player
        playerBrain = player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ();

        if (playerBrain != null)
        {
            playerBrain.canClimb = true;
        }
    }

        private void StopClimbing(GameObject player)
    {
        //Get a reference to the player
        playerBrain = player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ();

        if (playerBrain != null)
        {
            playerBrain.canClimb = false;
            playerBrain.isClimbing = false;
            playerBrain.resetGravity();
        }
    }
}
