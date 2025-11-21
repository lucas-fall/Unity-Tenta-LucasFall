using UnityEngine;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class BoxCounter : MonoBehaviour
{
    [Header("Current Number of Boxes")]
    [SerializeField] private int boxCount = 0;

    [Header("Optional UI Display")]
    [SerializeField] private TextMeshProUGUI counterText;

    [Header("Events")]
    public IntEvent OnCountChanged;

    void Start()
    {
        // Make sure UI shows the starting value
        UpdateUI();
    }

    // Returns the current box count
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
        // Update UI (if assigned)
        UpdateUI();

        // Trigger UnityEvent
        OnCountChanged?.Invoke(boxCount);
    }

    private void UpdateUI()
    {
        if (counterText != null)
            counterText.text = "Boxes: " + boxCount;
    }
}