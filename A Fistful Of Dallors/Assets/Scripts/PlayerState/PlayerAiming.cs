using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : IState<PlayerFacade>
{
    public void Enter(PlayerFacade target)
    {
        target.animator.SetBool("Aiming", true);
    }
    public void Exit(PlayerFacade target)
    {
        target.animator.SetBool("Aiming", false);

    }
    public void HandleInput(PlayerFacade target)
    {
        if (Input.GetMouseButtonDown(0))
            return;
        else if (Input.GetMouseButtonUp(1))
            target.playerEquip.ChangeState(PlayerFacade.playerOnWeapon);
    
            

    }
    public void Update(PlayerFacade target)
    {

    }
    public void FixedUpdate(PlayerFacade target)
    {

    }
}
