using System;
using UnityEngine;

namespace Battle.Units
{
    public class Unit : MonoBehaviour
    {

        [SerializeField]
        private Team team;
        public Team Team { set => team = value; }

        [Header("Sprites")]

        [SerializeField]
        private Sprite blueSprite;
        [SerializeField]
        private Sprite redSprite;

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
            transform.Translate(direction * Time.deltaTime);

        }
    }
}