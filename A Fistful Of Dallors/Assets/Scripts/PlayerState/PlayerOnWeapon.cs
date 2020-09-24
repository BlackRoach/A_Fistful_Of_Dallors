using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnWeapon : IState<PlayerFacade>
{
  
    public void Enter(PlayerFacade target)
    {

        PlayerFacade.Instance.animator.SetBool("Foward", true);


    }
    public void Exit(PlayerFacade target)
    {

        PlayerFacade.Instance.animator.SetBool("Foward", false);



    }
    public void HandleInput(PlayerFacade target)
    {
       switch(target.eqipState)
        {
            case WeaponType.None:
                break;
            case WeaponType.Pistol:
                break;
            case WeaponType.Rifle:
                break;
            default:
                break;
        }

    }
    public void Update(PlayerFacade target)
    {
       
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }
}
