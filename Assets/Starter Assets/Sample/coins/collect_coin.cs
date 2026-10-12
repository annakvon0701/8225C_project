using UnityEngine;

public class collect_coin : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            collect_coin+;

            effect.trasform.position = otner.transform.position;
            effectPlay();
        }
    }
    
}
