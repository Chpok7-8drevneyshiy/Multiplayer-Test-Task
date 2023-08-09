using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    public GameObject Player;
    public float MinX, MinY, MaxX, MaxY;


    private void Start()
    {
        Vector2 randomPosition = new Vector2( Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        PhotonNetwork.Instantiate(Player.name, randomPosition, Quaternion.identity);
    }
}
