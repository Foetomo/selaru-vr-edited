using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter: " + other.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShowPath>().isWin = true;
        }
    }

}
