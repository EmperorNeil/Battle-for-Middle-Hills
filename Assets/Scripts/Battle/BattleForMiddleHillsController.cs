using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battle.Units;
using TMPro;
using UnityEngine;
using Math = System.Math;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleForMiddleHills : MonoBehaviour
    {
        [SerializeField] private List<Lane> lanes;
        [SerializeField] private Unit archerPrefab;
        [SerializeField] private Unit knightPrefab;
        [SerializeField] private Unit pikemanPrefab;

        [SerializeField] private GameObject blueIncomeCounter;

        [SerializeField] private int baseIncome = 1;
        private Dictionary<Team, int> income = new Dictionary<Team, int>();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            income[Team.Blue] = baseIncome;
            income[Team.Red] = baseIncome;
            UpdateIncomeCounter(Team.Blue);
            StartCoroutine(SpawnWaveRoutine(2f));
        }

        private void OnValidate()
        {
            SetBlueIncomeCounter(baseIncome);
        }

        IEnumerator SpawnWaveRoutine(float spawnDelay)
        {
            while (true)
            {
                SpendMoney(Team.Blue);
                SpendMoney(Team.Red);
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        private void SpendMoney(Team team)
        {
            var unitsToBuy = Math.Min(lanes.Count, GetTeamIncome(team));
            var shuffledLanes = lanes.OrderBy(_ => Random.value).ToList();
            for (int i = 0; i < unitsToBuy; i++)
            {
                shuffledLanes[i].SpawnUnit(team, RandomUnit());
            }
        }

        private int GetTeamIncome(Team team)
        {
            if (income.ContainsKey(team))
            {
                return income[team];
            }

            return 0;
        }

        public void IncreaseIncome(Team team, int amount)
        {
            if (income.ContainsKey(team))
            {
                income[team] += amount;
            }

            UpdateIncomeCounter(team);
        }

        public void DecreaseIncome(Team team, int amount)
        {
            if (income.ContainsKey(team))
            {
                income[team] -= amount;
            }

            UpdateIncomeCounter(team);
        }

        private void UpdateIncomeCounter(Team team)
        {
            if (team == Team.Blue)
            {
                SetBlueIncomeCounter(income[Team.Blue]);
            }
        }

        private void SetBlueIncomeCounter(int newValue)
        {
            blueIncomeCounter.GetComponent<TextMeshProUGUI>().SetText(newValue.ToString());
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