using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    int SAMPLE_SIZE = 1024;
    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    public float visualModifier;
    public float smoothSpeed = 10f;

    public AudioSource source;
    public AudioClip clip;
    public int size;
    public int channel;
    public float[] samples;
    public float[] spectrum;
    float sampleRate;

    public Transform[] visualList;
    public float[] visualScale;
    public int visualAmount;
    public float visualScaleMax = 25f;
    public float keeppercentage = 0.5f;

    // Use this for initialization
    void Start()
    {
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;

        SpawnCubes();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            AnalyzeSound();
            VisualizeSound();
        }
    }

    public void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);
        float sum = 0;
        for (int i = 0; i < SAMPLE_SIZE; ++i)
        {
            sum += samples[i] * samples[i];
        }
        rmsVal = Mathf.Sqrt(sum / SAMPLE_SIZE);

        dbVal = 20 * Mathf.Log10(rmsVal / 0.1f);

        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float maxV = 0;
        int maxN = 0;

        for (int i = 0; i < SAMPLE_SIZE; ++i)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
                continue;

            maxV = spectrum[i];
            maxN = i;
        }

        float freqN = maxN;
        if (maxN > 0 && maxN < SAMPLE_SIZE - 1)
        {

            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f + (dR * dR - dL * dL);

        }

        pitchVal = freqN + (sampleRate / 2) / SAMPLE_SIZE;



    }

    public void SpawnCubes()
    {
        visualList = new Transform[visualAmount];
        visualScale = new float[visualAmount];

        for (int i = 0; i < visualAmount; ++i)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            visualList[i] = go.transform;
            visualList[i].position = Vector3.up * 10;

            visualList[i].RotateAround(Vector3.zero, Vector3.forward, (360 / visualAmount) * i);

        }
    }

    public void VisualizeSound()
    {
        int spectrumIndex = 0;
        int avgSize = (int)(SAMPLE_SIZE * keeppercentage)/ visualAmount;

        for (int i = 0; i < visualAmount; ++i)
        {
            float sum = 0;
            for (int j = 0; j < avgSize; ++j)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
            }

            float scaleY = sum / avgSize * visualModifier;
            visualScale[i] = Time.deltaTime * smoothSpeed;
            if (visualScale[i] < scaleY)
                visualScale[i] = scaleY;

            if (visualScale[i] > visualScaleMax)
                visualScale[i] = visualScaleMax;


            visualList[i].localScale = Vector3.one + Vector3.up * visualScale[i];
        }

    }
}
