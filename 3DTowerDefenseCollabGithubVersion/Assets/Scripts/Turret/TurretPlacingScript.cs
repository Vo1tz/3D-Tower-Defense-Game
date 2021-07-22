using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacingScript : MonoBehaviour
{
    public static TurretPlacingScript instance;

    [Header("Config")]
    public static int turretIndex = 0;
    public static bool turretAlreadySelected;

    public Text errormsg;

    [Header("Turret Config")]
    public static int totalTurretBuilds;
    public Vector3 RailGunPlaceoffset;
    public Vector3 FlameThrowerPlaceOffset;
    public Vector3 LightningPlaceOffset;
    public Vector3 MinigunPlaceOffset;
    public Vector3 ShotgunPlaceOffset;
    private bool turretPlaced;

    [Header("ColorCode")]
    private Renderer rend;
    public Color hoverColor;
    public Color defaultColor;

    [Header("Turret Prefabs")]
    public GameObject railgun; // 1
    public GameObject flamethrower; // 2
    public GameObject lightning; // 3
    public GameObject minigun; // 4
    public GameObject shotgun; // 5

    [Header("Audio")]
    public AudioClip placeTurretSFX;

    void Start()
    {
        instance = this;
        turretAlreadySelected = false;
        turretPlaced = false;

        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (turretPlaced == true)
        {
            Debug.LogError("Cant Build There!");
            errormsg.text = "There Is Already A Turret Placed There!";
            return;
        }

        if (turretIndex == 1)
        {
            if (turretPlaced == false)
            {
                railgun = (GameObject)Instantiate(railgun, transform.position + RailGunPlaceoffset, transform.rotation);
                AudioManager.Instance.PlayAudio(placeTurretSFX);
                turretIndex = 0;
                totalTurretBuilds += 1;
                turretAlreadySelected = false;
                turretPlaced = true;
            }
        }
        if (turretIndex == 2)
        { 
            if (turretPlaced == false)
            {
                flamethrower = (GameObject)Instantiate(flamethrower, transform.position + FlameThrowerPlaceOffset, transform.rotation);
                AudioManager.Instance.PlayAudio(placeTurretSFX);
                turretIndex = 0;
                totalTurretBuilds += 1;
                turretAlreadySelected = false;
                turretPlaced = true;
            }
        }
        if (turretIndex == 3)
        {
            if (turretPlaced == false)
            {
                lightning = (GameObject)Instantiate(lightning, transform.position + LightningPlaceOffset, transform.rotation);
                AudioManager.Instance.PlayAudio(placeTurretSFX);
                turretIndex = 0;
                totalTurretBuilds += 1;
                turretAlreadySelected = false;
                turretPlaced = true;
            }
        }
        if (turretIndex == 4)
        {
            if (turretPlaced == false)
            {
                minigun = (GameObject)Instantiate(minigun, transform.position + MinigunPlaceOffset, transform.rotation);
                AudioManager.Instance.PlayAudio(placeTurretSFX);
                turretIndex = 0;
                totalTurretBuilds += 1;
                turretAlreadySelected = false;
                turretPlaced = true;
            }
        }
        if (turretIndex == 5)
        {
            if (turretPlaced == false)
            {
                shotgun = (GameObject)Instantiate(shotgun, transform.position + ShotgunPlaceOffset, transform.rotation);
                AudioManager.Instance.PlayAudio(placeTurretSFX);
                turretIndex = 0;
                totalTurretBuilds += 1;
                turretAlreadySelected = false;
                turretPlaced = true;
            }
        }
    }
}