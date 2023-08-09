using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class WinnerChecker : MonoBehaviourPunCallbacks
{
    public List<GameObject> players = new List<GameObject>();
    public GameObject WinPanel;
    public TMP_Text Winner;

    private void Update()
    {
        if (players.Count > 1)
        {
            if (players[0]?.GetComponent<Health>().IsDead == true || players[1]?.GetComponent<Health>().IsDead == true)
            {
                ShowWinner();
            }
        }
    }

    private void ShowWinner()
    {
        WinPanel.SetActive(true);
        bool isOpen = false;
        if (players[1].GetComponent<Health>().IsDead == true && isOpen == false)
        {
            Winner.text = Winner.text + players[1].name;
            isOpen = true;
        }
        else if (players[2].GetComponent<Health>().IsDead == true && isOpen == false)
        {
            Winner.text = Winner.text + players[0].name;
            isOpen = true;
        }

        Time.timeScale = 0;
    }

    private void BackToMenu()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Menu");
    }
}
