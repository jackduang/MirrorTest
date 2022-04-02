using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class Move : NetworkBehaviour
{
    public float speed = 100;
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    [Client]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)&&isLocalPlayer)
        {
            cmd();
        }
    }
    
    [Command]
    void cmd()
    {
        myMove();
    }
    [ClientRpc]
    public void myMove()
    {

        transform.Translate(transform.forward * speed);
    }
}
