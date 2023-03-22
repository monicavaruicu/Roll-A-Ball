using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public Transform cam;  

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.SetActive(false);
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		
		if (Input.GetKey("w"))
        {
			rb.AddForce(new Vector3(cam.forward.x, 0, cam.forward.z).normalized * speed);
        }

		if (Input.GetKey("s"))
		{
			rb.AddForce(new Vector3(cam.forward.x, 0, cam.forward.z).normalized * (- speed));
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(new Vector3(cam.right.x, 0, cam.right.z).normalized * (- speed));
		}

		if (Input.GetKey("d"))
		{
			rb.AddForce(new Vector3(cam.right.x, 0, cam.right.z).normalized * speed);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 100)
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
		}
	}
}
