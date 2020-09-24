using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerIdle : IState<PlayerFacade>
{

    public void Enter(PlayerFacade target)
    {
       
            target.animator.SetBool("Foward", false);
      
    }
    public void Exit(PlayerFacade target)
    {
       
            target.animator.SetBool("Foward", true);
     
    }
    public void HandleInput(PlayerFacade target)
    {
      
        if (target.Horizontal == 0 && target.Vertical == 0)
            return;
        else
            target.playerState.ChangeState(PlayerFacade.playerMove);
    }
    public void Update(PlayerFacade target)
    {
        
    
       
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }

}

