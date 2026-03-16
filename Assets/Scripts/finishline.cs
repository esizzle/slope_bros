using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class finishline : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI winnerText2;

    private bool raceFinished = false;

    void Update()
    {
        if (raceFinished && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!raceFinished && collision.CompareTag("Player"))
        {
            raceFinished = true;

            winnerText.gameObject.SetActive(true);
            winnerText.text = collision.gameObject.name + " Wins!\n\nPress Enter to Continue";

            winnerText2.gameObject.SetActive(true);
            winnerText2.text = collision.gameObject.name + " Wins!\n\nPress Enter to Continue";
        }
    }
}
