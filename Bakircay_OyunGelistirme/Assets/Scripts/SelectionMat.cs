using UnityEngine;

public class SelectionMat : MonoBehaviour
{
    public SelectionMat otherMat;
    public GameManager gameManager; // GameManager referansı

    private GameObject currentObject;

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        CheckForMatch();
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentObject == other.gameObject)
        {
            currentObject = null;
        }
    }

    private void CheckForMatch()
    {
        if (otherMat != null && otherMat.currentObject != null)
        {
            if (GetBaseName(currentObject.name) == GetBaseName(otherMat.currentObject.name))
            {
                // Yok edilmeden önce GameManager'a bilgi ver
                gameManager.ObjectDestroyed();
                gameManager.ObjectDestroyed();

                // Nesneleri yok et
                Destroy(currentObject);
                Destroy(otherMat.currentObject);

                currentObject = null;
                otherMat.currentObject = null;
            }
        }
    }

    private string GetBaseName(string name)
    {
        int index = name.IndexOf(" (");
        if (index >= 0)
        {
            return name.Substring(0, index);
        }
        return name;
    }
}
