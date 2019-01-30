using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Image myBackground;

	public GameObject myButton;
	public GameObject myText;

	// Use this for initialization
	void Start () {
		myBackground = GetComponent<Image> ();

		myButton = transform.Find ("Button").gameObject;
		myText = transform.Find ("Dead_Text").gameObject;

		this.transform.localScale = new Vector3 (0, 0, 0);
		myButton.SetActive (false);
		myText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnEnable ()
	{
		EventManager.StartListening ("FinalDeath", showPanel);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("FinalDeath", showPanel);

	}

	void showPanel(string abc = ""){
		this.transform.localScale = new Vector3 (1, 1, 1);
		this.gameObject.SetActive (true);
		myText.SetActive (true);
		StartCoroutine(FadeTo(1.0f, 5.0f));
	}

		

	IEnumerator FadeTo(float aValue, float aTime)
	{
		
		float alpha = myBackground.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha,aValue,t));
			myBackground.color = newColor;
			yield return null;
		}
		myButton.SetActive (true);
	}
}
