using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TeleportZone : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _timeRequired = 2f;
    [SerializeField] private Vector2 _teleportPosition;

    // Track players and their timers
    private Dictionary<Transform, float> _playerTimers = new Dictionary<Transform, float>();
    private HashSet<Transform> _teleportingPlayers = new HashSet<Transform>();

    private void Update()
    {
        // Copy keys to avoid modifying collection during iteration
        var players = new List<Transform>(_playerTimers.Keys);

        foreach (var player in players)
        {
            if (player == null) continue;

            _playerTimers[player] += Time.deltaTime;

            if (_playerTimers[player] >= _timeRequired && !_teleportingPlayers.Contains(player))
            {
                StartCoroutine(TeleportRoutine(player));
            }
        }
    }

    private IEnumerator TeleportRoutine(Transform player)
    {
        _teleportingPlayers.Add(player);

        // Get THIS player's fader
        ScreenFader fader = player.GetComponentInChildren<ScreenFader>();
        Debug.Log($"Player {player.name} entered teleport routine. Fader found: {fader != null}");

        if (fader != null)
        {
            yield return fader.FadeOut();
            Debug.Log("Fading out...");
            }
        else
            Debug.LogWarning($"No ScreenFader found for player {player.name}!");

        // teleport only this player
        player.position = _teleportPosition;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.MovePosition(player.position); // Ensure physics updates to new position immediately
            rb.linearVelocity = Vector2.zero;
        }

        yield return new WaitForSeconds(0.2f);

        if (fader != null) 
            yield return fader.FadeIn();
            Debug.Log("Fading in...");

        _playerTimers.Remove(player);
        _teleportingPlayers.Remove(player);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform player = collision.transform;

            if (!_playerTimers.ContainsKey(player))
            {
                _playerTimers[player] = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform player = collision.transform;

            if (_playerTimers.ContainsKey(player))
            {
                _playerTimers.Remove(player);
            }
        }
    }
}