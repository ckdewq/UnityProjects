using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    Gun equippedGun;
    public Transform gunHold;
    public Gun startingGun;

	// Use this for initialization
	void Start () {
		if(startingGun != null)
        {
            EquipGun(startingGun);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipGun(Gun gunToEquip)
    {   if(equippedGun !=null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, gunHold.position, gunHold.rotation) as Gun;
        equippedGun.transform.parent = gunHold;
    }

    public void Shoot()
    {
        if(equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
