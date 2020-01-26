using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class Shaker : MonoBehaviour
{

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.001f;
	public float shake_intensity = 0.1f;

	private float temp_shake_intensity = 0;

	void Start()
	{
		
			Shake();
		
	}

	void Update()
	{
		
		if (temp_shake_intensity > 0)
		{
			transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;
		}
		else
		{
			Shake();
		}
	}

	void Shake()
	{
		originPosition = transform.position;
		originRotation = transform.rotation;
		temp_shake_intensity = shake_intensity;

	}
}