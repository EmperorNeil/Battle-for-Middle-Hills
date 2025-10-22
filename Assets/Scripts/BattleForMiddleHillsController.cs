using UnityEngine;

public class BattleForMiddleHills : MonoBehaviour
{

    [SerializeField]
    private GameObject redArmy;
    [SerializeField]
    private GameObject blueArmy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveArmy(blueArmy.transform, Vector3.right);
        MoveArmy(redArmy.transform, Vector3.left);
    }

    private void MoveArmy(Transform armyTransform, Vector3 direction)
    {
        foreach (Transform unit in armyTransform)
        {
            unit.transform.Translate(direction * Time.deltaTime);
        }
    }

}
