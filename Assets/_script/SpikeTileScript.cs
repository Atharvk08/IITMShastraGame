using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpikeTileScript : MonoBehaviour
{
    public Sprite spiderKillSprite;
    
    [SerializeField] private GameObject playerBlood;
    [SerializeField] private GameObject enemyBlood;
    [SerializeField] private GameObject playerGFX;
    [SerializeField] private GameObject spiderGFX;
    [SerializeField] private GameObject restartMenu;
    Animator spikeAnim;
    public float lifetime = 2f;

    private void Start()
    {
        spikeAnim = GetComponent<Animator>();
    }
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
        Destroy(playerGFX);
        Debug.Log("player destroyed");
        RestartMenu();
    }
    void DestroyEnemy(GameObject enemy)
    {
        Instantiate(enemyBlood, enemy.transform.position, Quaternion.identity);
        //StartCoroutine("waitTimeToDestroy", enemy);
        spiderGFX.SetActive(false);
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();
        spikeAnim.enabled = false;
        rend.sprite = spiderKillSprite;

        Debug.Log("enemy destroyed");
    }

    IEnumerator waitTimeToDestroy(GameObject other)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(other);
    }
    public void RestartMenu()
    {
        //Time.timeScale = 0;
        new WaitForSeconds(2f);
        restartMenu.SetActive(true);
    }
}
