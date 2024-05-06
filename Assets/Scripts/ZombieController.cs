using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent zombieAgent;
    private Animator zombieAnimator;
    private float damage = 20;
    [SerializeField]
    private float health = 100;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        zombieAgent = GetComponent<NavMeshAgent>();
        zombieAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        zombieAgent.destination = player.transform.position;
        if (zombieAgent.velocity.magnitude > 1)
        {
            zombieAnimator.SetBool("isRunning", true);
        }
        else
        {
            zombieAnimator.SetBool("isRunning", false);
        }
    }

    public void Hit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.enemiesAlive--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().Hit(damage);
        }
    }
}
