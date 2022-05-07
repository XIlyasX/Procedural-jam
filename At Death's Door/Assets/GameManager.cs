using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	UIManager uiManage;
	public float transitionTime;

	public void Awake()
	{


		Stats.humansKilled = 0;

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
	}

	public void Start()
	{
		uiManage = FindObjectOfType<UIManager>();
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if(Stats.humansKilled ==  uiManage.goalValue)
		{
			StartCoroutine(NextLevel());
		}
	}

	IEnumerator NextLevel()
	{
		yield return new WaitForSeconds(transitionTime);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		

	}

	public GameObject _camera;

    public void Shake()
    {
        _camera.GetComponent<Animator>().SetTrigger("Shake");
    }



}
