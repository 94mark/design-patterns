using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IBridge
{
    void Function1();
    void Function2();
}

public class Bridge1 : IBridge
{
    public void Function1()
    {
        Console.WriteLine("Bridge1.Function1");
    }

    public void Function2()
    {
        Console.WriteLine("Bridge1.Function2");
    }
}

public class Bridge2 : IBridge
{
    public void Function1()
    {
        Console.WriteLine("Bridge2.Function1");
    }

    public void Function2()
    {
        Console.WriteLine("Bridge2.Fuction2");
    }
}

public interface IAbstractBridge
{
    void CallMethod1();
    void CallMethod2();
}

public class AbstractBridge : IAbstractBridge
{
    public IBridge bridge;

    public AbstractBridge(IBridge bridge)
    {
        this.bridge = bridge;
    }

    public void CallMethod1()
    {
        this.bridge.Function1();
    }

    public void CallMethod2()
    {
        this.bridge.Function2();
    }
}