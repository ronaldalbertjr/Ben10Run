using UnityEngine;
using System.Collections;

public class NetworkPlayer : Photon.MonoBehaviour
{
    [SerializeField]
    private GameObject myCamera;
    void Start()
    {
        if (photonView.isMine)
        {
            myCamera.SetActive(true);
            this.GetComponent<PlayerScript>().enabled = true;
        }
        else
        {
            myCamera.SetActive(false);
            this.GetComponent<PlayerScript>().enabled = false;
        }
    }
}
