using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Quaternion rotate = Quaternion.identity;
    public Vector3 forward  = Vector3.zero;

    private void FixedUpdate()
    {
        if(rotate != GameManager.players[client.instance.id].transform.rotation || forward != GameManager.players[client.instance.id].transform.forward || Input.GetKey(KeyCode.UpArrow))
        {
            SendInputToServer();
        }
        rotate = GameManager.players[client.instance.id].transform.rotation;
        forward = GameManager.players[client.instance.id].transform.forward;
    }

    private void SendInputToServer()
    {   
        Vector3 _input = new Vector3(GameManager.players[client.instance.id].transform.position.x, GameManager.players[client.instance.id].transform.position.y, GameManager.players[client.instance.id].transform.position.z);
        
        ClientSend.PlayerMovement(_input);
            
        
    }
}
