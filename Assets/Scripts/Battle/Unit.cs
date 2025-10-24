using System;
using UnityEngine;

namespace Battle.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Team team;

        public Team Team
        {
            set => team = value;
        }

        [SerializeField] private UnitType unitType;

        public UnitType UnitType
        {
            get => unitType;
        }

        [Header("Sprites")] [SerializeField] private Sprite blueSprite;
        [SerializeField] private Sprite redSprite;

        void OnValidate()
        {
            ApplyTeam();
        }

        private void Start()
        {
            ApplyTeam();
        }

        private void ApplyTeam()
        {
            switch (team)
            {
                case Team.Blue:
                    transform.localScale = new Vector3(1, 1, 1);
                    SetSprite(blueSprite);
                    break;
                case Team.Red:
                    transform.localScale = new Vector3(-1, 1, 1);
                    SetSprite(redSprite);
                    break;
            }
        }

        private void SetSprite(Sprite sprite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        private void Update()
        {
            var direction = team == Team.Blue ? Vector3.right : Vector3.left;
            transform.Translate(direction * (Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherUnit = other.GetComponentInParent<Unit>();
            if (otherUnit != null)
            {
                BeginFighting(otherUnit);
            }
        }

        private void BeginFighting(Unit otherUnit)
        {
            var otherType = otherUnit.UnitType;
            if (unitType == otherType
                || (unitType == UnitType.Archer && otherType == UnitType.Knight)
                || (unitType == UnitType.Knight && otherType == UnitType.Pikeman)
                || (unitType == UnitType.Pikeman && otherType == UnitType.Archer))
            {
                OnDefeat();
            }
        }

        private void OnDefeat()
        {
            Destroy(gameObject);
        }
    }
}