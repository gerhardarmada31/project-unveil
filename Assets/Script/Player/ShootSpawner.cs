using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpawner : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] private Transform spawnTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Shoot()
    {
        GameObject bulletTransform = Instantiate(projectile, spawnTransform.position, spawnTransform.rotation);
    }

    private void OnDestroy()
    {
    }
}
