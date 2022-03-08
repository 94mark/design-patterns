using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foo
{
    public abstract Foo Clone();
}

public class ConcreteFoo1 : Foo
{
    public override Foo Clone()
    {
        return (Foo)this.MemberwiseClone();
    }
}

public class ConcreteFoo2 : Foo
{
    public override Foo Clone()
    {
        return (Foo)this.MemberwiseClone();
    }
}
