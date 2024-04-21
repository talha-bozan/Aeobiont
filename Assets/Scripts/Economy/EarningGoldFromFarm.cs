using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using Unity.VisualScripting;

public class EarningGoldFromFarm : MonoBehaviour
{
    [SerializeField] private int gemReward = 10; 
    [SerializeField] private float earningInterval = 2.0f; // Time between each reward

    private CancellationTokenSource cancellationTokenSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Gem playerGem = other.GetComponent<Gem>();
            if (playerGem != null && cancellationTokenSource == null)
            {
                cancellationTokenSource = new CancellationTokenSource();
                EarnGoldOverTime(playerGem, cancellationTokenSource.Token).Forget();
                Debug.Log("Player started earning gem at intervals.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
                Debug.Log("Player stopped earning gem.");
            }
        }
    }

    private async UniTask EarnGoldOverTime(Gem playerGem, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested) // Keep earning gold until cancelled
        {
            await UniTask.Delay((int)(earningInterval * 1000), cancellationToken: cancellationToken); // Wait for the earning interval
            playerGem.changeBalance(gemReward); // Increase the gem balance
            Debug.Log($"Player earned {gemReward} gem.");
        }
    }
}
