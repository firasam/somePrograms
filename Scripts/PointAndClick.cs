using UnityEngine;
using System.Collections;

public class PointAndClick : MonoBehaviour {
    InputManager _inputManager;
    float movementSpeed = 5.0f;
    Camera _camera;
    bool isMoving = false;
    Vector3 target;
	// Use this for initialization
	void Start () {
        _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (_inputManager.GetTouchStatus()) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(_inputManager.GetLastPosition()), Vector2.zero);
            if (hit.collider == null || hit.collider.tag != "Obstacle") {
                if (isMoving) {
                    StopCoroutine("move");
                }
                isMoving = true;
                StartCoroutine("move", _inputManager.GetLastPosition());
            }
        }
	}

    IEnumerator move(Vector3 destination) {
        Vector3 startPos = this.transform.position;
        Vector3 endPos = _camera.ScreenToWorldPoint(destination);
        endPos.x = Mathf.Floor(endPos.x) + 0.5f;
        endPos.y = Mathf.Floor(endPos.y) + 0.5f;
        endPos.z = 0;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPos, endPos);
        Debug.Log("endPos: X: " + endPos.x + " Y:" + endPos.y + " Z:" + endPos.z);

        while (this.transform.position != endPos) {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fracJourney = distCovered / journeyLength;
            this.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
            yield return new WaitForSeconds(0.01f);
        }
        isMoving = false;
    }
}
