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
            foreach (Lane lane in lanes)
            {
                lane.SpawnUnit(Team.Blue, archerPrefab);
                lane.SpawnUnit(Team.Red, archerPrefab);
            }
        }

    }
}