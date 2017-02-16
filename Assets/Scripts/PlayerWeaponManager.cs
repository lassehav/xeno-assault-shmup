using UnityEngine;
using System.Collections.Generic;


public class PlayerWeaponManager : MonoBehaviour {

    private List<IWeapon> activeWeapons;
    public AudioSource fireSound;
    public AudioSource weaponPowerUpSound;

    public GameObject BasicProjectilePrefab;
    public GameObject VBlasterProjectilePrefab;
    public GameObject TwinBlasterProjectilePrefab;

    // Use this for initialization
    void Start () {
        activeWeapons = new List<IWeapon> {
            new BasicWeapon(BasicProjectilePrefab),            
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireSound.Play();
            foreach (var w in activeWeapons)
            {
                w.Fire(transform.position);                
            }            
        }
    }

    public void AddWeapon(WeaponPowerUps weaponToAdd)
    {
        activeWeapons.Clear();

        weaponPowerUpSound.Play();

        switch(weaponToAdd)
        {
            case WeaponPowerUps.VBlaster:
                activeWeapons.Add(new VBlasterWeapon(VBlasterProjectilePrefab));
                break;
            case WeaponPowerUps.TwinBlaster:                
                activeWeapons.Add(new TwinBlasterWeapon(TwinBlasterProjectilePrefab));
                break;
            case WeaponPowerUps.VTripleBlaster:
                activeWeapons.Add(new VBlasterWeapon(VBlasterProjectilePrefab));
                activeWeapons.Add(new BasicWeapon(BasicProjectilePrefab));
                break;
            case WeaponPowerUps.TripleBlaster:
                activeWeapons.Add(new TwinBlasterWeapon(TwinBlasterProjectilePrefab));
                activeWeapons.Add(new BasicWeapon(BasicProjectilePrefab));                    
                break;
        }        
    }
}