using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgMaint : MonoBehaviour
{
    public GameObject progMaintainer;
    public GameObject progInhibiter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        progMaintainer.SetActive(true);
        StartCoroutine(ridWall(1.5f));
    }
    private IEnumerator ridWall(float delay)
    {
        yield return new WaitForSeconds(delay);
        progInhibiter.SetActive(false);
    }
}
