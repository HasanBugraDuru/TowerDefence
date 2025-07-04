using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;


    private List<GameObject> _pool;
    private GameObject _poolContainer;
    private void Awake()
    {
        _pool = new List<GameObject>();
        _poolContainer = new GameObject($"Pool - {prefab.name}");
        CreatePooler();
    }

    private void CreatePooler()
    {
        for (int i = 0; i < poolSize; i++) 
        {
            _pool.Add(CreateIstance());
        }
    }
    public GameObject GerInstanceFromPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].activeInHierarchy) return _pool[i];
        }
        return CreateIstance();
    }
    private GameObject CreateIstance()
    {
        GameObject newIstance = Instantiate(prefab);
        newIstance.transform.SetParent(_poolContainer.transform);
        newIstance.SetActive(false);
        return newIstance;
    }

    public static void ReturnToPool(GameObject _istance)
    {
        _istance.SetActive(false);
    }
}
