using FlutterSharp.Core;
using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;

// Create a simple Hello World page
Page CreatePage()
{
    var page = new Page
    {
        Title = "Hello FlutterSharp!",
        HorizontalAlignment = "center",
        VerticalAlignment = "center"
    };

    var column = new Column
    {
        HorizontalAlignment = "center",
        Spacing = 20
    };

    var title = new Text("Welcome to FlutterSharp!")
    {
        Size = 32,
        Weight = "bold",
        Color = "blue"
    };

    var subtitle = new Text("A modern C# .NET 9.0 implementation of Flet")
    {
        Size = 16,
        Color = "gray"
    };

    var counterText = new Text("You clicked 0 times")
    {
        Size = 20
    };

    var clickCount = 0;

    var button = new ElevatedButton("Click Me!", (sender, e) =>
    {
        clickCount++;
        counterText.Value = $"You clicked {clickCount} times";
        Console.WriteLine($"Button clicked! Count: {clickCount}");
    })
    {
        BackgroundColor = "blue",
        Color = "white"
    };

    column.AddChild(title);
    column.AddChild(subtitle);
    column.AddChild(counterText);
    column.AddChild(button);

    page.AddChild(column);

    return page;
}

// Create a more complex example with various controls
Page CreateComplexPage()
{
    var page = new Page
    {
        Title = "FlutterSharp - Full Demo",
        Scroll = true,
        Padding = 20
    };

    var mainColumn = new Column { Spacing = 30 };

    // Header
    var header = new Container(new Text("FlutterSharp Control Showcase")
    {
        Size = 28,
        Weight = "bold"
    })
    {
        Padding = 20,
        BackgroundColor = "#1976D2",
        BorderRadius = 10
    };
    mainColumn.AddChild(header);

    // Input Controls Section
    var inputSection = new Column { Spacing = 15 };
    inputSection.AddChild(new Text("Input Controls") { Size = 20, Weight = "bold" });

    var textField = new TextField
    {
        Label = "Enter your name",
        Hint = "John Doe",
        PrefixIcon = "person"
    };
    textField.Changed += (s, e) => Console.WriteLine($"TextField changed: {e.Text}");
    inputSection.AddChild(textField);

    var checkbox = new Checkbox(false, "Accept terms and conditions");
    checkbox.Changed += (s, e) => Console.WriteLine($"Checkbox: {e.Value}");
    inputSection.AddChild(checkbox);

    var switchControl = new Switch(true, "Enable notifications");
    switchControl.Changed += (s, e) => Console.WriteLine($"Switch: {e.Value}");
    inputSection.AddChild(switchControl);

    mainColumn.AddChild(inputSection);

    // Radio Buttons Section
    var radioSection = new Column { Spacing = 10 };
    radioSection.AddChild(new Text("Choose your platform:") { Size = 16, Weight = "bold" });

    var radio1 = new Radio("windows", "windows", "Windows");
    var radio2 = new Radio("macos", "windows", "macOS");
    var radio3 = new Radio("linux", "windows", "Linux");

    radio1.Changed += (s, e) => UpdateRadios(e.Value);
    radio2.Changed += (s, e) => UpdateRadios(e.Value);
    radio3.Changed += (s, e) => UpdateRadios(e.Value);

    void UpdateRadios(string value)
    {
        radio1.GroupValue = value;
        radio2.GroupValue = value;
        radio3.GroupValue = value;
        Console.WriteLine($"Platform selected: {value}");
    }

    radioSection.AddChild(radio1);
    radioSection.AddChild(radio2);
    radioSection.AddChild(radio3);

    mainColumn.AddChild(radioSection);

    // List View Section
    var listView = new ListView
    {
        Spacing = 10,
        Height = 200,
        Divider = true
    };

    for (int i = 1; i <= 5; i++)
    {
        var row = new Row { Spacing = 10 };
        row.AddChild(new Icon("check_circle") { Color = "green", Size = 24 });
        row.AddChild(new Text($"List item {i}"));
        listView.AddChild(row);
    }

    mainColumn.AddChild(new Text("ListView Example") { Size = 20, Weight = "bold" });
    mainColumn.AddChild(listView);

    // Stack Example
    var stack = new Stack
    {
        Width = 200,
        Height = 100
    };

    stack.AddChild(new Container
    {
        Width = 200,
        Height = 100,
        BackgroundColor = "#E3F2FD",
        BorderRadius = 10
    });

    stack.AddChild(new Text("Stacked Text")
    {
        Size = 18,
        Weight = "bold",
        Color = "#1976D2"
    });

    mainColumn.AddChild(new Text("Stack Example") { Size = 20, Weight = "bold" });
    mainColumn.AddChild(stack);

    page.AddChild(mainColumn);

    return page;
}

// Demonstrate the API
Console.WriteLine("FlutterSharp Hello World Sample");
Console.WriteLine("================================");
Console.WriteLine();

// Option 1: Simple page
var simplePage = CreatePage();
Console.WriteLine($"Created simple page with {simplePage.Children.Count} child(ren)");
Console.WriteLine($"Page title: {simplePage.Title}");

// Option 2: Complex page with all controls
var complexPage = CreateComplexPage();
Console.WriteLine($"Created complex page with {complexPage.Children.Count} child(ren)");
Console.WriteLine($"Page title: {complexPage.Title}");

// Show how to run (placeholder - actual web server not implemented yet)
Console.WriteLine();
Console.WriteLine("To run this app, you would call:");
Console.WriteLine("  App.Run(() => CreatePage());");
Console.WriteLine();
Console.WriteLine("Note: Full web server integration is pending (Phase 6).");
Console.WriteLine("The foundation is complete and ready for ASP.NET Core integration!");
