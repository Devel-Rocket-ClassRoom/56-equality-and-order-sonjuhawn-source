using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine();

List<Item> items = new()
{
    new Item("불꽃 검", "무기","전설"),
    new Item("얼음 단검", "무기","희귀"),
    new Item("철 갑옷", "방어구","일반"),
    new Item("미스릴 방패", "방어구","희귀"),
    new Item("체력 물약", "소비","일반"),
};


class Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Grade { get; set; }

    public Item(string name, string type, string grade)
    {
        Name = name;
        Type = type;
        Grade = grade;
    }
}

class ItemTypeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        return x.Type == y.Type;
    }

    public override int GetHashCode(Item obj)
    {
        return obj.Type.GetHashCode();
    }
}

class ItemGradeComparer : EqualityComparer<Item>
{
    public override bool Equals(Item x, Item y)
    {
        return x.Grade == y.Grade;
    }

    public override int GetHashCode(Item obj)
    {
        return obj.Grade.GetHashCode();
    }
}