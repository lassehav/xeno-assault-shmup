using UnityEngine;
using System.Collections;

public class WeaponPowerUp : MonoBehaviour {

    public WeaponPowerUps weapon;

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<PlayerWeaponManager>().AddWeapon(weapon);
            Destroy(gameObject);            
        }
    }
}
