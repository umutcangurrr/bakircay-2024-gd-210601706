using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int targetObjectsToDestroy; // Yok edilmesi gereken toplam nesne say�s�
    private int destroyedObjectsCount = 0; // �imdiye kadar yok edilen nesne say�s�

    public void ObjectDestroyed()
    {
        // Yok edilen nesne say�s�n� art�r
        destroyedObjectsCount++;

        // E�er t�m nesneler yok edildiyse oyunu bitir
        if (destroyedObjectsCount >= targetObjectsToDestroy)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over! All objects have been destroyed.");

        // Oyun sim�lasyonunu durdur
        Time.timeScale = 0;
    }
}