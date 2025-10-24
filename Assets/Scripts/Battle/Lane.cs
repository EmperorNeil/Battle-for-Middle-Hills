using System;
using Battle.Units;
using UnityEngine;

namespace Battle
{
    public class Lane : MonoBehaviour
    {
        public Unit SpawnUnit(Team team, Unit unit)
        {
            var spawnPosition = transform.Find( ToSpawnPositionName(team));
            var spawnUnit = Instantiate(unit,  spawnPosition.position, Quaternion.identity);
            spawnUnit.Team = team;
            return spawnUnit;
        }

        private static String ToSpawnPositionName(Team team) => team switch
        {
            Team.Blue => "BlueSpawn",
            Team.Red => "RedSpawn",
            _ => throw new ArgumentOutOfRangeException(nameof(team), team, null)
        };
    }
}