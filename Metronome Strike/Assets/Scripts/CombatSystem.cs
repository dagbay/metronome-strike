using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class CombatSystem : MonoBehaviour
{
    public SpriteRenderer _borderRend;
    private static CombatSystem _bpmInstance;
    public float _bpm;
    private float _beatInterval, _beatTimer, _beatIntervalD8, _beatTimerD8;
    public static bool _beatFull, _beatD8;
    public static int _beatCountFull, _beatCountD8;

    private void Awake()
    {
        if (_bpmInstance != null && _bpmInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _bpmInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        Color c = _borderRend.material.color;
        c.a = 0f;
        _borderRend.material.color = c;
    }

    private void Update()
    {
        BeatDetection();
    }

    #region "BPM Component"

    private void BeatDetection()
    {
        // Full Beat
        FadeOut();
        _beatFull = false;
        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            FadeIn();
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
            Debug.Log("Full");
        }

        // Divided Beat
        _beatD8 = false;
        _beatIntervalD8 = _beatInterval / 8;
        _beatTimerD8 += Time.deltaTime;
        if (_beatTimerD8 >= _beatIntervalD8) {
            _beatTimerD8 -= _beatIntervalD8;
            _beatD8 = true;
            _beatCountD8++;
            Debug.Log("D8");
        }
    }


    IEnumerator FadeInEnum() {
        for (float f = 0.05f; f <= 1; f += 0.05f) {
            Color c = _borderRend.material.color;
            c.a = f;
            _borderRend.material.color = c;
            yield return new WaitForSeconds((60000/_bpm)/(1600)*Time.deltaTime);
        }
    }

    IEnumerator FadeOutEnum() {
        for (float f = 0.05f; f >= 1; f -= 0.05f) {
            Color c = _borderRend.material.color;
            c.a = f;
            _borderRend.material.color = c;
            yield return new WaitForSeconds((60000/_bpm)/(1600)*Time.deltaTime);
        }
    }

    public void FadeIn() {
        StartCoroutine("FadeInEnum");
    }

    public void FadeOut() {
        StartCoroutine("FadeOutEnum");
    }

    #endregion

    #region "Combat Component"

    private void OnMouseDown() {
        
    }
    private void Attack() {

    }

    private void Defend() {

    }

    #endregion

}
