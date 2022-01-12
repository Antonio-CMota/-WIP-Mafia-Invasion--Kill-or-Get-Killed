using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4Behave : MonoBehaviour
{
    public bool isCoroutineExecuting;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("explosao");
    }

   IEnumerator explosao()
    {
        Debug.Log("Start");

        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        Debug.Log(2);

        yield return new WaitForSeconds(5f);

        Debug.Log("KABUM CHOURA");

        Destroy(gameObject);
    }
}
