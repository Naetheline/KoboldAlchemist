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

    private string name;
    public string Name
    {
        get { return name; }
    }

    private int ear;
    private int hair;
    private int horn;
    private int feet;
    private int makeSmell;
    private int kill;
    private int grow;
    private int alter;

    private Color colour;

    public Ingredient()
    {
          ear = 0;
      hair = 0;
      horn = 0;
      feet = 0;
      makeSmell = 0;
      kill = 0;
      grow = 0;
      alter = 0;

        colour = Color.white;
        name = "Water... How did you get that ?";
    }

    public Ingredient(Ingredient copy)
    {
        ear = copy.ear;
        hair = copy.hair;
        horn = copy.horn;
        feet = copy.feet;
        makeSmell = copy.makeSmell;
        kill = copy.kill;
        grow = copy.grow;
        alter = copy.alter;

        colour = copy.colour;
        name = copy.name;
    }

    public Ingredient(int e, int ha, int ho, int f, int ms, int k, int g, int a, Color c, string newName)
    {
        ear = e;
        hair = ha;
        horn = ho;
        feet = f;
        makeSmell = ms;
        kill = k;
        grow = g;
        alter = a;

        colour = c;

        name = newName;
    }


    public void Mix(Ingredient toMix)
    {
        this.ear = this.ear + toMix.ear;
        this.hair = this.hair + toMix.hair;
        this.horn = this.horn + toMix.horn;
        this.feet = this.feet + toMix.feet;
        this.makeSmell = this.makeSmell + toMix.makeSmell;
        this.kill = this.kill + toMix.kill;
        this.grow = this.grow + toMix.grow;
        this.alter = this.alter + toMix.alter;

        this.colour = this.colour + toMix.colour;

        RandomizeColourIfWhite();


        name = "";
        name += GenerateName();

    }

    public void Heat()
    {
        ear  = (int)(ear * HEAT_MODIFICATOR);
        hair = (int)(hair * HEAT_MODIFICATOR);
        horn = (int)(horn * HEAT_MODIFICATOR);
        feet = (int)(feet * HEAT_MODIFICATOR);
        makeSmell = (int)(makeSmell * HEAT_MODIFICATOR);
        kill = (int)(kill * HEAT_MODIFICATOR);
        grow = (int)(grow * HEAT_MODIFICATOR);
        alter = (int)(alter * HEAT_MODIFICATOR);

        this.colour = colour * HEAT_MODIFICATOR;
        RandomizeColourIfWhite();

        this.name = "heated " + GenerateName();
    }

    public void Cool()
    {
        ear = (int)(ear * COLD_MODIFICATOR);
        hair = (int)(hair * COLD_MODIFICATOR);
        horn = (int)(horn * COLD_MODIFICATOR);
        feet = (int)(feet * COLD_MODIFICATOR);
        makeSmell = (int)(makeSmell * COLD_MODIFICATOR);
        kill = (int)(kill * COLD_MODIFICATOR);
        grow = (int)(grow * COLD_MODIFICATOR);
        alter = (int)(alter * COLD_MODIFICATOR);

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
        if(colour.Equals(Color.white))
        {
            colour = Random.ColorHSV(0f, 1f, 0f, 0.8f, 0f, 1f);
        }
    }


    private string GenerateName()
    {
        StringBuilder newName = new StringBuilder(); ;
        newName.Append( (makeSmell >= NAME_THRESHOLD) ? "smelly " : "");
        newName.Append((kill >= NAME_THRESHOLD) ? "caustic " : "");
        newName.Append((grow >= NAME_THRESHOLD) ? "glowing " : "");
        newName.Append((alter >= NAME_THRESHOLD) ? "strange looking " : "");
        newName.Append((makeSmell <= -NAME_THRESHOLD) ? "inodorous " : "");
        newName.Append((kill <= -NAME_THRESHOLD) ? "viscous " : "");
        newName.Append((grow <= -NAME_THRESHOLD) ? "thick " : "");
        newName.Append((alter <= -NAME_THRESHOLD) ? "surprisingly clear " : "");
        newName.Append("liquid.");

        return newName.ToString();
    }

    public override string ToString()
    {
        StringBuilder newName = new StringBuilder();
        newName.Append(GenerateName());
        newName.Append("\nEars : " + this.ear);
        newName.Append("\nHair : " + this.hair);
        newName.Append("\nHorn : " + this.horn);
        newName.Append("\nFeet : " + this.feet);
        newName.Append("\nMake Smel : " + this.makeSmell);
        newName.Append("\nKill : "  + this.kill);
        newName.Append("\nGrow : "+ this.grow);
        newName.Append("\nAlter : " + this.alter);
        

        return newName.ToString();
    }
}
