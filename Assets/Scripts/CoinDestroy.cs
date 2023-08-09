using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class CoinDestroy : MonoBehaviourPun
{
    [PunRPC]
    private void DestroyCoin()
    {
        if (photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}

