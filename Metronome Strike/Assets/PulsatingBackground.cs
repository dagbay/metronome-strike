using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsatingBackground : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public float duration = 3.0f;

    public Camera camera;

    private void Start() {
        camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Update() {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        camera.backgroundColor = Color.Lerp(color1, color2, t);
    }


}
