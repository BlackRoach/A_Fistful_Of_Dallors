﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : IState<PlayerFacade>
{
    public void Enter(PlayerFacade target)
    {

        target.animator.SetBool("Move", true);


    }
    public void Exit(PlayerFacade target)
    {
       
        target.animator.SetBool("Move", false);

      
        
    }
    public void HandleInput(PlayerFacade target)
    {
        if (target.input.Horizontal != 0 || target.input.Vertical != 0)
            return;
        else
            target.playerState.ChangeState(PlayerFacade.playerIdle);

       

    }
    public void Update(PlayerFacade target)
    {
        
        //Move
        var dir = new Vector3(target.input.Horizontal, 0, target.input.Vertical);
        dir = target.transform.TransformDirection(dir) * 5f;
        target.characterController.Move(dir * Time.deltaTime);

        //Rotate
        var temp = target.cameraTrans.localRotation;
        var rotation = new Quaternion(0, temp.y, 0, temp.w);
        target.transform.rotation = Quaternion.Slerp(target.transform.rotation,
            rotation, 5f * Time.deltaTime);
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }
    public void LateUpdate(PlayerFacade target)
    {

    }
}

public class PlayerMoveAimed : PlayerMove
{

}

