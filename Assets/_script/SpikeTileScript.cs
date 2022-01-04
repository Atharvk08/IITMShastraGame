using UnityEngine;

public class SpikeTileScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyPlayer(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            DestroyEnemy(collision.gameObject);
        }
    }

    void DestroyPlayer(GameObject other)
    {
        Destroy(other);
        Debug.Log("player destroyed");
    }
    void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
        Debug.Log("enemy destroyed");
    }
}
