using FlutterSharp.Core.Controls;
using FlutterSharp.Core.Controls.Core;
using FlutterSharp.Core.Controls.Material;
using FlutterSharp.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Calculator state
var display = "";
var firstOperand = "";
var operation = "";
var shouldResetDisplay = false;

// Add FlutterSharp services
builder.Services.AddFlutterSharp(page =>
{
    page.Title = "FlutterSharp Calculator";
    page.Theme = "light";
    page.BackgroundColor = "#f0f0f0";

    // Main container
    var mainColumn = new Column
    {
        HorizontalAlignment = "center",
        VerticalAlignment = "center",
        Spacing = 0
    };

    // Calculator container
    var calcContainer = new Container
    {
        Width = 320,
        Padding = "20",
        BackgroundColor = "white",
        BorderRadius = 12
    };

    var calcColumn = new Column { Spacing = 15 };

    // Display
    var displayText = new Text("0")
    {
        Size = 48,
        Weight = "bold",
        TextAlign = "right",
        Color = "#333"
    };

    var displayContainer = new Container
    {
        Padding = "20,15",
        BackgroundColor = "#f8f8f8",
        BorderRadius = 8,
        Margin = "0,0,0,15"
    };
    displayContainer.AddChild(displayText);

    // Helper function to update display
    void UpdateDisplay(string value)
    {
        display = value;
        displayText.Value = string.IsNullOrEmpty(display) ? "0" : display;
    }

    // Helper function to handle number input
    void HandleNumber(string num)
    {
        if (shouldResetDisplay || display == "0")
        {
            UpdateDisplay(num);
            shouldResetDisplay = false;
        }
        else
        {
            UpdateDisplay(display + num);
        }
    }

    // Helper function to handle operation
    void HandleOperation(string op)
    {
        if (!string.IsNullOrEmpty(display))
        {
            if (!string.IsNullOrEmpty(firstOperand) && !shouldResetDisplay)
            {
                Calculate();
            }
            firstOperand = display;
            operation = op;
            shouldResetDisplay = true;
        }
    }

    // Helper function to perform calculation
    void Calculate()
    {
        if (string.IsNullOrEmpty(firstOperand) || string.IsNullOrEmpty(display) || string.IsNullOrEmpty(operation))
            return;

        try
        {
            var num1 = double.Parse(firstOperand);
            var num2 = double.Parse(display);
            double result = operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "×" => num1 * num2,
                "÷" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
                _ => num2
            };

            UpdateDisplay(result.ToString("G15")); // Format with up to 15 significant digits
            firstOperand = display;
            operation = "";
            shouldResetDisplay = true;
        }
        catch (DivideByZeroException)
        {
            UpdateDisplay("Error");
            firstOperand = "";
            operation = "";
            shouldResetDisplay = true;
        }
        catch
        {
            UpdateDisplay("Error");
            firstOperand = "";
            operation = "";
            shouldResetDisplay = true;
        }
    }

    // Helper function to create a button
    ElevatedButton CreateButton(string text, string? bgColor = null, string? textColor = null, int flex = 1)
    {
        var button = new ElevatedButton(text)
        {
            BackgroundColor = bgColor ?? "#e0e0e0",
            Color = textColor ?? "#333",
            Expand = flex,
            Height = 60
        };
        return button;
    }

    // Number buttons (0-9)
    var buttons = new Dictionary<string, ElevatedButton>();
    for (int i = 0; i <= 9; i++)
    {
        var num = i.ToString();
        var btn = CreateButton(num);
        btn.Click += (sender, e) => HandleNumber(num);
        buttons[num] = btn;
    }

    // Decimal button
    var decimalBtn = CreateButton(".");
    decimalBtn.Click += (sender, e) =>
    {
        if (!display.Contains("."))
        {
            HandleNumber(".");
        }
    };

    // Clear button
    var clearBtn = CreateButton("C", "#ff5252", "white");
    clearBtn.Click += (sender, e) =>
    {
        UpdateDisplay("");
        firstOperand = "";
        operation = "";
        shouldResetDisplay = false;
    };

    // Backspace button
    var backspaceBtn = CreateButton("⌫", "#ff9800", "white");
    backspaceBtn.Click += (sender, e) =>
    {
        if (!string.IsNullOrEmpty(display) && !shouldResetDisplay)
        {
            UpdateDisplay(display.Length > 1 ? display[..^1] : "");
        }
    };

    // Operation buttons
    var divideBtn = CreateButton("÷", "#2196f3", "white");
    divideBtn.Click += (sender, e) => HandleOperation("÷");

    var multiplyBtn = CreateButton("×", "#2196f3", "white");
    multiplyBtn.Click += (sender, e) => HandleOperation("×");

    var subtractBtn = CreateButton("-", "#2196f3", "white");
    subtractBtn.Click += (sender, e) => HandleOperation("-");

    var addBtn = CreateButton("+", "#2196f3", "white");
    addBtn.Click += (sender, e) => HandleOperation("+");

    var equalsBtn = CreateButton("=", "#4caf50", "white");
    equalsBtn.Click += (sender, e) => Calculate();

    // Build button layout
    // Row 1: C, ⌫, ÷
    var row1 = new Row { Spacing = 10 };
    row1.AddChild(clearBtn);
    row1.AddChild(backspaceBtn);
    row1.AddChild(divideBtn);

    // Row 2: 7, 8, 9, ×
    var row2 = new Row { Spacing = 10 };
    row2.AddChild(buttons["7"]);
    row2.AddChild(buttons["8"]);
    row2.AddChild(buttons["9"]);
    row2.AddChild(multiplyBtn);

    // Row 3: 4, 5, 6, -
    var row3 = new Row { Spacing = 10 };
    row3.AddChild(buttons["4"]);
    row3.AddChild(buttons["5"]);
    row3.AddChild(buttons["6"]);
    row3.AddChild(subtractBtn);

    // Row 4: 1, 2, 3, +
    var row4 = new Row { Spacing = 10 };
    row4.AddChild(buttons["1"]);
    row4.AddChild(buttons["2"]);
    row4.AddChild(buttons["3"]);
    row4.AddChild(addBtn);

    // Row 5: 0 (2x width), ., =
    var row5 = new Row { Spacing = 10 };
    var zeroBtn = CreateButton("0", flex: 2);
    zeroBtn.Click += (sender, e) => HandleNumber("0");
    row5.AddChild(zeroBtn);
    row5.AddChild(decimalBtn);
    row5.AddChild(equalsBtn);

    // Add all rows to calculator
    calcColumn.AddChild(displayContainer);
    calcColumn.AddChild(row1);
    calcColumn.AddChild(row2);
    calcColumn.AddChild(row3);
    calcColumn.AddChild(row4);
    calcColumn.AddChild(row5);

    calcContainer.AddChild(calcColumn);

    // Title above calculator
    var title = new Text("FlutterSharp Calculator")
    {
        Size = 24,
        Weight = "bold",
        Color = "#2196f3"
    };

    var titleContainer = new Container
    {
        Margin = "0,0,0,20"
    };
    titleContainer.AddChild(title);

    mainColumn.AddChild(titleContainer);
    mainColumn.AddChild(calcContainer);

    page.AddChild(mainColumn);
});

var app = builder.Build();

// Enable FlutterSharp WebSocket middleware
app.UseFlutterSharp();

// Serve landing page
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>FlutterSharp Calculator</title>
    <style>
        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, sans-serif;
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            min-height: 100vh;
        }
        .container {
            background: white;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 8px 16px rgba(0,0,0,0.2);
        }
        h1 { color: #667eea; margin-top: 0; }
        code {
            background: #f4f4f4;
            padding: 2px 6px;
            border-radius: 3px;
            font-family: 'Courier New', monospace;
        }
        .info {
            background: #e3f2fd;
            padding: 15px;
            border-radius: 6px;
            margin: 15px 0;
            border-left: 4px solid #2196f3;
        }
        ul { line-height: 1.8; }
        .feature {
            background: #f5f5f5;
            padding: 10px 15px;
            margin: 8px 0;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <div class='container'>
        <h1>🧮 FlutterSharp Calculator</h1>
        <div class='info'>
            <strong>WebSocket endpoint:</strong> <code>ws://localhost:5000/ws</code>
        </div>

        <h2>Features</h2>
        <div class='feature'>➕ Basic arithmetic operations (+, −, ×, ÷)</div>
        <div class='feature'>🔢 Decimal number support</div>
        <div class='feature'>⌫ Backspace to correct input</div>
        <div class='feature'>🔄 Clear (C) to reset</div>
        <div class='feature'>⛔ Division by zero handling</div>
        <div class='feature'>🎨 Clean, modern UI design</div>

        <h2>Operations</h2>
        <ul>
            <li><strong>Number Input:</strong> Click any digit (0-9)</li>
            <li><strong>Decimal Point:</strong> Click . for decimal numbers</li>
            <li><strong>Operations:</strong> +, −, ×, ÷</li>
            <li><strong>Calculate:</strong> = to get result</li>
            <li><strong>Clear:</strong> C to reset calculator</li>
            <li><strong>Backspace:</strong> ⌫ to delete last digit</li>
        </ul>

        <h2>Technology Stack</h2>
        <ul>
            <li><strong>Backend:</strong> ASP.NET Core 9.0 + FlutterSharp.Web</li>
            <li><strong>UI:</strong> Flutter Material Design controls</li>
            <li><strong>State:</strong> C# closures for calculator state</li>
            <li><strong>Events:</strong> Button click handlers</li>
        </ul>

        <h2>Code Highlights</h2>
        <ul>
            <li>Stateful calculator logic in C#</li>
            <li>Dynamic button creation with helper functions</li>
            <li>Pattern matching for operations</li>
            <li>Error handling for edge cases</li>
            <li>Responsive grid layout</li>
        </ul>
    </div>
</body>
</html>
", "text/html"));

app.Run();
