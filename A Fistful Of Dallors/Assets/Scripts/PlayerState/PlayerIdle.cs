using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerIdle : IState<PlayerFacade>
{

    public void Enter(PlayerFacade target)
    {
       
            target.animator.SetBool("Move", false);
      
    }
    public void Exit(PlayerFacade target)
    {
       
            target.animator.SetBool("Move", true);
     
    }
    public void HandleInput(PlayerFacade target)
    {
      
        if (target.input.Horizontal == 0 && target.input.Vertical == 0)
            return;
        else
            target.playerState.ChangeState(PlayerFacade.playerMove);
    }
    public void Update(PlayerFacade target)
    {
        
    
       
    }
    public void LateUpdate(PlayerFacade target)
    {

    }
    public void FixedUpdate(PlayerFacade target)
    {

    }

}

