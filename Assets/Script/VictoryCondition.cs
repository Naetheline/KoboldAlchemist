using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class VictoryCondition
{

    public const int EFFECT = 5;
    public const int STRONG_EFFECT = 8;

    // what is affected
    [Range(-1, 1)]
    private int ear;
    [Range(-1, 1)]
    private int horn;
    [Range(-1, 1)]
    private int feet;

    // How it's affected
    [Range(-2, 2)]
    private int makeSmell;
    [Range(-2, 2)]
    private int grow;
    [Range(-2, 2)]
    private int alter;

    public VictoryCondition()
    {
        do
        {
            ear = Mathf.RoundToInt(Random.Range(-1, 1));
            horn = Mathf.RoundToInt(Random.Range(-1, 1));
            feet = Mathf.RoundToInt(Random.Range(-1, 1));

            makeSmell = Mathf.RoundToInt(Random.Range(-2, 2));
            grow = Mathf.RoundToInt(Random.Range(-2, 2));
            alter = Mathf.RoundToInt(Random.Range(-2, 2));
        }
        while ((ear == 0 && horn == 0 && feet == 0) || (makeSmell == 0 && grow == 0 && alter == 0));

    }
    public VictoryCondition(int e, int h, int f, int ms, int g, int a)
    {
        ear = e;
        horn = h;
        feet = f;
        makeSmell = ms;
        grow = g;
        alter = a;
    }

    public int Ear { get => ear;  }
    public int Horn { get => horn;  }
    public int Feet { get => feet; }
    public int MakeSmell { get => makeSmell;  }
    public int Grow { get => grow;  }
    public int Alter { get => alter;  }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("I'd like my \n");

        sb.Append((ear == 1) ? "ears " : "");
        sb.Append((ear == -1) ? "eyes " : "");
        sb.Append((horn == 1) ? ((ear != 0)? "and horns " :"horns ") : "");
        sb.Append((horn == -1) ? ((ear != 0) ? "and tail " : "tail ") : "");
        sb.Append((feet == 1) ? ((ear != 0 || horn != 0)?"and feet ":"feet ") : "");
        sb.Append((feet == -1) ? ((ear != 0 || horn != 0) ? "and hands ":"hands ") : "");

        sb.Append("\n to be \n");


        sb.Append( (Mathf.Abs(makeSmell) == 2) ? "a lot ": "");
        sb.Append(((makeSmell) <= -1) ? "less smelly\n" : ((makeSmell >= 1) ? "more smelly\n" : ""));
        sb.Append((Mathf.Abs(grow) == 2) ? "a lot " : "");
        sb.Append(((grow) <= -1) ? "smaller" : ((grow >= 1) ? "bigger\n" : ""));
        sb.Append((Mathf.Abs(alter) == 2) ? "a lot " : "");
        sb.Append(((alter) <= -1) ? "less colourful." : ((alter >= 1) ? "more colourful." : ""));

        return sb.ToString();

    }
}
