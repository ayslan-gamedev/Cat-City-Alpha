using CatCity;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

[AddComponentMenu("Cat City/Dynamics/Infinity")]
public class Infinity : MonoBehaviour
{
    public GameObject[] objectsToInstantiate;
    public float timeToNextObject;

    GlobalValues globalVariables;

    public Player player;
    // temp variables

    private Transform playerTransform;

    void Start()
    {
        lastObject = gameObject;

        globalVariables = new GlobalValues();
        playerTransform = GameObject.Find(globalVariables.PLAYER_NAME).GetComponent<Transform>();
    }

    private int objectIndex;

    void Instantiate()
    {
        Vector2 position = playerTransform.position;
        lastObject = Instantiate(objectsToInstantiate[objectIndex], position, transform.rotation, transform);
        objectIndex++;
    }

    private GameObject lastObject;

    private bool LastObejctIsNotVisible()
    {
        Vector2 distanceBettenLastObject = lastObject.transform.position - player.transform.position;
        float minDistance = 10;

        if((distanceBettenLastObject.x > minDistance || distanceBettenLastObject.x < -minDistance) && (distanceBettenLastObject.y > minDistance || distanceBettenLastObject.y < -minDistance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [SerializeField] private float currentDistanceWalked;

    public void CalculateNextPoint()
    {
        Debug.Log(LastObejctIsNotVisible());
        if(player.PlayerInMovement())
        {
            currentDistanceWalked += Time.deltaTime;
        }

        if(currentDistanceWalked > timeToNextObject && LastObejctIsNotVisible())
        {
            Instantiate();
            currentDistanceWalked = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateNextPoint();
    }
}
