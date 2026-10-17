using UnityEngine;

public class ColorGate : MonoBehaviour
{
    public BallColor gateColor;
    private Collider gateCollider;

    void Awake()
    {
        gateCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            if (player != null && player.currentColor == gateColor)
            {
                gateCollider.enabled = false;
            }
        }
    }
}