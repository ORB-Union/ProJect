using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public GameObject Explosion_Effect;

    public float Explosion_Radius = 5f;
    public float Explosion_Force = 700f;

    public float Explosion_Delay = 3f;
    private float countdown;

    bool HasExploded = false;

	// Use this for initialization
	void Start () {
        countdown = Explosion_Delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !HasExploded)
        {
            Explode();
            HasExploded = true;
        }
	}

    void Explode()
    {
        //Debug.Log("Boom!");
        //Show Effect
        Instantiate(Explosion_Effect, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, Explosion_Radius);

        
        //Damage
        foreach (Collider nearbyObject in collidersToDestroy)
        {
            Destroy(gameObject);
            //Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            //if (rb != null)
            //{
            //    //Add Force
            //    rb.AddExplosionForce(Explosion_Force, transform.position, Explosion_Radius);

            //}
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, Explosion_Radius);

        //Get nearby objects
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Add Force
                rb.AddExplosionForce(Explosion_Force, transform.position, Explosion_Radius);
                
            }
        }

        Destroy(gameObject);
    }
}
