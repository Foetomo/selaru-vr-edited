using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class ShowPath : MonoBehaviour
{
    private NavMeshAgent _meshAgent;
    private LineRenderer _playerLineRenderer;

    [Header("Challenge")]
    public bool isChallenge;
    public bool isWin;
    public Highscore highscore;
    public UnityEvent eventAfterWin;
    public Transform spawnPlayer;
    public float timeBeforeBack = 3f;
    private float currentTime = 0;
    public TextMeshProUGUI timeWin;
    public float currentTimeElapsed;

    [Header("Line Direction")]
    [SerializeField] private float _startLineWidth = 0.1f;
    [SerializeField] private float _endLineWidth = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _meshAgent = GetComponent<NavMeshAgent>();
        _playerLineRenderer = GetComponent<LineRenderer>();

        _playerLineRenderer.startWidth = _startLineWidth;
        _playerLineRenderer.endWidth = _endLineWidth;
        _playerLineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (isChallenge && !isWin)
        {
            currentTimeElapsed += Time.deltaTime;
        }

        if (Vector3.Distance(_meshAgent.destination, transform.position) <= _meshAgent.stoppingDistance)
        {
            if (!isChallenge)
            {
                _meshAgent.SetDestination(transform.position);
                gameObject.GetComponent<LineRenderer>().enabled = false;
            }
        }
        else if(_meshAgent.hasPath)
        {
            if (!isChallenge)
            {
                DrawPath();
            }
        }

        if (isWin)
        {
            eventAfterWin.Invoke();
            highscore.SaveHighscore(currentTimeElapsed);
            BackToSpawn();
        }
    }

    public void SetDestination(Vector3 target)
    {
        Debug.Log(target);
        _meshAgent.SetDestination(target);
    }

    // Draw the ppath the player will take to reah its destination
    private void DrawPath()
    {
        gameObject.GetComponent<LineRenderer>().enabled = true;
        _playerLineRenderer.positionCount = _meshAgent.path.corners.Length;
        _playerLineRenderer.SetPosition(0, transform.position);

        if (_meshAgent.path.corners.Length < 2)
        {
            return;
        }

        for (int i = 1; i < _meshAgent.path.corners.Length; i++)
        {
            Vector3 destinationPosition = new Vector3(_meshAgent.path.corners[i].x, _meshAgent.path.corners[i].y, _meshAgent.path.corners[i].z);
            _playerLineRenderer.SetPosition(i, destinationPosition);
        }
    }

    public void TimeWin()
    {
        timeWin.text = (currentTimeElapsed/60).ToString("00") + ":" + (currentTimeElapsed%60).ToString("00");
    }

    private void BackToSpawn()
    {
        if (currentTime < timeBeforeBack)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Tour Guide");
        }
    }
}
