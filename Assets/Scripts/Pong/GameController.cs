using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public int PowerUpChance;
    public List<Shield> PlayerShields;
    public List<PowerUp> PowerUps;
    private List<Vector2> PowerUpsPositions;
    public PowerUpHolder PowerUpObject;

    private int TopPoints = 0;
    private int BottomPoints = 0;

    public Ball myBall;

    public CanvasGroup Buttons;

    public Text TopScore;
    public Text BottomScore;

    public Shield PlayerShield;
    public GameObject VerticalWall;
    public Button[] ControlButtons;

    private float gameWidth;

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

        gameWidth = Camera.main.orthographicSize * screenAspect;
    }

    void Start ()
	{       
        SetupBoard();
        StartCoroutine(StartGame());
	}

    void SetupBoard()
    {
        SetPowerUpsPositions();
        SetScoreTextSize();
        SetBorders();
        SetButtonsSize();
        SetCollidersSize();
        SetShieldsSize();
        

        Invoke("DisappearButtons", 5);
    }
	
    void SetBorders()
    {
        Instantiate(VerticalWall, new Vector3(gameWidth, 0, 0), Quaternion.identity);
        Instantiate(VerticalWall, new Vector3(gameWidth * -1, 0, 0), Quaternion.identity);
    }

    void SetButtonsSize()
    {
        foreach (var controlButton in ControlButtons)
            controlButton.image.rectTransform.sizeDelta = new Vector2(screenWidth / 2 - 10, screenHeight / 2 - 10);
    }

    void SetScoreTextSize()
    {
        TopScore.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, screenHeight / 2 - 50);
        BottomScore.rectTransform.sizeDelta = new Vector2(0, screenHeight / 2 - 50);
    }

    void SetCollidersSize()
    {
        foreach (BoxCollider2D col in GetComponents<BoxCollider2D>())
            col.size = new Vector2(gameWidth * 2, 1);
    }

    void SetPowerUpsPositions()
    {
        PowerUpsPositions = new List<Vector2>();

        for (int i = 1; i < 4; i++)
        {
            var p = new Vector2(gameWidth * 0.25f * i, 0);
            var p2 = new Vector2(-gameWidth * 0.25f * i, 0);
            
            PowerUpsPositions.Add(p);
            PowerUpsPositions.Add(p2);
        }
    }

    IEnumerator StartGame()
    {
        myBall.ResetBall();
        
        yield return new WaitForSeconds(1);

        myBall.StartBall();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.position.y > 0)
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

    public void CreatePowerUp()
    {
        PowerUpObject.transform.position = PowerUpsPositions[Random.Range(0, PowerUpsPositions.Count)];
        var powerUp = PowerUps[Random.Range(0, PowerUps.Count)];
       
        PowerUpObject.GetComponent<SpriteRenderer>().sprite = powerUp.PowerUpImage;
        PowerUpObject.PowerUp = powerUp;

        PowerUpObject.isPowerUpActive = true;
        PowerUpObject.gameObject.SetActive(true);
    }

    public void PowerUpsGenerator()
    {
        var rand = Random.Range(0, 100);

        if (rand < PowerUpChance)
        {
            if (!PowerUpObject.isPowerUpActive)
                CreatePowerUp();
        }
    }

    public void SetShieldsSize()
    {
        foreach (var shield in PlayerShields)
        {          
            var scale = shield.transform.localScale;
            scale.x = gameWidth * 2;

            shield.transform.localScale = scale;
        }
    }
}