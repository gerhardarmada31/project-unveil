using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    // [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float lifeSpan = 2f;

    private Rigidbody projRb;

    private void Awake()
    {
        projRb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void FixedUpdate()
    {
        projRb.AddForce(projRb.transform.forward * projectileSpeed);
    }
}
