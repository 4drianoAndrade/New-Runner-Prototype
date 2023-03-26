using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //private Player _Player;

    [Header("PLAYER BUNNY SETTINGS")]
    public float jumpForceBunny;
    public Transform checkGroundTransform;
    public float groundCheckRadiusSize;
    public LayerMask groundJumpLayer;

    [Header("BRIDGE SETTINGS")]
    public float groundSpeedMovement;
    public float distanceToDestroyGround;
    public float groundSizeForInstantiation;
    public GameObject[] groundPrefab;

    //[Header("GLOBAL VARIABLES")]
    //public float positionXPlayer;

    [Header("GAME SCORE")]
    public int gameScore;
    public Text scoreTxt;

    [Header("FX SOUND")]
    public AudioSource fxAudioSource;
    public AudioClip scoreSoundEffect;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        //_Player = FindObjectOfType<Player>();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void LateUpdate()
    {
        //positionXPlayer = _Player.transform.position.x;
    }

    public void ToScore(int amountOfPoints)
    {
        gameScore += amountOfPoints;
        scoreTxt.text = "Score: " + gameScore.ToString();
        fxAudioSource.PlayOneShot(scoreSoundEffect);
    }

    public void ChangeScene(string destinationScene)
    {
        SceneManager.LoadScene(destinationScene);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGroundTransform.position, groundCheckRadiusSize);
    }
}
