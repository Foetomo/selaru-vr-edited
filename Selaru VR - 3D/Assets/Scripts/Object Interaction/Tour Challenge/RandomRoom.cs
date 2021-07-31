using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class RandomRoom : MonoBehaviour
{
    public ListOfDestination listOfDestination;
    public ShowPath playerShowPath;
    private GameObject destination;

    public TextMeshProUGUI textDestination;

    private void Start()
    {
        RandomDest();
    }
    public void RandomDest()
    {
        int randomFloor = Random.Range(1, 4);
        int randomRoom;
        switch (randomFloor)
        {
            case 1:
                randomRoom = Random.Range(0, listOfDestination._destination1.Length);
                destination = listOfDestination._destination1[randomRoom];
                break;
            case 2:
                randomRoom = Random.Range(0, listOfDestination._destination2.Length);
                destination = listOfDestination._destination2[randomRoom];
                break;
            case 3:
                randomRoom = Random.Range(0, listOfDestination._destination2.Length);
                destination = listOfDestination._destination2[randomRoom];
                break;
            case 4:
                randomRoom = Random.Range(0, listOfDestination._destination2.Length);
                destination = listOfDestination._destination2[randomRoom];
                break;
        }
        destination.GetComponent<BoxCollider>().isTrigger = true;
        playerShowPath.gameObject.GetComponent<NavMeshAgent>().SetDestination(destination.transform.position);
        textDestination.text = destination.name;
    }
}
