using UnityEngine;
using Photon.Pun;

public class PlayerColor : MonoBehaviourPunCallbacks
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color red, blue;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetPlayerColor();

        // Добавляем игрока в список players
        WinnerChecker winnerChecker = FindObjectOfType<WinnerChecker>();
        if (winnerChecker != null)
        {
            winnerChecker.players.Add(gameObject);
        }
    }

    private void SetPlayerColor()
    {
        if (photonView.IsMine)
        {
            photonView.RPC("RPC_SetColor", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }

    [PunRPC]
    private void RPC_SetColor(int actorNumber)
    {
        if (actorNumber == 1)
        {
            spriteRenderer.color = red;
            gameObject.name = "Player 1";

        }
        else if (actorNumber == 2)
        {
            spriteRenderer.color = blue;
            gameObject.name = "Player 2";

        }
    }
}
