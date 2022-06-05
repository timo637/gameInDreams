using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject bedPrefab;
    public Text levelText;
    public Text livesText;
    public Text notificationText;

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;

    public GameObject[] levels;
    public bool nearTheBed = false;

    public static GameManager Instance { get; private set; }

    public enum State { MENU, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER };
    State _state;
    GameObject _currentLevel;
    GameObject _currentPlayer;
    
    bool _isSwitchingState;

    private int _level;

    public int Level
    {
        get { return _level; }
        set { _level = value;
            levelText.text = "Level: " + _level;
        }
    }

    private int _livesRemaining;

    public int LivesRemaining
    {
        get { return _livesRemaining; }
        set { _livesRemaining = value;
            livesText.text = "Lives remaining: " + _livesRemaining;
        }
    }


    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
    }

    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        _isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
        _isSwitchingState = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                panelPlay.SetActive(true);
                Level = 1;
                LivesRemaining = 3;
                _currentPlayer = Instantiate(playerPrefab);
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                _currentPlayer.transform.position = _currentPlayer.transform.position + GameObject.FindWithTag("spawn").transform.position;
                Debug.Log(_currentPlayer.transform.position);
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(true);
                break;
            case State.LOADLEVEL:
                if (Level >= levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    _currentLevel = Instantiate(levels[Level-1]);
                    Debug.Log(_currentPlayer.transform.position);
                    Debug.Log(GameObject.FindWithTag("spawn").transform.position);
                    //_currentPlayer.transform.position = _currentPlayer.transform.position + GameObject.FindWithTag("spawn").transform.position;
                    //Debug.Log(_currentPlayer.transform.position);
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;
        }
    }

    void Update()
    {

        if (nearTheBed)
        {
            notificationText.text = "Press 'F' to go to sleep.";
        }
        else
        {
            notificationText.text = "";
        }

        if (Input.GetKeyDown("f") && Level<levels.Length && nearTheBed)
        {
            Destroy(_currentLevel);
            _currentLevel = Instantiate(levels[Level]);
            Level += 1;
        }

        if (Input.GetKeyDown("g") && Level != 1)
        {
            Destroy(_currentLevel);
            _currentLevel = Instantiate(levels[Level-2]);
            Level -= 1;
        }

        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                if( Vector3.Distance(_currentPlayer.transform.position, _currentLevel.transform.GetChild(_currentLevel.transform.childCount - 1).position) < 3f) {
                    nearTheBed = true;
                }
                else
                {
                    nearTheBed = false;
                };
                if (LivesRemaining == 0)
                {
                    SwitchState(State.GAMEOVER);
                }
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }
}