using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate() 
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        Vector3 _input = new Vector3(GameManager.players[client.instance.id].transform.position.x, GameManager.players[client.instance.id].transform.position.y, GameManager.players[client.instance.id].transform.position.z);

        ClientSend.PlayerMovement(_input);
    }
}
