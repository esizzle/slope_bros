using System.Collections;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    private int collisionCount = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionCount++;
            //Debug.Log(collisionCount);

            if (collisionCount == 1)
            {
                SoundManager.Instance.PlaySled();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionCount--;
            //Debug.Log(collisionCount);

            StartCoroutine(WaitAndCheck());
        }
    }

    IEnumerator WaitAndCheck()
    {
        yield return new WaitForSeconds(0.25f);
        if (collisionCount == 0)
        {
            SoundManager.Instance.StopSled();
        }
    }
}