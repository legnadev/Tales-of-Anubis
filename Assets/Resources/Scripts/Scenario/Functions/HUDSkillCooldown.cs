using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSkillCooldown : MonoBehaviour {

	// Skill Time Control
	private Image hud_timeControl;
	private bool coolingDown_timeControl;
	private float cooldown_timeControl;

	// Use this for initialization
	void Start () {
		
		GameObject skills = GameObject.Find ("Skills");

		// TimeControl skill
		hud_timeControl = GameObject.Find ("HUD_TimeControl/Cooldown").GetComponent<Image>();
		cooldown_timeControl = skills.GetComponent<TimeControl> ().cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (coolingDown_timeControl) {
			hud_timeControl.fillAmount += 1.0f / cooldown_timeControl * Time.deltaTime;
		}
	}

	void OnEnable ()
	{
		EventManager.StartListening ("SetCooldown",  SetCooldown);
		EventManager.StartListening ("SetCooldown", SetCooldown);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("SetCooldown",  SetCooldown);
		EventManager.StopListening ("SetCooldown", SetCooldown);
	}

	void SetCooldown(string skillname = ""){
		if (skillname == "timeControl") {
			hud_timeControl.fillAmount = 0;
			coolingDown_timeControl = true;
		}

	}

	void RestartCooldown(string skillname = ""){
		if (skillname == "timeControl") {
			
		}

	}

}
