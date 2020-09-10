using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float hp = 100;
    public float speed = 10;

}
public class PlayerFacade : MonoSingleton<PlayerFacade>
{
  
    public Animator animator;

  
    public Rigidbody rigidbody;

   
    public Camera camera;

    static readonly public PlayerIdle playerIdle = new PlayerIdle();
    static readonly public PlayerMove playerMove = new PlayerMove();
    public StateMachine<PlayerFacade> playerState;

  
    public override void Init()
    {
        base.Init();
        playerState = new StateMachine<PlayerFacade>();
        animator = this.gameObject.GetComponent<Animator>();
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        playerState.Init(this, playerIdle);
      
        camera = Camera.main;
    }
    public void Update()
    {
        playerState.Update();
    }
}
