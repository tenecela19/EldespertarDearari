using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform PointToTeleport;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TeleportToRoom()
    {
        FindObjectOfType<AudioManager>().Play("PuertaAbierta");
        Player.transform.position = PointToTeleport.position;
    }

}
