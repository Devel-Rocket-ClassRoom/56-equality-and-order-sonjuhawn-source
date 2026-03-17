using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine("`''");
{
    string s1 = "hello";
    string s2 = "hello";
    string s3 = new string("hello".ToCharArray());

    Console.WriteLine(s1 == s2);
    Console.WriteLine(s1 == s3);

    Console.WriteLine(object.ReferenceEquals(s1, s2));
    Console.WriteLine(object.ReferenceEquals(s1, s3));
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    Player p1 = new Player("Hero", 10);
    Player p2 = new Player("Hero", 10);
    Player p3 = p1;

    Console.WriteLine($"p1 == p2: {p1 == p2}");
    Console.WriteLine($"p1 == p3: {p1 == p3}");

    Console.WriteLine($"p1.Equals(p2): {object.Equals(p1, p2)}");
    Console.WriteLine($"p1.Equals(p3): {object.Equals(p1, p3)}");
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    Position pos1 = new Position(10, 20);
    Position pos2 = new Position(10, 20);
    Position pos3 = new Position(30, 40);

    Console.WriteLine($"pos1.Equals(pos2): {pos1.Equals(pos2)}");
    Console.WriteLine($"pos1.Equals(pos3): {pos1.Equals(pos3)}");
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    Item item1 = new Item("Sword", 1);
    Item item2 = new Item("Sword", 1);
    Item item3 = new Item("Shield", 2);

    Console.WriteLine($"item1.Equals(item2): {item1.Equals(item2)}");
    Console.WriteLine($"item1.Equals(item3): {item1.Equals(item3)}");

    HashSet<Item> inventory = new HashSet<Item>();
    inventory.Add(item1);
    Console.WriteLine($"inventory.Contains(item2): {inventory.Contains(item2)}");
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    BadItem b1 = new BadItem("Potion");
    BadItem b2 = new BadItem("Potion");

    Console.WriteLine($"b1.Equals(b2): {b1.Equals(b2)}");

    Dictionary<BadItem, int> stock = new Dictionary<BadItem, int>();
    stock[b1] = 10;
    Console.WriteLine($"stock.ContainsKey(b2): {stock.ContainsKey(b2)}");
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    List<Monster> monsters = new List<Monster>
    {
        new Monster("Goblin", 30),
        new Monster("Dragon", 100),
        new Monster("Slime", 10),
        new Monster("Orc", 50)
    };

    Console.WriteLine("정렬 전:");
    foreach (Monster m in monsters)
    {
        Console.WriteLine($"  {m}");
    }

    monsters.Sort();  // IComparable<T> 사용

    Console.WriteLine("\n정렬 후:");
    foreach (Monster m in monsters)
    {
        Console.WriteLine($"  {m}");
    }
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    List<Student> students = new List<Student>
    {
        new Student("김철수", 2, 85),
        new Student("이영희", 1, 92),
        new Student("박민수", 2, 85),
        new Student("정수진", 1, 88),
        new Student("최동훈", 2, 90)
    };

    students.Sort();

    Console.WriteLine("정렬 결과:");
    foreach (Student s in students)
    {
        Console.WriteLine($"  {s}");
    }
}
Console.WriteLine("`''\n");

Console.WriteLine("`''");
{
    Customer c1 = new Customer("Kim", "Cheolsu");
    Customer c2 = new Customer("Kim", "Cheolsu");

    Dictionary<Customer, string> dict1 = new Dictionary<Customer, string>();
    dict1[c1] = "VIP";
    Console.WriteLine($"기본 Dictionary - c2 검색: {dict1.ContainsKey(c2)}");

    Dictionary<Customer, string> dict2 = new Dictionary<Customer, string>(new CustomerNameComparer());
    dict2[c1] = "VIP";
    Console.WriteLine($"커스텀 Dictionary - c2 검색: {dict2.ContainsKey(c2)}");
}
Console.WriteLine("`''\n");

class Player
{
    public string Name;
    public int Level;

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
    }
}
struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Item : IEquatable<Item>
{
    public string Name;
    public int Id;

    public Item(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public bool Equals(Item other)
    {
        if (other == null)
        {
            return false;
        }
        return Id == other.Id && Name == other.Name;
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as Item);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id);
    }
}

class BadItem
{
    public string Name;

    public BadItem(string name)
    {
        Name = name;
    }

    public override bool Equals(object obj)
    {
        BadItem other = obj as BadItem;
        if (other == null)
        {
            return false;
        }
        return Name == other.Name;
    }
}

class Monster : IComparable<Monster>
{
    public string Name;
    public int Power;

    public Monster(string name, int power)
    {
        Name = name;
        Power = power;
    }
    public int CompareTo(Monster other)
    {
        if (other == null)
        {
            return 1;  // null보다 항상 큼
        }
        return Power.CompareTo(other.Power);
    }
    public override string ToString()
    {
        return $"{Name}(전투력:{Power})";
    }
}

class Student : IComparable<Student>
{
    public string Name;
    public int Grade;
    public int Score;

    public Student(string name, int grade, int score)
    {
        Name = name;
        Grade = grade;
        Score = score;
    }

    public int CompareTo(Student other)
    {
        if (other == null)
        {
            return 1;
        }
        int result = Grade.CompareTo(other.Grade);
        if (result != 0)
        {
            return result;
        }
        result = Score.CompareTo(other.Score);
        if (result != 0)
        {
            return result;
        }
        return Name.CompareTo(other.Name);
    }
    public override string ToString()
    {
        return $"{Grade}학년 {Name} ({Score}점)";
    }
}

class Customer
{
    public string LastName;
    public string FirstName;

    public Customer(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }
    public override string ToString()
    {
        return $"{LastName} {FirstName}";
    }
}

class CustomerNameComparer : EqualityComparer<Customer>
{
    public override bool Equals(Customer x, Customer y)
    {
        if (x == null && y == null)
        {
            return true;
        }
        if (x == null || y == null)
        {
            return false;
        }
        return x.LastName == y.LastName && x.FirstName == y.FirstName;
    }

    public override int GetHashCode(Customer obj)
    {
        if(obj == null)
        {
            return 1;
        }
        return HashCode.Combine(obj.LastName, obj.FirstName);
    }
}