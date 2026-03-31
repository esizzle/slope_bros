using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    public SpriteRenderer icon;

    private void Awake()
    {
       icon = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!icon.enabled) return;

        if (collision.CompareTag("Player"))
        {
            Transform player = collision.transform;
            PowerupManager.Instance.GetRandomPowerUp(player);

            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        if (!icon.enabled) yield break;
        icon.enabled = false;

        yield return new WaitForSeconds(2f);

        icon.enabled = true;
    }
}
