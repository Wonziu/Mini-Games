﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public List<PowerUp> PowerUps;
    public PowerUpHolder PowerUpObject;

    public int TopPoints = 0;
    public int BottomPoints = 0;

    public Ball myBall;

    public CanvasGroup Buttons;

    public Text TopScore;
    public Text BottomScore;

    public GameObject VerticalWall;
    public Button[] ControlButtons;

    private float screenWidth;
    private float screenHeight;
    private float screenAspect;

    public Text FPS;

    void Awake()
    { 
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        screenWidth = Camera.main.pixelWidth;
        screenHeight = Camera.main.pixelHeight;

        screenAspect = screenWidth / screenHeight;
    }

    void Update()
    {
        float msec = Time.deltaTime * 1000.0f;
        float fps = 1.0f / Time.deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        FPS.text = text;
    }

    void Start ()
	{       
        SetupBoard();
        StartCoroutine(StartGame());   
        CreatePowerUp();
    }

    void SetupBoard()
    {
        SetScoreTextSize();
        SetBorders();
        SetButtonsSize();
        SetCollidersSize();

        Invoke("DisappearButtons", 5);
    }
	
    void SetBorders()
    {
        Instantiate(VerticalWall, new Vector3(Camera.main.orthographicSize * screenAspect, 0, 0), Quaternion.identity);
        Instantiate(VerticalWall, new Vector3(Camera.main.orthographicSize * -screenAspect, 0, 0), Quaternion.identity);
    }

    void SetButtonsSize()
    {
        foreach (var controlButton in ControlButtons)
            controlButton.image.rectTransform.sizeDelta = new Vector2(screenWidth / 2 - 10, screenHeight / 2 - 10);
    }

    void SetScoreTextSize()
    {
        TopScore.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, screenHeight / 2);
        BottomScore.rectTransform.sizeDelta = new Vector2(0, screenHeight / 2);
    }

    void SetCollidersSize()
    {
        foreach (BoxCollider2D col in GetComponents<BoxCollider2D>())
            col.size = new Vector2(Camera.main.orthographicSize * screenAspect * 2, 1);
    }

    IEnumerator StartGame()
    {
        myBall.ResetBall();
        
        yield return new WaitForSeconds(1);

        myBall.StartBall();
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.collider.transform.position.y > 0)
        {
            BottomPoints += 1;
            BottomScore.text = BottomPoints.ToString();
        }
        else
        {
            TopPoints += 1;
            TopScore.text = TopPoints.ToString();
        }

        StartCoroutine(StartGame());
    }

    void DisappearButtons()
    {
        Buttons.alpha = 0;
    }

    void CreatePowerUp()
    {
        var d = PowerUps[Random.Range(0, PowerUps.Count)];

        PowerUpObject.gameObject.SetActive(true);
        PowerUpObject.GetComponent<SpriteRenderer>().sprite = d.PowerUpImage;
        PowerUpObject.PowerUp = d;

    }
}