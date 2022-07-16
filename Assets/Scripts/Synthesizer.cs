using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Synthesizer : MonoBehaviour
{
    //Inspiration
    //https://www.youtube.com/watch?v=GqHFGMy_51c
    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnAudioFilterRead.html


    [SerializeField] private double _frequenzy;
    [SerializeField] private double _increment;
    [SerializeField] private double _phase;
    [SerializeField] private double _sampleRate;

    [SerializeField] private double _gain;

    private void OnAudioFilterRead(float[] data, int channels)
    {
        _increment = _frequenzy * 2.0 * Mathf.PI / _sampleRate;
        for (int i = 0; i < data.Length; i += channels)
        {
            _phase += _increment;
            data[i] = (float)_gain * Mathf.Sin((float)_phase);

            if (_phase > Mathf.PI * 2)
            {
                _phase = 0;
            }
            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

        }
    }


}
