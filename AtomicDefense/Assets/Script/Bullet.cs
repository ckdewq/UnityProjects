using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollision(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);        
     }
        
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void CheckCollision(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamagable damageableObject = hit.collider.GetComponent<IDamagable>();
        if(damageableObject!=null)
        {
            damageableObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }
}
