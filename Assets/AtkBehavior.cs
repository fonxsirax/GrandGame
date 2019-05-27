using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBehavior : StateMachineBehaviour
{
    private Player player;
    override public void OnStateEnter(Animator animator,
                                          AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
        {
            player = animator.gameObject.GetComponent<Player>();
        }
        player.sword.SetActive(true);

    }

    override public void OnStateExit(Animator animator,
                                          AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.sword.SetActive(false);
    }
}
