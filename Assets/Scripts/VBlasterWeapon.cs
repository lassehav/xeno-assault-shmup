using UnityEngine;
using System.Collections;
using System;

public class VBlasterWeapon : IWeapon
{
    public GameObject mProjectilePrefab;

    public VBlasterWeapon(GameObject projectilePrefab)
    {
        mProjectilePrefab = projectilePrefab;
    }

    public void Fire(Vector2 position)
    {
        GameObject.Instantiate(mProjectilePrefab, position, Quaternion.Euler(0f, 0f, -45f));
        GameObject.Instantiate(mProjectilePrefab, position, Quaternion.Euler(0f, 0f, 45f));
    }        
}
