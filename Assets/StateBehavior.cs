using UnityEngine;
using System.Collections;

public class StateBehavior : StateMachineBehaviour
{

    public HeroStates behaviorState;
    //public AudioClip soundEffect;

    public float horizontalForce;
    public float verticalForce;

    protected Ninja fighter;

    override public void OnStateEnter(Animator animator,
                                      AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter == null)
        {
            fighter = animator.gameObject.GetComponent<Ninja>();
        }

        fighter.currentState = behaviorState;

        //if (soundEffect != null)
        //{
        //    fighter.playSound(soundEffect);
        //}

        fighter.Body.AddRelativeForce(new Vector3(0, verticalForce, 0));
    }

    override public void OnStateUpdate(Animator animator,
                                       AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (behaviorState == HeroStates.Walk)
        //{
        //    if (!fighter.turnedLeft) {
        //        fighter.Body.AddRelativeForce(new Vector3(horizontalForce, 0, 0));
        //    }
        //    else {
        //        fighter.Body.AddRelativeForce(new Vector3(horizontalForce * (-1), 0, 0));
        //    }

        //}
        fighter.Body.AddRelativeForce(new Vector3(horizontalForce, 0, 0));
    }
}
