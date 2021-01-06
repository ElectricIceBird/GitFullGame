using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
       [System.Serializable]
   public class wave
   {
       public Enemy[] enemies;
       public int count;
       public float timebtwSpawn;
   }
   public wave[] waves;
   public Transform[] spawnPoints;
   public float timeBtwWaves;
   private wave currentwave;
   private int currentwaveIndex;
   private Transform player;
   private bool finsedSpawning;
  
   void Start()
   {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       StartCoroutine(StartNextWave(currentwaveIndex));
   }
   IEnumerator StartNextWave(int index)
   {
       yield return new WaitForSeconds(timeBtwWaves);
       StartCoroutine(SpawnWave(index));
   }
   IEnumerator SpawnWave(int index)
   {
       currentwave = waves[index];
      for(int i = 0; i < currentwave.count; i++)
      {
          if(player == null)
          {
              yield break;
          }
          Enemy randomEnemy = currentwave.enemies[Random.Range(0,currentwave.enemies.Length)];
          Transform randomSpot = spawnPoints[Random.Range(0,spawnPoints.Length)];
          Instantiate(randomEnemy,randomSpot.position,randomSpot.rotation);
          yield return new WaitForSeconds(currentwave.timebtwSpawn);
          if(i == currentwave.count - 1)
          {
              finsedSpawning = true;
          }
          else
          {
              finsedSpawning = false;
          }
          if(finsedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 )
          {
              finsedSpawning = false;
          }
          if(currentwaveIndex + 1 < waves.Length)
          {
              currentwaveIndex++;
              StartCoroutine(StartNextWave(currentwaveIndex));
          }else
          {
              Debug.Log(("Done"));
          }
      }
   }
}
