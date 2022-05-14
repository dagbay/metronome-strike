using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class CombatSystem : MonoBehaviour
{
    public GameObject _border;
    private static CombatSystem _bpmInstance;
    public float _bpm;
    private float _beatInterval, _beatTimer;
    public static bool _beatFull;
    public static int _beatCountFull;

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
    }

    private void Update()
    {
        BeatDetection();
    }

    #region "BPM Component"

    private void BeatDetection()
    {
        _beatFull = false;
        _beatInterval = 60 / _bpm;
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            _beatCountFull++;
            Debug.Log("Full");
        }
    }

    #endregion

    #region "Combat Component"

    #endregion

}
