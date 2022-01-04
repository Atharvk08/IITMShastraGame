using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpikeTileScript : MonoBehaviour
{
    public Sprite spiderKillSprite;
    
    [SerializeField] private GameObject playerBlood;
    [SerializeField] private GameObject enemyBlood;
    public float lifetime = 2f;
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
        Instantiate(playerBlood, other.transform.position, Quaternion.identity);
        //StartCoroutine("waitTimeToDestroy", other);
        Destroy(other);
        Debug.Log("player destroyed");
    }
    void DestroyEnemy(GameObject enemy)
    {
        Instantiate(enemyBlood, enemy.transform.position, Quaternion.identity);
        //StartCoroutine("waitTimeToDestroy", enemy);
        Destroy(enemy);
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();
        rend.sprite = spiderKillSprite;

        Debug.Log("enemy destroyed");
    }

    IEnumerator waitTimeToDestroy(GameObject other)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(other);
    }
}
