# FlutterSharp Todo Application

A full-featured todo list application demonstrating FlutterSharp's capabilities for building interactive web applications with C# and Flutter UI.

## Features

- **Add todos** - Create new todo items with text input
- **Complete todos** - Check off completed items
- **Delete todos** - Remove individual items
- **Filter todos** - View All, Active, or Completed items
- **Clear completed** - Bulk delete all completed todos
- **Real-time stats** - Track remaining items count
- **Persistent state** - In-memory todo storage during session

## Architecture

This sample demonstrates several FlutterSharp concepts:

### State Management
```csharp
record TodoItem(string Id, string Text, bool Completed);
var todos = new List<TodoItem>();
```

Uses C# records for immutable todo items and a mutable list for state.

### Event Handling
```csharp
addButton.Click += (sender, e) =>
{
    var newTodo = new TodoItem(Guid.NewGuid().ToString(), text, false);
    todos.Add(newTodo);
    UpdateTodoList();
};
```

Event-driven architecture with button clicks, checkbox changes, and form submissions.

### Dynamic UI Updates
```csharp
void UpdateTodoList()
{
    todoList.Children.Clear();
    foreach (var todo in filteredTodos)
    {
        // Rebuild UI dynamically
    }
}
```

Reactive UI that rebuilds when state changes.

### Layout Composition
```csharp
var mainColumn = new Column { /* ... */ };
var inputRow = new Row { /* ... */ };
var todoList = new Column { /* ... */ };
```

Hierarchical composition of Column and Row layouts.

## Controls Used

### Input Controls
- **TextField** - Todo text input
- **Checkbox** - Todo completion status
- **ElevatedButton** - Primary "Add" action
- **TextButton** - Secondary "Clear completed" action
- **OutlinedButton** - Filter buttons
- **IconButton** - Delete button with icon

### Layout Controls
- **Column** - Vertical layouts
- **Row** - Horizontal layouts
- **Container** - Spacing and padding

### Display Controls
- **Text** - Titles, labels, todo text

## Code Structure

### Program.cs

```csharp
// 1. Todo model definition
record TodoItem(string Id, string Text, bool Completed);

// 2. State initialization
var todos = new List<TodoItem>();

// 3. UI construction
builder.Services.AddFlutterSharp(page =>
{
    // Build UI tree
});

// 4. Event handlers
addButton.Click += (sender, e) => { /* ... */ };

// 5. Helper functions
void UpdateTodoList() { /* ... */ }
void UpdateStats() { /* ... */ }
```

## Running the Application

### 1. Build and Run

```bash
cd samples/TodoApp
dotnet run
```

### 2. Access the Application

Navigate to `http://localhost:5000` in your browser.

### 3. Connect a Client

Use a Flet/Flutter client to connect to `ws://localhost:5000/ws`.

## Implementation Highlights

### Filtering Logic

```csharp
var filteredTodos = currentFilter switch
{
    "active" => todos.Where(t => !t.Completed).ToList(),
    "completed" => todos.Where(t => t.Completed).ToList(),
    _ => todos.ToList()
};
```

Uses C# pattern matching for clean filter implementation.

### Reactive Updates

```csharp
checkbox.Change += (sender, e) =>
{
    var index = todos.FindIndex(t => t.Id == todo.Id);
    todos[index] = todo with { Completed = checkbox.Value ?? false };
    UpdateTodoList();  // Trigger UI refresh
    UpdateStats();     // Update item count
};
```

State changes trigger UI updates for reactive behavior.

### Form Submission

```csharp
todoInput.Submit += (sender, e) =>
{
    addButton.OnClick();  // Reuse click handler
};
```

Enter key in text field triggers add button.

## Extending the Application

### Add Persistence

Store todos in a database:

```csharp
// Add Entity Framework Core
builder.Services.AddDbContext<TodoDbContext>();

// Save on add
todos.Add(newTodo);
await dbContext.Todos.AddAsync(newTodo);
await dbContext.SaveChangesAsync();
```

### Add Priority Levels

Extend the todo model:

```csharp
record TodoItem(string Id, string Text, bool Completed, Priority Priority);

enum Priority { Low, Medium, High }

// Color code by priority
var todoText = new Text(todo.Text)
{
    Color = todo.Priority switch
    {
        Priority.High => "red",
        Priority.Medium => "orange",
        _ => "black"
    }
};
```

### Add Due Dates

```csharp
record TodoItem(string Id, string Text, bool Completed, DateTime? DueDate);

var datePicker = new DatePicker { Label = "Due date" };
```

### Add Categories

```csharp
var categories = new List<string> { "Work", "Personal", "Shopping" };

var categoryDropdown = new Dropdown { Label = "Category" };
foreach (var cat in categories)
{
    categoryDropdown.AddChild(new Option { Key = cat, Text = cat });
}
```

### Add Search

```csharp
var searchField = new TextField { Label = "Search todos" };

searchField.Change += (sender, e) =>
{
    var query = searchField.Value?.ToLower();
    filteredTodos = todos.Where(t =>
        t.Text.ToLower().Contains(query ?? "")).ToList();
    UpdateTodoList();
};
```

## Best Practices Demonstrated

1. **Separation of Concerns** - UI, state, and business logic clearly separated
2. **Event-Driven Architecture** - UI updates triggered by events
3. **Immutable Data** - Using records for todo items
4. **Functional Patterns** - LINQ for filtering, pattern matching
5. **Clean Code** - Helper functions for reusable logic
6. **Type Safety** - Strong typing throughout

## Performance Considerations

- **Efficient Updates** - Only rebuild changed portions of UI
- **Minimal State** - Keep state simple and focused
- **Event Debouncing** - Could add for search field
- **Virtual Scrolling** - Consider for large lists

## Testing

Test the application functionality:

```csharp
[Fact]
public void AddTodo_ShouldIncreaseCount()
{
    var todos = new List<TodoItem>();
    todos.Add(new TodoItem(Guid.NewGuid().ToString(), "Test", false));
    Assert.Single(todos);
}

[Fact]
public void CompleteTodo_ShouldUpdateStatus()
{
    var todo = new TodoItem("1", "Test", false);
    var completed = todo with { Completed = true };
    Assert.True(completed.Completed);
}
```

## Resources

- [FlutterSharp Documentation](../../README.md)
- [FlutterSharp.Web Documentation](../../src/FlutterSharp.Web/README.md)
- [Getting Started Guide](../../docs/getting-started.md)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)

## License

This sample is part of the FlutterSharp project and is licensed under the MIT License.
