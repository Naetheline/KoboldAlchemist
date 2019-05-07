using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Ingredient : System.Object
{

    public const float HEAT_MODIFICATOR = 1.5f;
    public const float COLD_MODIFICATOR = 0.5f;
    public const int NAME_THRESHOLD = 5;
    public const int THRESHOLD_EXPLOSION = 12;

    private string name;
    public string Name
    {
        get { return name; }
    }

    private int ear;
    public int Ear
    {
        get { return ear; }
    }
    private int horn;
    public int Horn
    {
        get { return horn; }
    }
    private int feet;
    public int Feet
    {
        get { return feet; }
    }
    private int makeSmell;
    public int MakeSmell
    {
        get { return makeSmell; }
    }
    private int grow;
    public int Grow
    {
        get { return grow; }
    }
    private int alter;
    public int Alter
    {
        get { return alter; }
    }

    private Color colour;

    public Ingredient()
    {
      ear = 0;
      horn = 0;
      feet = 0;
      makeSmell = 0;
      grow = 0;
      alter = 0;

        colour = Color.white;
        name = "Water... How did you get that ?";
    }

    public Ingredient(Ingredient copy)
    {
        ear = copy.ear;
        horn = copy.horn;
        feet = copy.feet;
        makeSmell = copy.makeSmell;
        grow = copy.grow;
        alter = copy.alter;

        colour = copy.colour;
        name = copy.name;
    }

    public Ingredient(int e, int ho, int f, int ms, int g, int a, Color c, string newName)
    {
        ear = e;
        horn = ho;
        feet = f;
        makeSmell = ms;
        grow = g;
        alter = a;

        colour = c;

        name = newName;
    }


    public void Mix(Ingredient toMix)
    {
        this.ear = this.ear + toMix.ear;
        this.horn = this.horn + toMix.horn;
        this.feet = this.feet + toMix.feet;
        this.makeSmell = this.makeSmell + toMix.makeSmell;
        this.grow = this.grow + toMix.grow;
        this.alter = this.alter + toMix.alter;

        this.colour = this.colour + toMix.colour;

        RandomizeColourIfWhite();


        name = "";
        name += GenerateName();

    }

    public void Heat()
    {
        ear  = Mathf.FloorToInt((ear * HEAT_MODIFICATOR));
        horn = Mathf.FloorToInt((horn * HEAT_MODIFICATOR));
        feet = Mathf.FloorToInt((feet * HEAT_MODIFICATOR));
        makeSmell = Mathf.FloorToInt((makeSmell * HEAT_MODIFICATOR));
        grow = Mathf.FloorToInt((grow * HEAT_MODIFICATOR));
        alter = Mathf.FloorToInt((alter * HEAT_MODIFICATOR));

        this.colour = colour * HEAT_MODIFICATOR;
        RandomizeColourIfWhite();

        this.name = "heated " + GenerateName();
    }

    public void Cool()
    {
        ear = Mathf.FloorToInt((ear * COLD_MODIFICATOR));
        horn = Mathf.FloorToInt((horn * COLD_MODIFICATOR));
        feet = Mathf.FloorToInt((feet * COLD_MODIFICATOR));
        makeSmell = Mathf.FloorToInt((makeSmell * COLD_MODIFICATOR));
        grow = Mathf.FloorToInt((grow * COLD_MODIFICATOR));
        alter = Mathf.FloorToInt((alter * COLD_MODIFICATOR));

        colour = colour * COLD_MODIFICATOR;
        RandomizeColourIfWhite();

        this.name = "cool " + GenerateName();
    }

    public Color GetColour()
    {
        return colour;
    }

    private void RandomizeColourIfWhite()
    {
        while(colour.r >= 0.8f && colour.g >= 0.8f && colour.b >= 0.8f)
        {
            colour = Random.ColorHSV(0f, 1f, 0f, 0.8f, 0f, 1f);
        }
    }

    private void CheckExplosion()
    {
        if( Mathf.Abs(ear) >= THRESHOLD_EXPLOSION ||
            Mathf.Abs(horn) >= THRESHOLD_EXPLOSION ||
            Mathf.Abs(feet) >= THRESHOLD_EXPLOSION ||
            Mathf.Abs(makeSmell) >= THRESHOLD_EXPLOSION ||
            Mathf.Abs(grow) >= THRESHOLD_EXPLOSION ||
            Mathf.Abs(alter) >= THRESHOLD_EXPLOSION)
        {
            Debug.Log("Boom !");
        }
    }


    private string GenerateName()
    {
        StringBuilder newName = new StringBuilder(); ;
        newName.Append( (makeSmell >= NAME_THRESHOLD) ? "smelly " : "");
        newName.Append((grow >= NAME_THRESHOLD) ? "thick " : "");
        newName.Append((alter >= NAME_THRESHOLD) ? "glowing " : "");
        newName.Append((makeSmell <= -NAME_THRESHOLD) ? "inodorous " : "");
        newName.Append((grow <= -NAME_THRESHOLD) ? "caustic " : "");
        newName.Append((alter <= -NAME_THRESHOLD) ? "strange looking " : "");
        newName.Append("liquid.");

        return newName.ToString();
    }

    public override string ToString()
    {
        StringBuilder newName = new StringBuilder();
        newName.Append(GenerateName());
        newName.Append("\nEars : " + this.ear);
        newName.Append("\nHorn : " + this.horn);
        newName.Append("\nFeet : " + this.feet);
        newName.Append("\nMake Smell : " + this.makeSmell);
        newName.Append("\nGrow : "+ this.grow);
        newName.Append("\nAlter : " + this.alter);
        

        return newName.ToString();
    }
}
