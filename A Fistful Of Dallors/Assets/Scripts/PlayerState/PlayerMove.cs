using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : IState<PlayerFacade>
{
    private float horizontal;
    private float vertical;

  
    public void Enter(PlayerFacade target)
    {
        PlayerFacade.Instance.animator.SetBool("Walking", true);
    }
    public void Exit(PlayerFacade target)
    {
        PlayerFacade.Instance.animator.SetBool("Walking", false);
    }
    public void HandleInput(PlayerFacade target)
    {
        var player = PlayerFacade.Instance;
        if (horizontal != 0 || vertical != 0)
            return;
        else
            player.playerState.ChangeState(PlayerFacade.playerIdle);

       

    }
    public void Update(PlayerFacade target)
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        var player = PlayerFacade.Instance;
        var dir = new Vector3(horizontal, 0, vertical);
        dir = player.transform.TransformDirection(dir) * 5f;

        player.characterController.Move(dir * Time.deltaTime);
        var temp = player.cameraTrans.localRotation;
        var rotation = new Quaternion(0, temp.y, 0, temp.w);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation,
            rotation, 5f * Time.deltaTime);
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }

}

public class PlayerMoveAimed : PlayerMove
{

}

