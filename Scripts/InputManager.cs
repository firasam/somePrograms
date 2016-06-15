using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
    Vector3 lastTouchPos;
    bool touchStatus;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        touchStatus = UpdateTouchPosition();
    }

    bool UpdateTouchPosition() {
        bool aTouch;
        bool notAndroid = Application.platform != RuntimePlatform.Android;

        if (notAndroid) {
            // use the input stuff
            aTouch = Input.GetMouseButtonDown(0);
        } else {
            // use the iPhone Stuff
            if (Input.touchCount > 0) {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                    aTouch = Input.touchCount > 0;
                else
                    aTouch = false;
            } else aTouch = false;
        }

        if (aTouch) {
            if (notAndroid)
                lastTouchPos = Input.mousePosition;
            else
                lastTouchPos = Input.GetTouch(0).position;
        }

        return aTouch;
    }
    // call only on updates or coroutines!
    public bool GetTouchStatus() {
        return touchStatus;
    }

    public Vector3 GetLastPosition() {
        Debug.Log("X:" + lastTouchPos.x + " Y:" + lastTouchPos.y);

        return lastTouchPos;
    }

	public void offTouch(){
		touchStatus = false;
	}
}
