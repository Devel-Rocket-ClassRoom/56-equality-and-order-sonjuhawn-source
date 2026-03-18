using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine();


class TodoTask : IComparable<TodoTask>
{
    public string Title { get; set; }
    public int Priority { get; set; }
    public string DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public TodoTask(string title, int priority, string dueDate)
    {
        Title = title;
        Priority = priority;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public int CompareTo(TodoTask other)
    {
        if(Priority == null)
        {

        }
    }
}