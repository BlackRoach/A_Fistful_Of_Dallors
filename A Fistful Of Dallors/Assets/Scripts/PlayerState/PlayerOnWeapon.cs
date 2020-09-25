using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerOnWeapon : IState<PlayerFacade>
{
    private int equiped = -1;
    private readonly string[] Weapons = { "OnPistol", "OnRifle" };

    public void Enter(PlayerFacade target)
    {

    }
    public void Exit(PlayerFacade target)
    {


    }
    public void HandleInput(PlayerFacade target)
    {
        if (equiped != 0 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(target, 0);
       
        }
        else if (equiped != 1 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(target, 1);
        }
        else if(equiped != -1 && Input.GetKeyDown(KeyCode.X))
        {
            ChangeWeapon(target, -1);
        }

        if (Input.GetMouseButtonDown(1))
            target.playerEquip.ChangeState(PlayerFacade.playerAiming);
           
    }
    public void Update(PlayerFacade target)
    {
        
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }

    private void ChangeWeapon(PlayerFacade target, int num)
    {
        if(equiped > -1)
            target.animator.SetBool(Weapons[equiped], false);
        target.WeaponChange(num, equiped);
        equiped = num;
        if(equiped > -1)
            target.animator.SetBool(Weapons[equiped], true);
    }
}
