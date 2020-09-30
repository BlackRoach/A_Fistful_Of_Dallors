using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponData
{
    public int damage;
    public int ammoCapacity;   // 용량
    public float fireDistance; // 사정거리
    public float timeBetFire;  // 발사 간격
    public float reloadTime;   // 재장전 시간

}
public abstract class Weapon : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }

    public Transform fireTransform; // 총구 위치

    public ParticleSystem flashEffect; // 총 발사 효과

    public WeaponData data;

    public int ammoRemain { get; private set; }
    public int magAmmo { get; private set; }

    private float lastFireTime;
    private State state;
    public void Fire()
    {
        if (state == State.Ready && Time.time > lastFireTime + data.timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }
    private void Shot()
    {
        RaycastHit hit;
        var hisPosition = Vector3.zero;
        
    }
    public void Reload()
    {
        if (state == State.Reloading || data.ammoCapacity == ammoRemain || ammoRemain == 0)
            return;
        state = State.Reloading;
        //start reloading
    }
    private IEnumerator ReloadRoutine()
    {
        yield return new WaitForSeconds(data.reloadTime);
    }
    public void OnWeapon()
    {
        this.gameObject.SetActive(true);
    }

    public void OffWeapon()
    {
        this.gameObject.SetActive(false);
    }

}
