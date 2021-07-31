using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCollider : MonoBehaviour
{
    
    public GameObject ImgPanel;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ImgPanel.SetActive (true);
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ImgPanel.SetActive (false);
        }
    }
}