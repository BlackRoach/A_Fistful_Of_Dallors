using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : IState<PlayerFacade>
{
    private Transform _spine; // 상체 트랜스폼

    public void Enter(PlayerFacade target)
    {
        target.animator.SetBool("Aiming", true);
        PlayerCamera.Instance.AimCamera(true);
        _spine = target.animator.GetBoneTransform(HumanBodyBones.Spine);
    }
    public void Exit(PlayerFacade target)
    {
        target.animator.SetBool("Aiming", false);
        PlayerCamera.Instance.AimCamera(false);
    }
    public void HandleInput(PlayerFacade target)
    {
        if (Input.GetMouseButtonDown(0))
            return;
        else if (Input.GetMouseButtonUp(1))
            target.playerEquip.ChangeState(PlayerFacade.playerOnWeapon);
    
            

    }
    
    public void Update(PlayerFacade target)
    {
        //Rotate
        //Rotate
        var temp = target.cameraTrans.localRotation;
        var rotation = new Quaternion(0, temp.y, 0, temp.w);
        target.transform.rotation = Quaternion.Slerp(target.transform.rotation,
            rotation, 5f * Time.deltaTime);
    }
    public void LateUpdate(PlayerFacade target)
    {
        var chestOffset = new Vector3(0, 140, -90);
        // 140 -100 라이플
        //155 -70 권총
        _spine.LookAt(target.aimTarget);

        _spine.rotation = _spine.rotation * Quaternion.Euler(chestOffset);
    }
    public void FixedUpdate(PlayerFacade target)
    {

    }
}
