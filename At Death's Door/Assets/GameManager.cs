using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	public UIManager uiManage;
	public float transitionTime;

	public bool isHumanKilled;

	public GameObject _camera;
	public GameObject player;

	private void Start()
	{
		uiManage = FindObjectOfType<UIManager>();
		isHumanKilled = false;
		_camera = Camera.main.gameObject;
		player = FindObjectOfType<PlayerMovement>().gameObject;
	}

	public void HumanKilled()
	{
		player.GetComponent<Possessing>().timer = player.GetComponent<Possessing>().possessDelay;
		isHumanKilled = true;
		//uiManage = FindObjectOfType<UIManager>();
	}

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

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			Stats.hasDiedOnce = false;
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
		LoadLevel();

	}
	public void LoadLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}

	public void Shake()
    {
        _camera.GetComponent<Animator>().SetTrigger("Shake");
    }
}
