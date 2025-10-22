using UnityEngine;

public class Archer : MonoBehaviour
{

    [SerializeField]
    private Team team;
    public Team Team { set => team = value; }

    [Header("Sprites")]

    [SerializeField]
    private ArcherSpriteSet blueSprites;
    [SerializeField]
    private ArcherSpriteSet redSprites;



    void OnValidate()
    {
        switch (team)
        {
            case Team.Blue:
                transform.localScale = new Vector3(-1, 1, 1);
                SetSprites(blueSprites);
                break;
            case Team.Red:
                transform.localScale = new Vector3(1, 1, 1);
                SetSprites(redSprites);
                break;
        }
    }

    private void SetSprites(ArcherSpriteSet sprites)
    {
        Transform body = transform.Find("Body");
        body.gameObject.GetComponent<SpriteRenderer>().sprite = sprites.body;
        body.Find("Back arm").gameObject.GetComponent<SpriteRenderer>().sprite = sprites.backArm;
        body.Find("Front arm").gameObject.GetComponent<SpriteRenderer>().sprite = sprites.frontArm;
    }

}

[System.Serializable]
public class ArcherSpriteSet
{
    [SerializeField]
    public Sprite body;
    [SerializeField]
    public Sprite frontArm;
    [SerializeField]
    public Sprite backArm;
}