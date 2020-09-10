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
    public readonly Animator animator_readonly;
    private Animator animator;

    public readonly Rigidbody rigidbody_readonly;
    private Rigidbody rigidbody;

    public StateMachine<PlayerFacade> playerState;

    public PlayerFacade()
    {
        animator_readonly = animator;
        rigidbody_readonly = rigidbody;
    }
    public override void Init()
    {
        base.Init();

        animator = this.gameObject.GetComponent<Animator>();
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        
    }
    public void Update()
    {

    }
}
