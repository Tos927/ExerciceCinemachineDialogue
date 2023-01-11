using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boat;

    public void RevealBoat()
    {
        boat.SetActive(true);
    }

    public void HidePlayer()
    {
        Debug.Log("Yeeeho !");
    }
}
