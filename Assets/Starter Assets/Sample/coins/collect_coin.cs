using UnityEngine;

public class collect_coin : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private UpdateUI updateUI;
    
    private int coinsCollected = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCollected++;
            
            updateUI.UpdateCoinText(coinsCollected);
            
            effect.transform.position = other.transform.position;
            effect.Play();
        }
    }
}
