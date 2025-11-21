using UnityEngine;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class BoxCounter : MonoBehaviour
{
    [Header("Current Number of Boxes")]
    [SerializeField] private int boxCount = 0;

    [Header("Goal Settings")]
    public int goalCount = 5;               // The target number of boxes
    public UnityEvent OnReachedGoal;        // Fires when boxCount == goalCount
    private bool goalReached = false;       // Prevents repeating the event

    [Header("Optional UI Display")]
    [SerializeField] private TextMeshProUGUI counterText;

    [Header("Events")]
    public IntEvent OnCountChanged;         // Fires on every count update

    void Start()
    {
        UpdateUI(); // Initialize UI on start
    }

    public int GetCount()
    {
        return boxCount;
    }

    public void AddBox()
    {
        boxCount++;
        CountChanged();
    }

    public void RemoveBox()
    {
        boxCount = Mathf.Max(0, boxCount - 1);
        CountChanged();
    }

    public void SetCount(int newCount)
    {
        boxCount = Mathf.Max(0, newCount);
        CountChanged();
    }

    private void CountChanged()
    {
        UpdateUI();
        OnCountChanged?.Invoke(boxCount);

        // --- Goal Check ---
        if (!goalReached && boxCount == goalCount)
        {
            goalReached = true;
            OnReachedGoal?.Invoke();
        }
    }

    private void UpdateUI()
    {
        if (counterText != null)
            counterText.text = "Boxes: " + boxCount;
    }
}