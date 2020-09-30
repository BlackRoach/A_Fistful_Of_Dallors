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

    public Transform aimTarget;

    [SerializeField]
    private GameObject[] weapons;
    #region Player State Object
    static readonly public PlayerIdle playerIdle = new PlayerIdle();
    static readonly public PlayerMove playerMove = new PlayerMove();
    static readonly public PlayerOnWeapon playerOnWeapon = new PlayerOnWeapon();
    static readonly public PlayerAiming playerAiming = new PlayerAiming();
    #endregion

    public StateMachine<PlayerFacade> playerState;
    public StateMachine<PlayerFacade> playerEquip;
    
    public InputManager input;
  
    public override void Init()
    {
        base.Init();
        input = new InputManager();

        playerState = new StateMachine<PlayerFacade>();
        playerEquip = new StateMachine<PlayerFacade>();
       

        animator = this.gameObject.GetComponent<Animator>();
        characterController = this.gameObject.GetComponent<CharacterController>();

       

        playerState.Init(this, playerIdle);
        playerEquip.Init(this, playerOnWeapon);
      
        cameraTrans = Camera.main.transform;
        aimTarget = Camera.main.transform.GetChild(0).transform;
    }
    public void Update()
    {
        input.Update();
        playerState.Update();
        playerEquip.Update();
    }
    public void LateUpdate()
    {
        playerEquip.LateUpdate();
    }
    public void WeaponChange(int num, int cur)          
    {
        if (cur > -1)
            weapons[cur].SetActive(false);

        if (num > -1)
            weapons[num].SetActive(true);

    }
}
