using UnityEngine;
using System.Collections;
using System;

public class BasicDamageTaker : MonoBehaviour, IDamageable, IKillable {

    public int hitPoints = 1;
    public int scoreValue = 1000;
    protected GameManager gm;
  
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Damage(int value)
    {
        hitPoints -= value;
        if(hitPoints <= 0)
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        gm.AddScore(scoreValue);
        ExplosionRandomizer ex = gameObject.GetComponent<ExplosionRandomizer>();
        if (ex != null)
        {
            ex.Explode();
        }
        
        Destroy(this.gameObject, 0.1f);
    }

}
