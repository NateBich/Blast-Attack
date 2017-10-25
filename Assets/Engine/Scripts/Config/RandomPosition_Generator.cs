using UnityEngine;
using System.Collections;


namespace Engine.Config
{
    public class RandomPosition_Generator
    {
        // Randomly picks a position to spawn enemy at
        public static Vector3 RandomPositionGenerator(int whereToSpawn, Transform playerPos)
        {            
            float spawnDistMin = 25f;
            float spawnDistMax = 50f;
            Vector3 enemySpawnPos = Vector3.zero;
            switch (whereToSpawn)
            {
                case 1:
                    enemySpawnPos = playerPos.position + new Vector3(Random.Range(spawnDistMin, spawnDistMax), Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 2:
                    enemySpawnPos = playerPos.position + new Vector3(Random.Range(-spawnDistMin, spawnDistMax), Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 3:
                    enemySpawnPos = playerPos.position + new Vector3(Random.Range(spawnDistMin, spawnDistMax), -Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 4:
                    enemySpawnPos = playerPos.position + new Vector3(-Random.Range(spawnDistMin, spawnDistMax), -Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 5:
                    enemySpawnPos = playerPos.position - new Vector3(Random.Range(spawnDistMin, spawnDistMax), Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 6:
                    enemySpawnPos = playerPos.position - new Vector3(Random.Range(-spawnDistMin, spawnDistMax), Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 7:
                    enemySpawnPos = playerPos.position - new Vector3(Random.Range(spawnDistMin, spawnDistMax), -Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                case 8:
                    enemySpawnPos = playerPos.position - new Vector3(-Random.Range(spawnDistMin, spawnDistMax), -Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
                default:
                    enemySpawnPos = playerPos.position + new Vector3(Random.Range(spawnDistMin, spawnDistMax), Random.Range(spawnDistMin, spawnDistMax), 0f);
                    break;
            }
            return enemySpawnPos;
        }
    }
}
