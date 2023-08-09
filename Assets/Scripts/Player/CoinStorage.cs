using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class CoinStorage : MonoBehaviourPun
{
    [SerializeField] private TMP_Text coinCounter;
    private int coins;
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        coinCounter = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TMP_Text>();
        coinCounter.text = coins.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            if (view.IsMine)
            {
                coins++;
                coinCounter.text = coins.ToString();
                view.RPC("DestroyCoin", RpcTarget.All, other.GetComponent<PhotonView>().ViewID);
            }
        }
    }
    [PunRPC]
    private void DestroyCoin(int coinViewID)
    {
        PhotonView coinPhotonView = PhotonView.Find(coinViewID);
        if (coinPhotonView != null && coinPhotonView.IsMine)
        {
            PhotonNetwork.Destroy(coinPhotonView);
        }
    }
}
