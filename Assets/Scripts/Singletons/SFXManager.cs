using UnityEngine;

public class SFXManager : MonoBehaviour
{
	public static SFXManager Instance;

	private AudioSource _source;
	
	private void Awake()
	{
		if(Instance == null)
			Instance = this;
		else if(Instance != this)
			Destroy(gameObject);
	}

    private void Start()
    {
		_source = GetComponent<AudioSource>();
	}

	public void PlaySFX(AudioEvent audioEvent)
    {
		audioEvent.Play(_source);
    }
}