using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Singleton<PlayerMove>, IState<PlayerFacade>
{
    private float horizontal;
    private float vertical;

    protected PlayerMove() { }
    static PlayerMove() { instance = new PlayerMove();  }
    public void Enter(PlayerFacade target)
    {
        PlayerFacade.Instance.animator_readonly.SetBool("", true);
    }
    public void Exit(PlayerFacade target)
    {
        PlayerFacade.Instance.animator_readonly.SetBool("", false);
    }
    public void HandleInput(PlayerFacade target)
    {

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

public class PlayerMoveAimed : PlayerMove
{

}

