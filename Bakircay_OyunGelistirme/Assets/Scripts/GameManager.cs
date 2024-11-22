using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int targetObjectsToDestroy; 
    private int destroyedObjectsCount = 0; 

    public void ObjectDestroyed()
    {
        
        destroyedObjectsCount++;

        
        if (destroyedObjectsCount >= targetObjectsToDestroy)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over! All objects have been destroyed.");

        
        Time.timeScale = 0;
    }
}
