using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ShockWaveManager : MonoBehaviour
{
    [SerializeField] private float _shockWaveTime = 0.75f;

    private Coroutine _shockWaveCoroutine;
    private Material _material;
    private static int _waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (Input.GetButtonDown("SwitchPlatform"))
        {
            CallShockWave();
        }
    }

    public void CallShockWave()
    {
        _shockWaveCoroutine = StartCoroutine(shockWaveAction(0f, 1.2f));
    }

    private IEnumerator shockWaveAction(float startPos, float endPos)
    {
        _material.SetFloat(_waveDistanceFromCenter, startPos);
        float lerpedAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < _shockWaveTime)
        {
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / _shockWaveTime));
            _material.SetFloat(_waveDistanceFromCenter, lerpedAmount);

            yield return null ;
        }
    }
}
