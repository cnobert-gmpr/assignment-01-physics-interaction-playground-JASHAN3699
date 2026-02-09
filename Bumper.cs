using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force = 600f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>()
                .AddForce(Vector2.up * force);
        }
    }
}
