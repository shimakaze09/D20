#region

using System;

#endregion

[Serializable]
public partial struct DiceRoll
{
    public static readonly DiceRoll D6 = new(6);
    public static readonly DiceRoll D20 = new(20);

    public int count;
    public int sides;
    public int bonus;

    public DiceRoll(int sides)
    {
        count = 1;
        this.sides = sides;
        bonus = 0;
    }

    public DiceRoll(int count, int sides)
    {
        this.count = count;
        this.sides = sides;
        bonus = 0;
    }

    public DiceRoll(int count, int sides, int bonus)
    {
        this.count = count;
        this.sides = sides;
        this.bonus = bonus;
    }

    public override string ToString()
    {
        if (bonus != 0)
            return string.Format("{0}d{1}+{2}", count, sides, bonus);
        return string.Format("{0}d{1}", count, sides);
    }
}