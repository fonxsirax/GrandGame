using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkNinja : StateMachineBehaviour
{
    private Ninja player;
    override public void OnStateEnter(Animator animator,
                                          AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.gameObject.GetComponent<Ninja>();
        }
        player.sword.SetActive(true);

    }

    override public void OnStateExit(Animator animator,
                                          AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.sword.SetActive(false);
    }
}
