using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask mask;

    private void Update()
    {
        if (photonView.IsMine)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, mask);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    float newHealth = hit.collider.GetComponent<Health>().GetCurrentHealth() - damage;
                    hit.collider.GetComponent<PhotonView>().RPC("ApplyDamage", RpcTarget.All, newHealth);
                }
                photonView.RPC("DestroyBullet", RpcTarget.All);
            }
            else
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
    }

    [PunRPC]
    private void DestroyBullet()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
