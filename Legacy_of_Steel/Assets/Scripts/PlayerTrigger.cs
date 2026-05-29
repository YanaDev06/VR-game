using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Проверяем все объекты рядом с игроком
        Collider[] hits = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider hit in hits)
        {
            CoinCollect coin = hit.GetComponent<CoinCollect>();
            if (coin != null)
            {
                coin.Collect();
            }
        }
    }
}
