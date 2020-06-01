using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();
        Debug.Log($"Message from server: {_msg}");
        client.instance.id = _myId;
        ClientSend.WelcomeReceived();
        Debug.Log("Get the welcome message");
        UIManager.instance.ConnectToServerUDP(((IPEndPoint)client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        if ((_id != client.instance.id))
        {
            Debug.Log($"UDP Message from server: {_id} and new position x:{ _position.x}");
            try
            {
                GameManager.players[_id].transform.position = _position; //client改位置
            }
            catch (KeyNotFoundException e)
            {
                // do nothing, since we have not spawn the client
                Debug.Log($"{e}");
            }
        }
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();
        try
        {
            GameManager.players[_id].transform.rotation = _rotation;
        }
        catch (KeyNotFoundException e)
        {
            Debug.Log($"{e}");
            // do nothing, since we have not spawn the client
        }
    }

}
