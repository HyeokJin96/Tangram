using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    //! �÷��� ��ư�� ������ �� �÷��� ������ �Ѿ��
    public void OnPlayButton()
    {
        GFunc.LoadScene(GData.SCENE_NAME_PLAY);
    }   //  OnPlayButton()
}
