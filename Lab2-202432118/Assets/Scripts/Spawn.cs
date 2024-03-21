using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject model;

    private Vector3[] vector3s;
    private bool fillVecs = false;
    private float moveSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        GameObject instant;
        if (Input.GetKeyDown(KeyCode.C))
        {
            var position = new Vector3(Random.Range(-5f, 5f), Random.Range(1, 5f), Random.Range(-5f, 5f));
            instant = Instantiate(model, position, Random.rotation);

            instant.transform.parent = transform;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            fillVecs = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject go = transform.GetChild(i).gameObject;
                Destroy(go);
            }
        }

        if (fillVecs)
        {
            vector3s = new Vector3[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                vector3s[i] = Random.insideUnitSphere;
            }
            fillVecs = false;
        }

        if (vector3s.Length > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                child.transform.Translate(vector3s[i] * moveSpeed * Time.deltaTime);
            }
        }
    }
}
