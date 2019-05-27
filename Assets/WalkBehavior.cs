using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehavior : StateMachineBehaviour
{
    public float horizontalForce;
    public float verticalForce;

    protected Player_info fighter;

    override public void OnStateEnter(Animator animator,
                                          AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter == null)
        {
            fighter = animator.gameObject.GetComponent<Player_info>();
        }
    }

    override public void OnStateUpdate(Animator animator,
                                       AnimatorStateInfo stateInfo, int layerIndex)
    {
            if (!fighter.turnedLeft)
            {
                fighter.Body.AddRelativeForce(new Vector3(horizontalForce, 0, 0));
            }
            else
            {
                fighter.Body.AddRelativeForce(new Vector3(horizontalForce * (-1), 0, 0));
            }
        //fighter.Body.AddRelativeForce(new Vector3(horizontalForce, 0, 0));
    }
}
