using System.Collections.Generic;
using UnityEngine;

public class MatManager : MonoBehaviour
{
    public static MatManager Instance { get; private set; }

    private readonly Dictionary<string, List<Collider>> _taggedObjects = new Dictionary<string, List<Collider>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterObject(string tag, Collider obj)
    {
        if (!_taggedObjects.ContainsKey(tag))
        {
            _taggedObjects[tag] = new List<Collider>();
        }

        _taggedObjects[tag].Add(obj);
        CheckAndDestroy(tag);
    }

    public void UnregisterObject(string tag, Collider obj)
    {
        if (_taggedObjects.ContainsKey(tag))
        {
            _taggedObjects[tag].Remove(obj);

            if (_taggedObjects[tag].Count == 0)
            {
                _taggedObjects.Remove(tag);
            }
        }
    }

    private void CheckAndDestroy(string tag)
    {
        if (_taggedObjects.ContainsKey(tag) && _taggedObjects[tag].Count == 2)
        {
            Debug.Log($"Two objects with tag {tag} detected on different mats. Destroying...");

            foreach (var obj in _taggedObjects[tag])
            {
                Destroy(obj.gameObject);
            }

            _taggedObjects.Remove(tag);
        }
    }
}
