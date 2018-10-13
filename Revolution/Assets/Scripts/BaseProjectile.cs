using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    public float speed = 3.0f;

    public abstract void FireProjectile(GameObject launcher, GameObject target, float damage, float attackspeed);


}
