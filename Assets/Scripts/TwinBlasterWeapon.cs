using UnityEngine;
using System.Collections;
using System;

public class TwinBlasterWeapon : IWeapon
{
    public GameObject mProjectilePrefab;

    public TwinBlasterWeapon(GameObject projectilePrefab)
    {
        mProjectilePrefab = projectilePrefab;
    }

    public void Fire(Vector2 position)
    {

        GameObject.Instantiate(mProjectilePrefab, position + new Vector2(-0.1f, 0f), Quaternion.identity);
        GameObject.Instantiate(mProjectilePrefab, position + new Vector2(0.1f, 0f), Quaternion.identity);
    }
}
