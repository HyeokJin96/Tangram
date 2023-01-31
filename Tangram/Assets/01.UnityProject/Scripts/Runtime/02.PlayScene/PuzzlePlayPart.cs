using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
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

        playlevel = GameManager.Instance.gameObjs["Level_1"].GetComponentMust<PlayLevel>();
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
