using UnityEngine;

public class Target : MonoBehaviour
{
    private float resetTime;

    public void Initialize(float time)
    {
        resetTime = time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke(nameof(ResetTarget), resetTime);
        }
    }

    void ResetTarget()
    {
        gameObject.SetActive(true);
    }
}
