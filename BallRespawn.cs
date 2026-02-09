using UnityEngine;
using System.Collections;

public class BallRespawn : MonoBehaviour
{
    private Vector2 spawnPos;
    private float delay;

    public void Initialize(Vector2 pos, float respawnDelay)
    {
        spawnPos = pos;
        delay = respawnDelay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        transform.position = spawnPos;
        gameObject.SetActive(true);
    }
}
