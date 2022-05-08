using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;

	public static AudioManager instance;

	public enum AudioPlay { Normal, Oneshot};

	public void Awake()
	{
		


		DontDestroyOnLoad(gameObject);

		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

		
	}

	public void Update()
	{

	}

	private void Start()
	{
		Play("Music", AudioPlay.Normal);
	}

	public void Play(string name, AudioPlay audioPlay)
	{
		
		foreach(Sound s in sounds)
		{
			if(s.name == name)
			{
				if(audioPlay == AudioPlay.Normal)
				{
					s.source.Play();
				}
				if(audioPlay == AudioPlay.Oneshot)
				{
					s.source.PlayOneShot(s.clip);
				}

				return;
			}

		}
	}


	public void Mute(string name, bool muted)
	{
		foreach(Sound s in sounds)
		{
			if(s.name == name)
			{
				s.source.mute = muted;
			}
		}
	}

	public void Stop(string name)
	{
		foreach(Sound s in sounds)
		{
			if(s.name == name)
			{
				s.source.Stop();
				return;
			}
		}
	}




}
