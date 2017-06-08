using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class StandaloneFPSCounter : MonoBehaviour
{

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private Text fps;   // Use this for initialization
    void Start()
    {
        fps = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fps.text = GetFPS();
    }

    private string GetFPS()
    {
        return string.Format("{0:0.0} ms ({1:0.} fps)", Time.deltaTime * 1000.0f, 1.0f / Time.deltaTime);
    }
}
