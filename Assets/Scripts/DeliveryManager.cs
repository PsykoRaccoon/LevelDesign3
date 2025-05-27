using UnityEngine;
using TMPro;
using System.Collections;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;

    public TextMeshProUGUI feedbackText;
    public float feedbackDuration;

    public int totalRequiredDeliveries;
    public int currentDeliveries;
    public GameObject bossPrefab;
    public GameObject boxPrefab;
    public Transform spawnPoint;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterDelivery()
{
    currentDeliveries++;

    ShowFeedback("¡Paquete entregado!");

    if (currentDeliveries >= totalRequiredDeliveries)
    {
        ShowFeedback("¡Cuidado con este vecino!");
        SpawnBoss();
    }
}

    void SpawnBoss()
    {
        if (bossPrefab != null && spawnPoint != null)
        {
            Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(boxPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void ShowFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(HideFeedbackAfterDelay());
        }
    }

    IEnumerator HideFeedbackAfterDelay()
    {
        yield return new WaitForSeconds(feedbackDuration);
        feedbackText.gameObject.SetActive(false);
    }
}
