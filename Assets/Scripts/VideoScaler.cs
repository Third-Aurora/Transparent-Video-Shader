using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoScaler : MonoBehaviour {

    Vector3 startScale;

    void Awake() {
        //save initial scale
        startScale = transform.localScale;

        //scale video within bounds of mesh to correct aspect ratio
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        float width = videoPlayer.clip.width;
        float height = videoPlayer.clip.height;
        ScaleVideo(width, height);
    }

    public void ScaleVideo(float width, float height) {
        Vector3 newScale = startScale;

        if (width > height) {
            //handle landscape
            float AspectRatio = height / width;
            newScale.y = startScale.x * AspectRatio;
        } else {
            //handle portrait
            float AspectRatio = width / height;
            newScale.x = startScale.y * AspectRatio;
        }

        transform.localScale = newScale;
    }
}
