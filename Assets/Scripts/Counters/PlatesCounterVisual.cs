using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;

    private List<GameObject> palteVisualGameObjects;
    private void Awake() {
        palteVisualGameObjects = new List<GameObject>();
    }
    private void Start() {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0,plateOffsetY * palteVisualGameObjects.Count,0);

        palteVisualGameObjects.Add(plateVisualTransform.gameObject);
    }
    private void PlatesCounter_OnPlateRemoved(object sender, EventArgs e)
    {
        GameObject plateGameObject = palteVisualGameObjects[palteVisualGameObjects.Count - 1];
        palteVisualGameObjects.Remove(plateGameObject);
        Destroy(plateGameObject);
    }
}
