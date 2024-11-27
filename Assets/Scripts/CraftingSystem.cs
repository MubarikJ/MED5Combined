using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    [Header("Crafting Outputs")]
    public GameObject daggerPrefab;
    public GameObject swordPrefab;

    [Header("Spawn Point")]
    public Transform spawnPoint;

    private int ingotCount = 0;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the anvil's trigger is an ingot
        if (other.CompareTag("Ingot"))
        {
            ingotCount++;

            // Destroy ingot when it interacts with the anvil
            Destroy(other.gameObject);
        }

        // Check crafting conditions
        CheckCrafting();
    }

    void CheckCrafting()
    {
        if (ingotCount == 2)
        {
            // Spawn a dagger
            Instantiate(daggerPrefab, spawnPoint.position, Quaternion.identity);
            ResetCrafting();
        }
        else if (ingotCount == 3)
        {
            // Spawn a sword
            Instantiate(swordPrefab, spawnPoint.position, Quaternion.identity);
            ResetCrafting();
        }
    }

    void ResetCrafting()
    {
        // Reset the ingot counter
        ingotCount = 0;
    }
}
