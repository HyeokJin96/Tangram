using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingletone<GameManager>
{
    public Dictionary<string, GameObject> gameObjs = default;

    public override void Awake()
    {
        base.Awake();

        //  ���ð� �̱��� �ν��Ͻ� ����
        Creat();

        gameObjs = new Dictionary<string, GameObject>();
    }

    protected override void Init()
    {
        base.Init();

        //  ���⼭ ���� �Ŵ����� �ʱ�ȭ �ȴ�.
        gameObjs = new Dictionary<string, GameObject>();
    }   //  Init()

}
