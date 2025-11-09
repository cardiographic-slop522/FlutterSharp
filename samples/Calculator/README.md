# FlutterSharp Calculator

A fully functional calculator application built with FlutterSharp, demonstrating event-driven programming, state management, and dynamic UI construction in C#.

## Features

- **Basic Operations** - Addition, subtraction, multiplication, division
- **Decimal Support** - Handle decimal numbers
- **Clear Function** - Reset calculator state
- **Backspace** - Delete last digit
- **Error Handling** - Division by zero protection
- **Clean UI** - Modern Material Design interface

## Screenshots

```
┌──────────────────────┐
│  FlutterSharp Calculator  │
├──────────────────────┤
│                      │
│              0       │  ← Display
│                      │
├──────────────────────┤
│  C    ⌫    ÷        │
│  7    8    9    ×   │
│  4    5    6    −   │
│  1    2    3    +   │
│    0      .    =    │
└──────────────────────┘
```

## Architecture

### State Management

The calculator uses simple closure-based state:

```csharp
var display = "";           // Current display value
var firstOperand = "";      // First number in operation
var operation = "";         // Current operation (+, -, ×, ÷)
var shouldResetDisplay = false;  // Flag for display reset
```

### Button Creation Pattern

Dynamic button creation with a helper function:

```csharp
ElevatedButton CreateButton(string text, string? bgColor = null,
                           string? textColor = null, int flex = 1)
{
    return new ElevatedButton(text)
    {
        BgColor = bgColor ?? "#e0e0e0",
        Color = textColor ?? "#333",
        Expand = flex,
        Height = 60
    };
}
```

### Calculation Logic

Uses pattern matching for operations:

```csharp
double result = operation switch
{
    "+" => num1 + num2,
    "-" => num1 - num2,
    "×" => num1 * num2,
    "÷" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
    _ => num2
};
```

## Controls Used

### Material Design Controls
- **ElevatedButton** - All calculator buttons
- **Text** - Display and title
- **Container** - Calculator frame and display background
- **Column** - Vertical layout
- **Row** - Button rows

### Layout Features
- **Expand** - Flexible button sizing (0 button takes 2x space)
- **Spacing** - Gaps between buttons
- **Padding** - Internal spacing
- **BorderRadius** - Rounded corners
- **BgColor** - Color theming

## Code Walkthrough

### 1. State Initialization

```csharp
var display = "";
var firstOperand = "";
var operation = "";
var shouldResetDisplay = false;
```

### 2. Display Update Function

```csharp
void UpdateDisplay(string value)
{
    display = value;
    displayText.Value = string.IsNullOrEmpty(display) ? "0" : display;
}
```

### 3. Number Input Handler

```csharp
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
```

### 4. Operation Handler

```csharp
void HandleOperation(string op)
{
    if (!string.IsNullOrEmpty(display))
    {
        if (!string.IsNullOrEmpty(firstOperand) && !shouldResetDisplay)
        {
            Calculate();  // Auto-calculate on chained operations
        }
        firstOperand = display;
        operation = op;
        shouldResetDisplay = true;
    }
}
```

### 5. Calculation Function

```csharp
void Calculate()
{
    if (string.IsNullOrEmpty(firstOperand) ||
        string.IsNullOrEmpty(display) ||
        string.IsNullOrEmpty(operation))
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
            "÷" => num2 != 0 ? num1 / num2
                             : throw new DivideByZeroException(),
            _ => num2
        };

        UpdateDisplay(result.ToString("G15"));
        firstOperand = display;
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
```

## Button Layout

### Row 1: Clear, Backspace, Divide
```csharp
var row1 = new Row { Spacing = 10 };
row1.AddChild(clearBtn);       // C - Red
row1.AddChild(backspaceBtn);   // ⌫ - Orange
row1.AddChild(divideBtn);      // ÷ - Blue
```

### Rows 2-4: Numbers and Operations
Each row contains 3 numbers and 1 operation button.

### Row 5: Zero (2x), Decimal, Equals
```csharp
var row5 = new Row { Spacing = 10 };
var zeroBtn = CreateButton("0", flex: 2);  // Takes 2x space
row5.AddChild(zeroBtn);
row5.AddChild(decimalBtn);     // .
row5.AddChild(equalsBtn);      // = - Green
```

## Color Scheme

| Element | Color | Purpose |
|---------|-------|---------|
| Clear | `#ff5252` (Red) | Destructive action |
| Backspace | `#ff9800` (Orange) | Secondary action |
| Operations | `#2196f3` (Blue) | Math operations |
| Equals | `#4caf50` (Green) | Primary action |
| Numbers | `#e0e0e0` (Gray) | Input buttons |

## Running the Application

### Build and Run

```bash
cd samples/Calculator
dotnet run
```

### Access the UI

Navigate to `http://localhost:5000` in your browser.

### Connect a Client

Use a Flet/Flutter client to connect to `ws://localhost:5000/ws`.

## Usage Examples

### Basic Calculation

1. Click `7`
2. Click `+`
3. Click `3`
4. Click `=`
5. Display shows `10`

### Chained Operations

1. Click `5`
2. Click `×`
3. Click `2` → Auto-calculates to `10`
4. Click `+`
5. Click `3`
6. Click `=` → Result `13`

### Decimal Numbers

1. Click `3`
2. Click `.`
3. Click `1` 4`
4. Click `÷`
5. Click `2`
6. Click `=` → Result `1.57`

### Error Handling

1. Click `5`
2. Click `÷`
3. Click `0`
4. Click `=` → Display shows `Error`

## Extending the Calculator

### Add Scientific Functions

```csharp
var sqrtBtn = CreateButton("√", "#9c27b0", "white");
sqrtBtn.Click += (sender, e) =>
{
    if (!string.IsNullOrEmpty(display))
    {
        var num = double.Parse(display);
        UpdateDisplay(Math.Sqrt(num).ToString("G15"));
    }
};

var squareBtn = CreateButton("x²", "#9c27b0", "white");
squareBtn.Click += (sender, e) =>
{
    if (!string.IsNullOrEmpty(display))
    {
        var num = double.Parse(display);
        UpdateDisplay(Math.Pow(num, 2).ToString("G15"));
    }
};
```

### Add Memory Functions

```csharp
var memory = 0.0;

var memoryStoreBtn = CreateButton("MS");
memoryStoreBtn.Click += (sender, e) =>
{
    if (!string.IsNullOrEmpty(display))
        memory = double.Parse(display);
};

var memoryRecallBtn = CreateButton("MR");
memoryRecallBtn.Click += (sender, e) =>
{
    UpdateDisplay(memory.ToString("G15"));
};

var memoryClearBtn = CreateButton("MC");
memoryClearBtn.Click += (sender, e) =>
{
    memory = 0.0;
};
```

### Add History

```csharp
var history = new List<string>();

void AddToHistory(string calculation)
{
    history.Add(calculation);
    // Update history display
}

// In Calculate():
var calculation = $"{firstOperand} {operation} {display} = {result}";
AddToHistory(calculation);
```

### Add Percentage

```csharp
var percentBtn = CreateButton("%");
percentBtn.Click += (sender, e) =>
{
    if (!string.IsNullOrEmpty(display))
    {
        var num = double.Parse(display);
        UpdateDisplay((num / 100).ToString("G15"));
    }
};
```

## Best Practices Demonstrated

1. **Functional Decomposition** - Separate functions for each responsibility
2. **Error Handling** - Try-catch for parsing and division errors
3. **State Management** - Clear separation of display and calculation state
4. **Event-Driven** - Button clicks trigger state changes
5. **DRY Principle** - Button creation helper eliminates repetition
6. **Type Safety** - Strong typing throughout
7. **Pattern Matching** - Clean operation dispatch

## Performance Considerations

- **Minimal Redraws** - Only display text updates on state changes
- **Efficient Parsing** - Numbers parsed only when needed
- **Lazy Evaluation** - Operations not calculated until equals

## Testing Ideas

```csharp
[Theory]
[InlineData("5", "+", "3", 8)]
[InlineData("10", "-", "4", 6)]
[InlineData("6", "×", "7", 42)]
[InlineData("20", "÷", "4", 5)]
public void Calculator_Operations_ShouldReturnCorrectResult(
    string num1, string op, string num2, double expected)
{
    // Test calculation logic
}

[Fact]
public void Calculator_DivideByZero_ShouldShowError()
{
    // Test error handling
}
```

## Resources

- [FlutterSharp Documentation](../../README.md)
- [Getting Started Guide](../../docs/getting-started.md)
- [FlutterSharp.Web Documentation](../../src/FlutterSharp.Web/README.md)

## License

This sample is part of the FlutterSharp project and is licensed under the MIT License.
