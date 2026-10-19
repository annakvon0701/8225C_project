using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinCountText;

    public void UpdateCoinText(int coins)
    {
        coinCountText.text = "Coins: " + coins;
    }
}