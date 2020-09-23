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

    
    public CharacterController characterController;
   
    public Transform cameraTrans;

    static readonly public PlayerIdle playerIdle = new PlayerIdle();
    static readonly public PlayerMove playerMove = new PlayerMove();
    public StateMachine<PlayerFacade> playerState;


    public override void Init()
    {
        base.Init();
        playerState = new StateMachine<PlayerFacade>();
        animator = this.gameObject.GetComponent<Animator>();
        characterController = this.gameObject.GetComponent<CharacterController>();
        playerState.Init(this, playerIdle);

        cameraTrans = Camera.main.transform;
    }
    public void Update()
    {
        playerState.Update();
    
    }
}
