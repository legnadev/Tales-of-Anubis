using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
	public static GameObject eventPanel;

	public class StringEvent : UnityEvent<string>{}

	private Dictionary <string, StringEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError ("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init (); 
                }
            }

            return eventManager;
        }
    }

    void Init ()
    {
        if (eventDictionary == null)
        {
			eventDictionary = new Dictionary<string, StringEvent>();
        }
		eventPanel = GameObject.Find ("Events_Panel");
		eventPanel.gameObject.SetActive (false);
    }

	public static void StartListening (string eventName, UnityAction<string> listener)
    {
		StringEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.AddListener (listener);
        } 
        else
        {
			thisEvent = new StringEvent ();
            thisEvent.AddListener (listener);
            instance.eventDictionary.Add (eventName, thisEvent);
        }
    }

	public static void StopListening (string eventName, UnityAction<string> listener)
    {
        if (eventManager == null) return;
		StringEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.RemoveListener (listener);
        }
    }

	public static void TriggerEvent (string eventName, string message)
    {
		StringEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
			thisEvent.Invoke (message);
        }
    }
}