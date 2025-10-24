using Battle.Units;
using TMPro;
using UnityEngine;

namespace Battle
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private int startingHealth = 3;
        [SerializeField] private Team team;
        [SerializeField] private GameObject lifeCounter;
        private int health;
        void Start()
        {
            health = startingHealth;
        }

        void OnValidate()
        {
            SetHealthCounter(startingHealth);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var unit = other.GetComponentInParent<Unit>();
            if (unit != null && unit.Team != team)
            {
                Destroy(unit.gameObject);
                health--;
                SetHealthCounter(health);
            }
        }

        private void SetHealthCounter(int newValue)
        {
            lifeCounter.GetComponent<TextMeshProUGUI>().SetText(newValue.ToString());
        }
    }
}
