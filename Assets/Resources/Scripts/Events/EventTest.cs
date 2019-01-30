using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

    private UnityAction someListener;

    void Awake ()
    {
       // someListener = new UnityAction (SomeFunction);
    }

    void OnEnable ()
    {
		//EventManager.StartListening ("test", someListener);
		EventManager.StartListening ("Spawn",  SomeOtherFunction);
        EventManager.StartListening ("Destroy", SomeThirdFunction);
    }

    void OnDisable ()
    {
       // EventManager.StopListening ("test", someListener);
		EventManager.StopListening ("Spawn",  SomeOtherFunction);
        EventManager.StopListening ("Destroy", SomeThirdFunction);
    }

	void SomeFunction (string message)
    {
        Debug.Log ("Some Function was called!");
    }
    
	void SomeOtherFunction (string message)
    {
		Debug.Log ("Some Other Function was called!" + message);
    }
    
	void SomeThirdFunction (string message)
    {
        Debug.Log ("Some Third Function was called!");
    }
}