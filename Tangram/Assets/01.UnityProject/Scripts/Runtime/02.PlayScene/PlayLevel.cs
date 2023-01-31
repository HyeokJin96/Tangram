using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<PuzzleLvPart> puzzleLvParts = default;

    public void Awake()
    {
        GameManager.Instance.Creat();
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }   //  Awake()

    // Start is called before the first frame update
    void Start()
    {
        puzzleLvParts = new List<PuzzleLvPart>();

        for(int i = 0; i < transform.childCount; i++)
        {
            puzzleLvParts.Add(transform.GetChild(i).gameObject.GetComponentMust<PuzzleLvPart>());
        }   //  loop : ���� �������� ���� ������ ��� ĳ���ϴ� ����
    }   //  Start()

    // Update is called once per frame
    void Update()
    {

    }   //  Update()
}
