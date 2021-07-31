using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class ListOfDestination : MonoBehaviour
{
    
    [SerializeField] private GameObject _buttonDestination; // prefab button that will be instantiated
    [SerializeField] private NavMeshAgent _playerNavMesh; // player navigation mesh

    [Header("1st floor")]
    [SerializeField] private string _destinationTag1; // tag destination
    public GameObject[] _destination1; // array of destination object
    [SerializeField] private GameObject _content1; // parrent for content
    [Header("2nd floor")]
    [SerializeField] private string _destinationTag2; // tag destination
    public GameObject[] _destination2; // array of destination object
    [SerializeField] private GameObject _content2; // parrent for content
    [Header("3rd floor")]
    [SerializeField] private string _destinationTag3; // tag destination
    public GameObject[] _destination3; // array of destination object
    [SerializeField] private GameObject _content3; // parrent for content
    [Header("4th floor")]
    [SerializeField] private string _destinationTag4; // tag destination
    public GameObject[] _destination4; // array of destination object
    [SerializeField] private GameObject _content4; // parrent for content

    private void Awake()
    {
        if (_destinationTag1 != null && _destinationTag1 != "")
            _destination1 = GameObject.FindGameObjectsWithTag(_destinationTag1); // add array of gameobject to variable
        if (_destinationTag2 != null && _destinationTag2 != "")
            _destination2 = GameObject.FindGameObjectsWithTag(_destinationTag2); // add array of gameobject to variable
        if (_destinationTag3 != null && _destinationTag3 != "")
            _destination3 = GameObject.FindGameObjectsWithTag(_destinationTag3); // add array of gameobject to variable
        if (_destinationTag4 != null && _destinationTag4 != "")
            _destination4 = GameObject.FindGameObjectsWithTag(_destinationTag4); // add array of gameobject to variable
    }

    private void Start()
    {
        if (_buttonDestination != null)
        {
            // 1st floor
            if (_destination1 != null)
            {
                foreach (GameObject item in _destination1)
                {
                    GameObject newBtn = Instantiate(_buttonDestination, _content1.transform); // instantiate object
                    newBtn.GetComponentInChildren<TextMeshProUGUI>().text = item.name; // change button text to item name
                    newBtn.name = item.name; // change new button name to item name
                    Button clickBtn = newBtn.GetComponent<Button>(); // initialize clickBtn with Button
                    clickBtn.onClick.AddListener(() => { _playerNavMesh.SetDestination(item.transform.position); }); // add onclick to set destination 
                }
            }

            // 2nd floor
            if (_destination2 != null)
            {

                foreach (GameObject item in _destination2)
                {
                    GameObject newBtn = Instantiate(_buttonDestination, _content2.transform); // instantiate object
                    newBtn.GetComponentInChildren<TextMeshProUGUI>().text = item.name; // change button text to item name
                    newBtn.name = item.name; // change new button name to item name
                    Button clickBtn = newBtn.GetComponent<Button>(); // initialize clickBtn with Button
                    clickBtn.onClick.AddListener(() => { _playerNavMesh.SetDestination(item.transform.position); }); // add onclick to set destination 
                }
            }

            // 3rd floor
            if (_destination3 != null)
            {
                foreach (GameObject item in _destination3)
                {
                    GameObject newBtn = Instantiate(_buttonDestination, _content3.transform); // instantiate object
                    newBtn.GetComponentInChildren<TextMeshProUGUI>().text = item.name; // change button text to item name
                    newBtn.name = item.name; // change new button name to item name
                    Button clickBtn = newBtn.GetComponent<Button>(); // initialize clickBtn with Button
                    clickBtn.onClick.AddListener(() => { _playerNavMesh.SetDestination(item.transform.position); }); // add onclick to set destination 
                }
            }

            // 4th floor
            if (_destination4 != null)
            {
                foreach (GameObject item in _destination4)
                {
                    GameObject newBtn = Instantiate(_buttonDestination, _content4.transform); // instantiate object
                    newBtn.GetComponentInChildren<TextMeshProUGUI>().text = item.name; // change button text to item name
                    newBtn.name = item.name; // change new button name to item name
                    Button clickBtn = newBtn.GetComponent<Button>(); // initialize clickBtn with Button
                    clickBtn.onClick.AddListener(() => { _playerNavMesh.SetDestination(item.transform.position); }); // add onclick to set destination 
                }
            }
        }
    }


}
                