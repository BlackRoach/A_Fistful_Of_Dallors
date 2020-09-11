using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerIdle : IState<PlayerFacade>
{
    private float horizontal;
    private float vertical;
    public void Enter(PlayerFacade target)
    {
        PlayerFacade.Instance.animator.SetBool("Walking", false);
    }
    public void Exit(PlayerFacade target)
    {
        PlayerFacade.Instance.animator.SetBool("Walking", true);
    }
    public void HandleInput(PlayerFacade target)
    {
        var player = PlayerFacade.Instance;
        if (horizontal == 0 && vertical == 0)
            return;
        else
            player.playerState.ChangeState(PlayerFacade.playerMove);
    }
    public void Update(PlayerFacade target)
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
       
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }

}

