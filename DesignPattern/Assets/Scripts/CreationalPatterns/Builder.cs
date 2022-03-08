using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Height { get; set; }
    public string Colour { get; set; }

    public Bicycle(string make, string model, string colour, int height)
    {
        Make = make;
        Model = model;
        Colour = colour;
        Height = height;
    }
}

public interface IBicycleBuilder
{
    string Colour { get; set; }
    int Height { get; set; }

    Bicycle GetResult();
}

public class GTBuilder : IBicycleBuilder
{
    public string Colour { get; set; }
    public int Height { get; set; }

    public Bicycle GetResult()
    {
        return Height == 29 ? new Bicycle("GT", "Avalanche", Colour, Height) : null;
    }
}

public class MountainBikeBuildDirector
{
    private IBicycleBuilder _builder;
    public MountainBikeBuildDirector(IBicycleBuilder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.Colour = "Red";
        _builder.Height = 29;
    }

    public Bicycle GetResult()
    {
        return this._builder.GetResult();
    }
}

public class Client
{
    public void DoSomethingWithBicycles()
    {
        var builder = new GTBuilder();
        var director = new MountainBikeBuildDirector(builder);

        director.Construct();
        Bicycle myMountainBike = director.GetResult();
    }
}