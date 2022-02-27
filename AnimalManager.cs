using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    public GameObject[] animalPrefabs;
    public Animal curAnimal;

    public Transform canvas;

    public static AnimalManager instance;

    void Awake() {
        instance = this;
    }

    // Spawn Animal
    public void SpawnAnimal() {
        GameObject animalToSpawn = animalPrefabs[Random.Range(0, animalPrefabs.Length)];
        GameObject obj = Instantiate(animalToSpawn, canvas);

        curAnimal = obj.GetComponent<Animal>();
    }

    // Replace Animal
    public void ReplaceAnimal(GameObject animal) {
        Destroy(animal);
        SpawnAnimal();
    }
}