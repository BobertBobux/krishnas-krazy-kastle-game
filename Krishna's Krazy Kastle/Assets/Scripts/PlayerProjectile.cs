using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject Player;
    private PlayerCharacter playerCharacter;

    private Vector3 locationOfTarget;
    
    void Start()
    {
        Debug.Log("I have spawned");
        Player = GameObject.Find("Player");
        playerCharacter = Player.GetComponent<PlayerCharacter>();
        locationOfTarget = playerCharacter.projectileTarget();

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, locationOfTarget, Time.deltaTime * 5);
        Destroy(gameObject, 3);


    }
}
