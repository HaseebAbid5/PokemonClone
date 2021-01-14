using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScene : MonoBehaviour {

    [Header("Variables")]
    public float xDistance;
    public float yDistance;
    public float roateSpeed;

    [Header("Transforms References")]
    public Transform animalsParentTransform;
    public Transform cameraTransform;
    public Transform center;

    [Header("Animal Meshes")]
    public GameObject bunny;
    public GameObject fox;
    public GameObject hedgehog;
    public GameObject husky;
    public GameObject kiwi;
    public GameObject owl;
    public GameObject pug;
    public GameObject raccoon;

    [Header("Animal Textures")]
    public List<Texture> bunnyTextures;
    public List<Texture> foxTextures;
    public List<Texture> hedgehogTextures;
    public List<Texture> huskyTextures;
    public List<Texture> kiwiTextures;
    public List<Texture> owlTextures;
    public List<Texture> pugTextures;
    public List<Texture> raccoonTextures;


    GameObject animalToSpawn;
    Texture selectedTexture;
    List <Texture> selectedTextures;

    public void PlaceAnimals() {

        

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                SelectAnimal(x);

                GameObject spawnedAnimal = Instantiate(animalToSpawn, animalsParentTransform) as GameObject;

                spawnedAnimal.transform.position = new Vector3(x*xDistance, 0, -y*yDistance);
                spawnedAnimal.GetComponentInChildren<SkinnedMeshRenderer>().material.SetTexture("_MainTex", selectedTextures[y]);
            }
        }
    }

    void Start() {
        PlaceAnimals();
        PlaceCamera();
        SetCenterOfEverything();
    }

    public void SelectAnimal(int x) {

        switch (x)
        {
            case 0:
                animalToSpawn = bunny;
                selectedTextures = null;
                selectedTextures = bunnyTextures;
                break;

            case 1:
                animalToSpawn = fox;
                selectedTextures = null;
                selectedTextures = foxTextures;
                break;

            case 2:
                animalToSpawn = hedgehog;
                selectedTextures = null;
                selectedTextures = hedgehogTextures;
                break;

            case 3:
                animalToSpawn = husky;
                selectedTextures = null;
                selectedTextures = huskyTextures;
                break;

            case 4:
                animalToSpawn = kiwi;
                selectedTextures = null;
                selectedTextures = kiwiTextures;
                break;

            case 5:
                animalToSpawn = owl;
                selectedTextures = null;
                selectedTextures = owlTextures;
                break;

            case 6:
                animalToSpawn = pug;
                selectedTextures = null;
                selectedTextures = pugTextures;
                break;

            case 7:
                animalToSpawn = raccoon;
                selectedTextures = null;
                selectedTextures = raccoonTextures;
                break;

            default:
                break;
        }
    }

    public void PlaceCamera() {

        float cameraPositionX = (xDistance * 7)/2 ; 
        cameraTransform.position = new Vector3(cameraPositionX, 
            cameraTransform.position.y, 
            cameraTransform.position.z);
    }

    public void SetCenterOfEverything() {
        float centerX = xDistance * 7 / 2;
        float centerY = yDistance * 7 / 2;
        center.position = new Vector3(centerX, 0 , -centerY);
        cameraTransform.SetParent(center);
    }

    void Update() {
        center.RotateAround(Vector3.up, roateSpeed * Time.deltaTime);
    }

}
