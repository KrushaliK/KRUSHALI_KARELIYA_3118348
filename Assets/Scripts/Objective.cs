using UnityEngine;

public class Objective : MonoBehaviour
{
    private AudioSource audioSource;
    private GameManager gameManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnPickup()
    {
        gameManager.AddScore();
        audioSource.Play();
        gameObject.SetActive(false);
    }
}
