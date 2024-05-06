using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    private float range = 100f;
    private float damage = 25f;
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            ZombieController enemy = hit.transform.GetComponent<ZombieController>();
            if (enemy != null)
            {
                enemy.Hit(damage);
            }
        }
    }
}
