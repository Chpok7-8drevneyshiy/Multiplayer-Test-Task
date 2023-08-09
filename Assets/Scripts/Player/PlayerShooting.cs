using System;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private Transform startPosition;
    [SerializeField] private GameObject bullet;
    private PhotonView view;
    private bool canFire;
    private float time;
    private float screen;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        startPosition = GameObject.FindGameObjectWithTag("BulletStart").transform;
        time = 0;
        screen = Screen.width;
    }

    private void Update()
    {
        Reload();
    }
    public void Fire()
    {
        if (canFire) 
        {
            PhotonNetwork.Instantiate(bullet.name, startPosition.position, transform.rotation);
            time = 0;
            canFire = false;
        } 
    }
    private void Reload()
    {
            int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screen / 2)
            {
            if (view.IsMine)
                {
                    Fire();
                }
            }
            i++;
        }

        time += Time.deltaTime;
        if(time > fireRate)
        {
            canFire = true;
        }    
    }
}
