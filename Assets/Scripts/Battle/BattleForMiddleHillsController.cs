using System.Collections;
using System.Collections.Generic;
using Battle.Units;
using UnityEngine;

namespace Battle
{
    public class BattleForMiddleHills : MonoBehaviour
    {

        [SerializeField]
        private List<Lane> lanes;
        [SerializeField]
        private Unit archerPrefab;
        [SerializeField]
        private Unit knightPrefab;
        [SerializeField]
        private Unit pikemanPrefab;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(SpawnWaveRoutine(2f));
        }

        IEnumerator SpawnWaveRoutine(float spawnDelay)
        {
            while (true)
            {
                SpawnRandomWave();
                yield return new WaitForSeconds(spawnDelay);
            }
        }
        
        private void SpawnRandomWave()
        {
            foreach (Lane lane in lanes)
            {
                
                lane.SpawnUnit(Team.Blue, RandomUnit());
                lane.SpawnUnit(Team.Red, RandomUnit());
            }
        }

        private Unit RandomUnit()
        {
            var unitType = Random.Range(0, 3);
            switch (unitType)
            {
                case 0:
                    return archerPrefab;
                case 1:
                    return knightPrefab;
                default:
                    return pikemanPrefab;
            }
        }
    }
}