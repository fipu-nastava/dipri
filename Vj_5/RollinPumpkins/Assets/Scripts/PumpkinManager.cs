using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinManager : MonoBehaviour
{
    public List<GameObject> pumpkins;

	public float force;

	private int currentPumpkinIdx;
	private Vector3 initialScale;
	private float scaleUp = 1.5f;

   
	private GameObject CurrentPumpkin
	{
		get
		{
			return pumpkins[currentPumpkinIdx];
		}
	}

	void Start()
	{
        // Save the scale so we can later reset it
		initialScale = CurrentPumpkin.transform.localScale;
        // Scale up the first pumpkin
		CurrentPumpkin.transform.localScale *= scaleUp;
	}

	void Update()
	{
		if (Input.GetKeyDown("right"))
		{
			SelectPumpkin(1);
		}
		else if (Input.GetKeyDown("left"))
		{
			SelectPumpkin(-1);
		}
		else if (Input.GetKeyDown("up"))
		{
			ApplyForce();
		}
	}

	private void SelectPumpkin(int step)
	{
        // Scale back the previous pumpkin
		CurrentPumpkin.transform.localScale = initialScale;

        // Set the new index
		currentPumpkinIdx = (currentPumpkinIdx - step + pumpkins.Count) % pumpkins.Count;

        // Scale up current pumpkin
		CurrentPumpkin.transform.localScale *= scaleUp;
	}

	void ApplyForce()
	{
		CurrentPumpkin.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * force, ForceMode.Impulse);
        
	}

}
