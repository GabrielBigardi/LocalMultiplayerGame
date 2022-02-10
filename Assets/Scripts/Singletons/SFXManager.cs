using UnityEngine;

public class SFXManager : MonoBehaviour
{
	public static SFXManager Instance;
	
	private void Awake()
	{
		if(Instance == null)
			Instance = this;
		else if(Instance != this)
			Destroy(gameObject);
	}
	

}