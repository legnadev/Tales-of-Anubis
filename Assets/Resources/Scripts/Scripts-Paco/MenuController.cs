using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Menu Buttons
	public GameObject MenuBtnNewGame;
	public GameObject MenuBtnLevels;
	public GameObject MenuBtnOptions;
	public GameObject MenuBtnExit;

	// Menu Panels
	public GameObject Panel_Menu;
	public GameObject Panel_Options;

	// 
	[SerializeField] bool isFirstGame = true;

	void Awake(){

	}

	// Use this for initialization
	void Start () {

        
		Time.timeScale = 1;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.Instance.InputController.menu) {
			ShowMenuPanel ();
		}
			
	}

	public void NewGame(){
		SceneManager.LoadScene("Level1");
	}


	public void LoadLevel(string levelName){
		SceneManager.LoadScene(levelName);
	}


	public void LevelSelector(){
		SceneManager.LoadScene("LevelSelector");
	}
	public void MainMenu(){
		SceneManager.LoadScene("Menu");
	}

	public void Exit(){
		Application.Quit();
	}

	public void reloadScene(){
		SceneManager.LoadScene (Application.loadedLevel);
	}

	public void ShowMenuPanel(){
		if (!Panel_Menu.activeSelf && Panel_Options.activeSelf) {
			Panel_Options.SetActive (false);
		}

		if (Panel_Menu.activeSelf) {
			Panel_Menu.SetActive (false);
		} else if (!Panel_Menu.activeSelf) {
			Panel_Menu.SetActive (true);
		} 
	}

	public void ShowOptionsPanel(){
		if (Panel_Options.activeSelf) {
			Panel_Options.SetActive (false);
		} else if (!Panel_Options.activeSelf){
			Panel_Options.SetActive (true);
		}
	}
     
}
