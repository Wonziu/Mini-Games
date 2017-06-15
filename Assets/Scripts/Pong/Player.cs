using UnityEngine;

public class Player : MonoBehaviour
{
    public Player Enemy;
    private Rigidbody2D myRigidBody;
    public Vector2 PlayerScale;
    public Shield MyShield;

    private int verticalSide;
    private bool isLeftButtonClicked;
    private bool isRightButtonClicked;
    public float PlayerSpeed;
    public float PlayerBoostSpeed;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        PlayerScale = transform.localScale;
    }

    void FixedUpdate()
    {
        myRigidBody.velocity = new Vector2(verticalSide * PlayerSpeed * PlayerBoostSpeed, 0);
    }

    public void OnButtonDown(bool l) // for left side, it will be true, for right - false
    {   
        isLeftButtonClicked = l;
        isRightButtonClicked = !l;

        if (isLeftButtonClicked)
            verticalSide = -1;
        else verticalSide = 1;
    }

    public void OnLeftButtonUp()
    {
        isLeftButtonClicked = false;

        if (!isRightButtonClicked)
            verticalSide = 0;
    }

    public void OnRightButtonUp()
    {
        isRightButtonClicked = false;

        if (!isLeftButtonClicked)
            verticalSide = 0;
    }

    public void EnableShield()
    {
        MyShield.gameObject.SetActive(true);
    }
}