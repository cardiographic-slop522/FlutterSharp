using System.Text.Json.Serialization;

namespace FlutterSharp.Core.Controls.Material;

/// <summary>
/// Column configuration for a DataTable.
/// Corresponds to Flutter's DataColumn widget.
/// </summary>
[Control("DataColumn", Category = "material")]
public sealed class DataColumn : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataColumn"/> class.
    /// </summary>
    public DataColumn()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataColumn"/> class with a label.
    /// </summary>
    /// <param name="label">The column heading.</param>
    public DataColumn(object? label = null)
    {
        if (label != null) Label = label;
    }

    /// <summary>
    /// Gets or sets the column heading.
    /// Typically a Text control, or could be an Icon or combination in a Row.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("label")]
    public object? Label
    {
        get => GetProperty<object>(nameof(Label));
        set => SetProperty(nameof(Label), value);
    }

    /// <summary>
    /// Gets or sets whether this column represents numeric data or not.
    /// The contents of cells of columns containing numeric data are right-aligned.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("numeric")]
    public bool? Numeric
    {
        get => GetProperty<bool?>(nameof(Numeric));
        set => SetProperty(nameof(Numeric), value);
    }

    /// <summary>
    /// Gets or sets the horizontal layout of the label and sort indicator in the heading row.
    /// Values: "start", "end", "center", "spaceBetween", "spaceAround", "spaceEvenly"
    /// </summary>
    [JsonPropertyName("headingRowAlignment")]
    public string? HeadingRowAlignment
    {
        get => GetProperty<string>(nameof(HeadingRowAlignment));
        set => SetProperty(nameof(HeadingRowAlignment), value);
    }

    /// <summary>
    /// Occurs when the user asks to sort the table using this column.
    /// If not set, the column will not be considered sortable.
    /// </summary>
    public event EventHandler? Sort;
}

/// <summary>
/// The data for a cell of a DataTable.
/// Corresponds to Flutter's DataCell widget.
/// </summary>
[Control("DataCell", Category = "material")]
public sealed class DataCell : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataCell"/> class.
    /// </summary>
    public DataCell()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataCell"/> class with content.
    /// </summary>
    /// <param name="content">The content of this cell.</param>
    public DataCell(object? content = null)
    {
        if (content != null) Content = content;
    }

    /// <summary>
    /// Gets or sets the content of this cell.
    /// Typically a Text control or a Dropdown control.
    /// Can be a string or a BaseControl.
    /// </summary>
    [JsonPropertyName("content")]
    public object? Content
    {
        get => GetProperty<object>(nameof(Content));
        set => SetProperty(nameof(Content), value);
    }

    /// <summary>
    /// Gets or sets whether the content is actually a placeholder.
    /// If true, the default text style for the cell is changed to be appropriate for placeholder text.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("placeholder")]
    public bool? Placeholder
    {
        get => GetProperty<bool?>(nameof(Placeholder));
        set => SetProperty(nameof(Placeholder), value);
    }

    /// <summary>
    /// Gets or sets whether to show an edit icon at the end of this cell.
    /// This does not make the cell actually editable; the caller must implement editing behavior.
    /// If this is set, OnTap should also be set, otherwise tapping the icon will have no effect.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("showEditIcon")]
    public bool? ShowEditIcon
    {
        get => GetProperty<bool?>(nameof(ShowEditIcon));
        set => SetProperty(nameof(ShowEditIcon), value);
    }

    /// <summary>
    /// Occurs when this cell is tapped.
    /// If this is null, tapping this cell will attempt to select its row.
    /// </summary>
    public event EventHandler? Tap;

    /// <summary>
    /// Occurs when this cell is double tapped.
    /// </summary>
    public event EventHandler? DoubleTap;

    /// <summary>
    /// Occurs when this cell is long-pressed.
    /// </summary>
    public event EventHandler? LongPress;

    /// <summary>
    /// Occurs when the user cancels a tap that was started on this cell.
    /// </summary>
    public event EventHandler? TapCancel;

    /// <summary>
    /// Occurs when this cell is tapped down.
    /// </summary>
    public event EventHandler? TapDown;
}

/// <summary>
/// Row configuration and cell data for a DataTable.
/// Corresponds to Flutter's DataRow widget.
/// </summary>
[Control("DataRow", Category = "material")]
public sealed class DataRow : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataRow"/> class.
    /// </summary>
    public DataRow()
    {
    }

    /// <summary>
    /// Gets or sets the color of this row.
    /// The effective color can depend on the control state, if the row is selected, pressed, hovered, etc.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color
    {
        get => GetProperty<string>(nameof(Color));
        set => SetProperty(nameof(Color), value);
    }

    /// <summary>
    /// Gets or sets whether the row is selected.
    /// If OnSelectChange is non-null for any row in the table, then a checkbox is shown at the start of each row.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("selected")]
    public bool? Selected
    {
        get => GetProperty<bool?>(nameof(Selected));
        set => SetProperty(nameof(Selected), value);
    }

    /// <summary>
    /// Occurs when this row is long-pressed.
    /// </summary>
    public event EventHandler? LongPress;

    /// <summary>
    /// Occurs when the user selects or unselects a selectable row.
    /// If this is not null, then this row is selectable.
    /// </summary>
    public event EventHandler? SelectChange;
}

/// <summary>
/// A Material Design data table.
/// Displays data in rows and columns with support for sorting, selection, and custom cell content.
/// Corresponds to Flutter's DataTable widget.
/// </summary>
[Control("DataTable", Category = "material")]
public sealed class DataTable : Control
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTable"/> class.
    /// </summary>
    public DataTable()
    {
    }

    /// <summary>
    /// Gets or sets the background color of the table's heading row.
    /// </summary>
    [JsonPropertyName("headingRowColor")]
    public string? HeadingRowColor
    {
        get => GetProperty<string>(nameof(HeadingRowColor));
        set => SetProperty(nameof(HeadingRowColor), value);
    }

    /// <summary>
    /// Gets or sets the height of the table's heading row.
    /// Defaults to 56.0.
    /// </summary>
    [JsonPropertyName("headingRowHeight")]
    public double? HeadingRowHeight
    {
        get => GetProperty<double?>(nameof(HeadingRowHeight));
        set => SetProperty(nameof(HeadingRowHeight), value);
    }

    /// <summary>
    /// Gets or sets the height of each data row (excluding the heading row).
    /// </summary>
    [JsonPropertyName("dataRowHeight")]
    public double? DataRowHeight
    {
        get => GetProperty<double?>(nameof(DataRowHeight));
        set => SetProperty(nameof(DataRowHeight), value);
    }

    /// <summary>
    /// Gets or sets the minimum height of each data row (excluding the heading row).
    /// </summary>
    [JsonPropertyName("dataRowMinHeight")]
    public double? DataRowMinHeight
    {
        get => GetProperty<double?>(nameof(DataRowMinHeight));
        set => SetProperty(nameof(DataRowMinHeight), value);
    }

    /// <summary>
    /// Gets or sets the maximum height of each data row (excluding the heading row).
    /// </summary>
    [JsonPropertyName("dataRowMaxHeight")]
    public double? DataRowMaxHeight
    {
        get => GetProperty<double?>(nameof(DataRowMaxHeight));
        set => SetProperty(nameof(DataRowMaxHeight), value);
    }

    /// <summary>
    /// Gets or sets the default text style for the table's heading row.
    /// </summary>
    [JsonPropertyName("headingTextStyle")]
    public string? HeadingTextStyle
    {
        get => GetProperty<string>(nameof(HeadingTextStyle));
        set => SetProperty(nameof(HeadingTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the default text style for data rows.
    /// </summary>
    [JsonPropertyName("dataTextStyle")]
    public string? DataTextStyle
    {
        get => GetProperty<string>(nameof(DataTextStyle));
        set => SetProperty(nameof(DataTextStyle), value);
    }

    /// <summary>
    /// Gets or sets the default column width for the data table.
    /// </summary>
    [JsonPropertyName("columnSpacing")]
    public double? ColumnSpacing
    {
        get => GetProperty<double?>(nameof(ColumnSpacing));
        set => SetProperty(nameof(ColumnSpacing), value);
    }

    /// <summary>
    /// Gets or sets the horizontal margin between the table's edge and its checkboxes/first column.
    /// </summary>
    [JsonPropertyName("horizontalMargin")]
    public double? HorizontalMargin
    {
        get => GetProperty<double?>(nameof(HorizontalMargin));
        set => SetProperty(nameof(HorizontalMargin), value);
    }

    /// <summary>
    /// Gets or sets the size of the checkbox in the table heading and data rows.
    /// </summary>
    [JsonPropertyName("checkboxHorizontalMargin")]
    public double? CheckboxHorizontalMargin
    {
        get => GetProperty<double?>(nameof(CheckboxHorizontalMargin));
        set => SetProperty(nameof(CheckboxHorizontalMargin), value);
    }

    /// <summary>
    /// Gets or sets the decoration to display behind the data rows.
    /// </summary>
    [JsonPropertyName("decoration")]
    public string? Decoration
    {
        get => GetProperty<string>(nameof(Decoration));
        set => SetProperty(nameof(Decoration), value);
    }

    /// <summary>
    /// Gets or sets the background color of data rows.
    /// </summary>
    [JsonPropertyName("dataRowColor")]
    public string? DataRowColor
    {
        get => GetProperty<string>(nameof(DataRowColor));
        set => SetProperty(nameof(DataRowColor), value);
    }

    /// <summary>
    /// Gets or sets the divider color between rows.
    /// </summary>
    [JsonPropertyName("dividerThickness")]
    public double? DividerThickness
    {
        get => GetProperty<double?>(nameof(DividerThickness));
        set => SetProperty(nameof(DividerThickness), value);
    }

    /// <summary>
    /// Gets or sets whether the first column should remain fixed when scrolling horizontally.
    /// Defaults to false.
    /// </summary>
    [JsonPropertyName("showCheckboxColumn")]
    public bool? ShowCheckboxColumn
    {
        get => GetProperty<bool?>(nameof(ShowCheckboxColumn));
        set => SetProperty(nameof(ShowCheckboxColumn), value);
    }

    /// <summary>
    /// Gets or sets the direction in which the table's content will overflow and be clipped.
    /// Values: "none", "hardEdge", "antiAlias", "antiAliasWithSaveLayer"
    /// </summary>
    [JsonPropertyName("clipBehavior")]
    public string? ClipBehavior
    {
        get => GetProperty<string>(nameof(ClipBehavior));
        set => SetProperty(nameof(ClipBehavior), value);
    }

    /// <summary>
    /// Gets or sets the border around the table.
    /// </summary>
    [JsonPropertyName("border")]
    public string? Border
    {
        get => GetProperty<string>(nameof(Border));
        set => SetProperty(nameof(Border), value);
    }

    /// <summary>
    /// Gets or sets the index of the currently sorted column (zero-based).
    /// </summary>
    [JsonPropertyName("sortColumnIndex")]
    public int? SortColumnIndex
    {
        get => GetProperty<int?>(nameof(SortColumnIndex));
        set => SetProperty(nameof(SortColumnIndex), value);
    }

    /// <summary>
    /// Gets or sets whether the sort order is ascending.
    /// Defaults to true.
    /// </summary>
    [JsonPropertyName("sortAscending")]
    public bool? SortAscending
    {
        get => GetProperty<bool?>(nameof(SortAscending));
        set => SetProperty(nameof(SortAscending), value);
    }

    /// <summary>
    /// Occurs when the user selects all rows.
    /// </summary>
    public event EventHandler? SelectAll;
}
