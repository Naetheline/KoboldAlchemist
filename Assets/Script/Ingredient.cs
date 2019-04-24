using System.Collections;
using System.Collections.Generic;
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



    public Ingredient(int e, int ha, int ho, int f, int ms, int k, int g, int a)
    {
        ear = e;
        hair = ha;
        horn = ho;
        feet = f;
        makeSmell = ms;
        kill = k;
        grow = g;
        alter = a;

        colour = Color.magenta;
        name = "It's magenta...";
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

        name = "";
        name += (makeSmell >= NAME_THRESHOLD) ? "smelly " : "";
        name += (kill >= NAME_THRESHOLD) ? "caustic " : "";
        name += (grow >= NAME_THRESHOLD) ? "glowing " : "";
        name += (alter >= NAME_THRESHOLD) ? "strange looking " : "";
        name += "liquid.";

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

        this.name = "heated " + name;
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

        this.name = "cool " + name;
    }

    public Color GetColour()
    {
        return colour;
    }
}
