using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Transform muzzle;
    public Bullet bullet;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;

    float nextShotTime;

    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
            newBullet.SetSpeed(muzzleVelocity);
        }

        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
