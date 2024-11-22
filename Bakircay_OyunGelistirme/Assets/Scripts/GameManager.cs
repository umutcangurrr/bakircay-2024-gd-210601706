using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int targetObjectsToDestroy; // Yok edilmesi gereken toplam nesne sayýsý
    private int destroyedObjectsCount = 0; // Þimdiye kadar yok edilen nesne sayýsý

    public void ObjectDestroyed()
    {
        // Yok edilen nesne sayýsýný artýr
        destroyedObjectsCount++;

        // Eðer tüm nesneler yok edildiyse oyunu bitir
        if (destroyedObjectsCount >= targetObjectsToDestroy)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over! All objects have been destroyed.");

        // Oyun simülasyonunu durdur
        Time.timeScale = 0;
    }
}
