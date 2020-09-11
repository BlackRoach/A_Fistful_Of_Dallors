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


    // public Rigidbody rigidbody;
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
        //rigidbody = this.gameObject.GetComponent<Rigidbody>();
        characterController = this.gameObject.GetComponent<CharacterController>();
        playerState.Init(this, playerIdle);

        cameraTrans = Camera.main.transform;
    }
    public void Update()
    {
        playerState.Update();
        var rotation = 
            new Quaternion(0, cameraTrans.localRotation.y, 0, cameraTrans.localRotation.w);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            rotation, 5f * Time.deltaTime);
    }
}
