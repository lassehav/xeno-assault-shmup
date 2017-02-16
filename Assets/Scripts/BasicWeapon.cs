using UnityEngine;

public class BasicWeapon : IWeapon {

    private GameObject mProjectilePrefab;

    public BasicWeapon(GameObject projectilePrefab)
    {
        mProjectilePrefab = projectilePrefab;
    }

    public void Fire(Vector2 position)
    {
        GameObject.Instantiate(mProjectilePrefab, position, Quaternion.identity);
    }
}
