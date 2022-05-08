using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
	[Range(0f, 1f)]
	public float volume;
	[Range(0.3f, 1.2f)]
	public float pitch = 1f;

	[HideInInspector]
	public AudioSource source;
	public AudioClip clip;

	public string name;

	public bool loop;
}
