using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBehavior : StateMachineBehaviour
{
    //public HeroStates behaviorState;
    //public AudioClip soundEffect;

    public float horizontalForce;
    public float verticalForce;

    protected Player_info fighter;
    protected Player player;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (fighter == null)
        {
            fighter = animator.gameObject.GetComponent<Player_info>();
            player = animator.gameObject.GetComponent<Player>();
        }
        player.sword.SetActive(true);

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
            fighter.Body.AddRelativeForce(new Vector3(horizontalForce * -1, 0, 0));
        }
    }
    override public void OnStateExit(Animator animator,
                                          AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.sword.SetActive(false);
    }

}
