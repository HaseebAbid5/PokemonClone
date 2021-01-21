﻿using UnityEngine;
using System.Collections;
using Databox;

// AimBehaviour inherits from GenericBehaviour. This class corresponds to aim and strafe behaviour.
public class AimBehaviourBasic : GenericBehaviour
{
	public string aimButton = "Aim", shoulderButton = "Aim Shoulder";     // Default aim and switch shoulders buttons.
	public Texture2D crosshair;                                           // Crosshair texture.
	public float aimTurnSmoothing = 0.15f;                                // Speed of turn response when aiming to match camera facing.
	public Vector3 aimPivotOffset = new Vector3(0.5f, 1.2f,  0f);         // Offset to repoint the camera when aiming.
	public Vector3 aimCamOffset   = new Vector3(0f, 0.4f, -0.7f);         // Offset to relocate the camera when aiming.

	private int aimBool;                                                  // Animator variable related to aiming.
	private bool aim;                                                     // Boolean to determine whether or not the player is aiming.
    IntType value;

    public GameObject item, hand, pokeBallContainer;
    public Vector3 offset;
    public float throwForce = 1.0f;
    public DataboxObjectLink data;

    bool grabbed;
    Camera cam = Camera.main;


	// Start is always called after any Awake functions.
	void Start ()
	{
		// Set up the references.
		aimBool = Animator.StringToHash("Aim");
	}

	// Update is used to set features regardless the active behaviour.
	void Update ()
	{
		// Activate/deactivate aim by input.
		if (Input.GetAxisRaw(aimButton) != 0 && !aim)
		{
			StartCoroutine(ToggleAimOn());
            if (!item.activeInHierarchy && data.database.GetData<IntType>("Data", "Player", "Pokeballs").Value > 0)
            {
                item.SetActive(true);
            }

        }
		else if (aim && Input.GetAxisRaw(aimButton) == 0)
		{
			StartCoroutine(ToggleAimOff());
            item.SetActive(false);
        }

        if (Input.GetButton("Fire1") && item.activeInHierarchy)
        {

            value = data.database.GetData<IntType>("Data", "Player", "Pokeballs");
            value.Value = value.Value - 1;
            item.SetActive(false);
            GameObject pokeBall = Instantiate(pokeBallContainer, item.transform.position, item.transform.rotation);
            pokeBall.GetComponent<Rigidbody>().AddForce(Camera.main.ViewportPointToRay(new Vector3(0.47f, 0.55f, 0f)).direction *throwForce, ForceMode.Impulse);
            StartCoroutine(PokeballCheck(pokeBall));
        }

        // No sprinting while aiming.
        canSprint = !aim;

		// Toggle camera aim position left or right, switching shoulders.
		if (aim && Input.GetButtonDown (shoulderButton))
		{
			aimCamOffset.x = aimCamOffset.x * (-1);
			aimPivotOffset.x = aimPivotOffset.x * (-1);
		}

		// Set aim boolean on the Animator Controller.
		behaviourManager.GetAnim.SetBool (aimBool, aim);
	}

	// Co-rountine to start aiming mode with delay.
	private IEnumerator ToggleAimOn()
	{
		yield return new WaitForSeconds(0.05f);
		// Aiming is not possible.
		if (behaviourManager.GetTempLockStatus(this.behaviourCode) || behaviourManager.IsOverriding(this))
			yield return false;

		// Start aiming.
		else
		{
         
            aim = true;
			int signal = 1;
			aimCamOffset.x = Mathf.Abs(aimCamOffset.x) * signal;
			aimPivotOffset.x = Mathf.Abs(aimPivotOffset.x) * signal;
			yield return new WaitForSeconds(0.1f);
			behaviourManager.GetAnim.SetFloat(speedFloat, 0);
            item.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            // This state overrides the active one.
            behaviourManager.OverrideWithBehaviour(this);
		}
	}

	// Co-rountine to end aiming mode with delay.
	private IEnumerator ToggleAimOff()
	{
		aim = false;
       // item.SetActive(false);
        yield return new WaitForSeconds(0.1f);
		behaviourManager.GetCamScript.ResetTargetOffsets();
		behaviourManager.GetCamScript.ResetMaxVerticalAngle();
		yield return new WaitForSeconds(0.05f);
		behaviourManager.RevokeOverridingBehaviour(this);
	}

    private IEnumerator PokeballCheck(GameObject p)
    {

        data.database.SetData<IntType>("Data", "Player", "Pokeballs", value);
        Debug.Log(value.Value);
        yield return new WaitForSeconds(3);
        Destroy(p);
    }

	// LocalFixedUpdate overrides the virtual function of the base class.
	public override void LocalFixedUpdate()
	{
        // Set camera position and orientation to the aim mode parameters.
        if (aim)
            behaviourManager.GetCamScript.SetTargetOffsets(aimPivotOffset, aimCamOffset);
     
	}

	// LocalLateUpdate: manager is called here to set player rotation after camera rotates, avoiding flickering.
	public override void LocalLateUpdate()
	{
		AimManagement();
	}

	// Handle aim parameters when aiming is active.
	void AimManagement()
	{
		// Deal with the player orientation when aiming.
		Rotating();
	}

	// Rotate the player to match correct orientation, according to camera.
	void Rotating()
	{
		Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);
		// Player is moving on ground, Y component of camera facing is not relevant.
		forward.y = 0.0f;
		forward = forward.normalized;

		// Always rotates the player according to the camera horizontal rotation in aim mode.
		Quaternion targetRotation =  Quaternion.Euler(0, behaviourManager.GetCamScript.GetH, 0);

		float minSpeed = Quaternion.Angle(transform.rotation, targetRotation) * aimTurnSmoothing;

		// Rotate entire player to face camera.
		behaviourManager.SetLastDirection(forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, minSpeed * Time.deltaTime);

	}

 	// Draw the crosshair when aiming.
	void OnGUI () 
	{
		if (crosshair)
		{
			float mag = behaviourManager.GetCamScript.GetCurrentPivotMagnitude(aimPivotOffset);
			if (mag < 0.05f)
				GUI.DrawTexture(new Rect(Screen.width / 2 - (crosshair.width * 0.5f),
										 Screen.height / 2 - (crosshair.height * 0.5f),
										 crosshair.width, crosshair.height), crosshair);
		}
	}
}
