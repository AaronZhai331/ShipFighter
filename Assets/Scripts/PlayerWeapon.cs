using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public Transform Weapon;

    public GameObject Bullet;

    public float BlastForce = 10;

    
    public void Shoot()
    {
       GameObject projectile = Instantiate(Bullet, Weapon.position, Weapon.rotation);

        projectile.GetComponent<Rigidbody2D>().AddForce(Weapon.up * BlastForce, ForceMode2D.Impulse);
    }

}
