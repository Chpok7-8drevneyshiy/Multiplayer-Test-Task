using UnityEngine;
using Photon.Pun;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int countCoin;
    [SerializeField] private GameObject coin;
    private PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        CoinSpawn();
    }
    private void CoinSpawn()
    {
        if (view.IsMine)
        {
            for (int i = 0; i < countCoin; i++)
            {
                float randPositionX = Random.Range(-9, 9);
                float randPositionY = Random.Range(-4.5f, 4.5f);
                PhotonNetwork.Instantiate(coin.name, new Vector2(randPositionX, randPositionY), Quaternion.identity);
            }
        }
    }
}
