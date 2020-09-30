using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public bool onRifle { get; private set; }
    public bool onPistol { get; private set; }
    public bool onShotgun { get; private set; }
    public bool downWeapon { get; private set; }
    public bool run { get; private set; }
    public bool aim { get; private set; }
    public bool fire { get; private set; }
    public bool aimOff { get; private set; }

    public void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        onPistol = Input.GetKeyDown(KeyCode.Alpha1);
        onRifle = Input.GetKeyDown(KeyCode.Alpha2);
        onShotgun = Input.GetKeyDown(KeyCode.Alpha3);
        downWeapon = Input.GetKeyDown(KeyCode.X);
        run = Input.GetKeyDown(KeyCode.LeftShift);
        aim = Input.GetMouseButtonDown(1);
        aimOff = Input.GetMouseButtonUp(1);
        fire = Input.GetMouseButtonDown(0);
       
    }
}
