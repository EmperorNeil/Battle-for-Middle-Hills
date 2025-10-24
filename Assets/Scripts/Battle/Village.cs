using Battle.Units;
using UnityEngine;

namespace Battle
{
    public class Village : MonoBehaviour
    {
        [SerializeField] private BattleForMiddleHills controller;
        [SerializeField] private Sprite blueBanner;
        [SerializeField] private Sprite redBanner;

        private Team team = Team.None;

        private int blueOccupiers;
        private int redOccupiers;

        private void Update()
        {
            if (BlueCanConquer())
            {
                SetTeam(Team.Blue);
            }
            else if (RedCanConquer())
            {
                SetTeam(Team.Red);
            }

            redOccupiers = 0;
            blueOccupiers = 0;
        }

        private bool BlueCanConquer()
        {
            return blueOccupiers > redOccupiers && team != Team.Blue;
        }

        private bool RedCanConquer()
        {
            return redOccupiers > blueOccupiers && team != Team.Red;
        }

        private void SetTeam(Team newTeam)
        {
            controller.DecreaseIncome(team, 1);
            team = newTeam;
            controller.IncreaseIncome(team, 1);
            if (team == Team.Blue)
            {
                SetBannerSprite(blueBanner);
            }
            else if (team == Team.Red)
            {
                SetBannerSprite(redBanner);
            }
        }

        private void SetBannerSprite(Sprite bannerSprite)
        {
            transform.Find("banner").gameObject.GetComponent<SpriteRenderer>().sprite = bannerSprite;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var unit = other.GetComponentInParent<Unit>();
            if (unit != null)
            {
                if (unit.Team == Team.Red)
                {
                    redOccupiers++;
                }
                else if (unit.Team == Team.Blue)
                {
                    blueOccupiers++;
                }
            }
        }
    }
}