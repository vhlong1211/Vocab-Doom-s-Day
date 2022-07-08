using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SimplePool
{
    static int DEFAULT_AMOUNT = 5;
    //pool tong
    static Dictionary<GameObject, Pool> poolObjects = new Dictionary<GameObject, Pool>();

    //tim pool cha cua thang object
    static Dictionary<GameObject, Pool> poolParents = new Dictionary<GameObject, Pool>();

    public static void Preload(GameObject prefab, int amount, Transform parent)
    {
        if (!poolObjects.ContainsKey(prefab))
        {
            poolObjects.Add(prefab, new Pool(prefab, amount, parent));
        }
    }

    public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj = null;

        if (!poolObjects.ContainsKey(prefab) || poolObjects[prefab] == null)
        {
            poolObjects.Add(prefab, new Pool(prefab, DEFAULT_AMOUNT, null));
        }

        obj = poolObjects[prefab].Spawn(position, rotation);

        return obj;
    }

    public static void Despawn(GameObject obj)
    {
        if (poolParents.ContainsKey(obj))
        {
            poolParents[obj].Despawn(obj);
        }
        else
        {
            GameObject.Destroy(obj);
        }
    }

    public static void CollectAll()
    {
        foreach (var item in poolObjects)
        {
            item.Value.Collect();
        }
    }

    public static void ReleaseAll()
    {
        foreach (var item in poolObjects)
        {
            item.Value.Release();
        }
    }

    public class Pool
    {
        Queue<GameObject> pools = new Queue<GameObject>();
        List<GameObject> activeObjs = new List<GameObject>();
        Transform parent;
        GameObject prefab;

        public Pool(GameObject prefab, int amount, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;

            for (int i = 0; i < amount; i++)
            {
                GameObject obj = GameObject.Instantiate(prefab, parent);
                poolParents.Add(obj, this);
                pools.Enqueue(obj);
                obj.gameObject.SetActive(false);
            }
        }

        public GameObject Spawn(Vector3 position, Quaternion rotation)
        {
            GameObject obj = null;

            if (pools.Count == 0)
            {
                obj = GameObject.Instantiate(prefab, parent);
                poolParents.Add(obj, this);
            }
            else
            {
                obj = pools.Dequeue();
            }

            obj.transform.SetPositionAndRotation(position, rotation);
            obj.gameObject.SetActive(true);

            activeObjs.Add(obj);

            return obj;
        }

        public void Despawn(GameObject obj)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                activeObjs.Remove(obj);
                pools.Enqueue(obj);
                obj.gameObject.SetActive(false);
            }
        }

        public void Collect()
        {
            while (activeObjs.Count > 0)
            {
                Despawn(activeObjs[0]);
            }
        }

        public void Release()
        {
            Collect();

            while (pools.Count > 0)
            {
                GameObject obj = pools.Dequeue();
                GameObject.DestroyImmediate(obj);
            }
        }

    }
}
