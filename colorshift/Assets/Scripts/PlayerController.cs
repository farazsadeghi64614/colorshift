using UnityEngine;
using UnityEngine.SceneManagement;

public enum BallColor { Red, Blue, Green, Yellow }

public class PlayerController : MonoBehaviour
{
    public BallColor currentColor = BallColor.Red;
    [SerializeField] private float speed = 10f;

    private Renderer rend;
    private Rigidbody rb;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        SetColor(currentColor);
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetColor(BallColor newColor)
    {
        currentColor = newColor;

        switch (currentColor)
        {
            case BallColor.Red:
                rend.material.color = Color.red;
                break;
            case BallColor.Blue:
                rend.material.color = Color.blue;
                break;
            case BallColor.Green:
                rend.material.color = Color.green;
                break;
            case BallColor.Yellow:
                rend.material.color = Color.yellow;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedPillar"))
        {
            SetColor(BallColor.Red);
        }
        else if (other.CompareTag("BluePillar"))
        {
            SetColor(BallColor.Blue);
        }
        else if (other.CompareTag("GreenPillar"))
        {
            SetColor(BallColor.Green);
        }
        else if (other.CompareTag("YellowPillar"))
        {
            SetColor(BallColor.Yellow);
        }
    }
}