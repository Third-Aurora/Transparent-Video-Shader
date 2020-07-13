using UnityEngine;

public class TouchInteraction : MonoBehaviour {

    Vector2 minScale = Vector3.one * .1f;
    Vector2 maxScale = Vector3.one * 50;

    void Update() {

        //check for double touch
        if (Input.GetMouseButtonDown(1)) {
            scaleDelta = 0;
        }

        if (Input.touchCount > 1) {
            Vector2 firstPos = Input.GetTouch(0).position;
            Vector2 secondPos = Input.GetTouch(1).position;
            ScaleContent(firstPos,secondPos);
        }
    }

    float scaleDelta;
    Vector2 firstScale;
    void ScaleContent(Vector2 firstPos, Vector2 secondPos) {

        //get both touch positions taking into account which is higher on screen
        float delta = Vector2.Distance(firstPos, secondPos);

        //save original state
        if (scaleDelta.Equals(0)) {
            scaleDelta = delta;
            firstScale = transform.localScale;
        }

        float currDelta = 1 + (delta - scaleDelta) / 200;
        Vector3 newScale = firstScale * currDelta;

        if (newScale.x > minScale.x && newScale.x < maxScale.x) {
            transform.localScale = newScale;
        }
    }
}
