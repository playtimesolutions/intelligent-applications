using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SimplePlugin;

public class Location
{
    [JsonPropertyName("X-axis (east-west) location")]
    public int X { get; set; }

    [JsonPropertyName("Y-axis (north-south) location")]
    public int Y { get; set; }

    [JsonPropertyName("Z-axis (height) location")]
    public int Z { get; set; }
}

public class DronePlugin
{
    private Location _location = new();

    [KernelFunction("get_current_location")]
    [Description("Returns the current location of the drone")]
    [return: Description("The current location of the drone")]
    public Location GetLocation() => _location;

    [KernelFunction("move_north")]
    [Description("Changes the X-axis location positive one step")]
    [return: Description("The updated location of the drone")]
    public Location MoveNorth()
    {
        _location.Y++;

        return _location;
    }

    [KernelFunction("move_south")]
    [Description("Changes the X-axis location negative one step")]
    [return: Description("The updated location of the drone")]
    public Location MoveSouth()
    {
        _location.Y--;

        return _location;
    }

    [KernelFunction("move_east")]
    [Description("Changes the Y-axis location positive one step")]
    [return: Description("The updated location of the drone")]
    public Location MoveEast()
    {
        _location.X++;

        return _location;
    }

    [KernelFunction("move_west")]
    [Description("Changes the Y-axis location negative one step")]
    [return: Description("The updated location of the drone")]
    public Location MoveWest()
    {
        _location.X--;

        return _location;
    }

    [KernelFunction("move_up")]
    [Description("Changes the Z-axis location positive one step")]
    [return: Description("The updated location of the drone")]
    public Location MoveUp()
    {
        _location.Z++;

        return _location;
    }

    [KernelFunction("move_down")]
    [Description("Changes the Z-axis location negative one step")]
    [return: Description("The updated location of the drone")]
    public Location MoveDown()
    {
        _location.Z--;

        return _location;
    }
}
