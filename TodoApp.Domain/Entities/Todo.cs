using System;
using System.Collections.Generic;

namespace TodoApp.Domain.Entities;

public partial class Todo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public DateOnly Deadline { get; set; }

    public string Priority { get; set; } = null!;

    public bool Status { get; set; }
}
