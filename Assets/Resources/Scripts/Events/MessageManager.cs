using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;
[System.Serializable] 
public class Message{
	
	public int id;
	public string name;
	public string message;

	public Message(int newId, string newName, string newMessage){
		id = newId;
		name = newName;
		message = newMessage;
	}
}

public class MessageManager : MonoBehaviour {
	
	private static Dictionary <string, Message> MessagesDictionary = new Dictionary<string, Message>();

	//public List <Message> messagesList = new List<Message> ();

	void Awake ()
	{
		loadMessages();
	}

	void loadMessages(){
		string path = Application.dataPath + "/Resources/Json/messagesJSON.json";
		string jsonString = File.ReadAllText (path);
		var messages = JSON.Parse (jsonString);
		//var name = messages["messages"]["key_use"]["message"];
		foreach (var m in messages) {
			//messagesList.Add(new Message(m.Value["id"], m.Value["name"], m.Value["message"]));
			MessagesDictionary.Add ( m.Value["name"], new Message(m.Value["id"] , m.Value["name"] , m.Value["message"]));
		}
		//print( getMessageText("key_take"));
	}

	public static String getMessageText(string messageName, string amount = null, string itemname = null){
		Message messageContent;
		if (!MessagesDictionary.TryGetValue (messageName.ToString(), out messageContent)) {
			return "nono";
		}
		return messageContent.message + " " + amount + " " + itemname;
	}
		

	void OnEnable ()
	{
		EventManager.StartListening ("Message", SendMessage);
	}

	void OnDisable ()
	{
		EventManager.StopListening ("Message", SendMessage);

	}

	void SendMessage(string myMessage){
		EventManager.eventPanel.gameObject.SetActive (true);
		EventManager.eventPanel.gameObject.GetComponentInChildren<Text> ().text = myMessage.ToString ();
		print (myMessage);
		Invoke ("restartMessage", 1f);
	}

	void restartMessage(){
		EventManager.eventPanel.gameObject.SetActive (false);
	}
}
