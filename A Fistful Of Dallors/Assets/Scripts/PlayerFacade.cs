using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float hp = 100;
    public float speed = 10;

}
public enum WeaponType
{
    None,
    Pistol,
    Rifle,
    Shotgun
}
public class PlayerFacade : MonoSingleton<PlayerFacade>
{
    public Animator animator;

    
    public CharacterController characterController;
   
    public Transform cameraTrans;

    static readonly public PlayerIdle playerIdle = new PlayerIdle();
    static readonly public PlayerMove playerMove = new PlayerMove();
    static readonly public PlayerOnWeapon playerOnWeapon = new PlayerOnWeapon();
    public StateMachine<PlayerFacade> playerState;
    public StateMachine<PlayerFacade> playerEquip;

    public WeaponType eqipState;

    private float _horizontal;
    public float Horizontal { get { return _horizontal; } }

    private float _vertical;
    public float Vertical { get { return _vertical; } }

    public override void Init()
    {
        base.Init();

        playerState = new StateMachine<PlayerFacade>();
        playerEquip = new StateMachine<PlayerFacade>();

        animator = this.gameObject.GetComponent<Animator>();
        characterController = this.gameObject.GetComponent<CharacterController>();
        eqipState = WeaponType.None;
        _horizontal = 0;
        _vertical = 0;

        playerState.Init(this, playerIdle);
        playerEquip.Init(this, playerOnWeapon);
      
        cameraTrans = Camera.main.transform;
    }
    public void Update()
    {
        playerState.Update();
        playerEquip.Update();

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
}
