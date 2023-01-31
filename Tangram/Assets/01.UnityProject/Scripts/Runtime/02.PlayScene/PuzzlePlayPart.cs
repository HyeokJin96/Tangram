using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public PuzzleType puzzleType = PuzzleType.None;
    private Image puzzleImage = default;

    private bool isClicked = false;
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    private PlayLevel playlevel = default;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.gameObject.GetComponentMust<PuzzleInitZone>();

        playlevel = GameManager.Instance.gameObjs[GData.OBJ_NAME_CURRENT_LEVEL].GetComponentMust<PlayLevel>();

        puzzleImage = gameObject.FindChildObj("PuzzleLvImage").GetComponentMust<Image>();

        // ���� �̹��� �̸��� ���� ������ Ÿ���� ��������.
        switch (puzzleImage.sprite.name)
        {
            case "Puzzle_BigTriangle1":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            case "Puzzle_BigTriangle2":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            default:
                puzzleType = PuzzleType.None;
                break;
        }   //  switch
    }   //  Start()

    // Update is called once per frame
    void Update()
    {

    }   //  Update()

    //! ���콺 ��ư�� ������ �� �����ϴ� �Լ�
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }   //  OnPointerDown()

    //! ���콺 ��ư���� ���� ���� �� �����ϴ� �Լ�
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;

        //  ���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ� ���� ����� ������ ã�´�.
        PuzzleLvPart closeLvPuzzle =  playlevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        if (closeLvPuzzle == null || closeLvPuzzle == default)
        {
            return;
        }

        transform.position = closeLvPuzzle.transform.position;

        GFunc.Log($"{closeLvPuzzle.name}�� ���� �����̿� �ֽ��ϴ�.");
    }   //  OnPointerUp()

    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            //  ���� ��ǥ�� �����ϴ� ���� -> ����� �������� ���� �����ǿ� ���ϴ� �������� ���� eventData.delta
            gameObject.AddAnchoredPos(eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);
        }   //  if : ���� ������Ʈ�� ������ ���
    }   //  OnDrag()



}
