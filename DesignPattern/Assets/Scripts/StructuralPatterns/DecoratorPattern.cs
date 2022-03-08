namespace DesignPatterns.DecoratorPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 데코레이터 패턴
    /// 객체에 동적 기능을 추가하기 위해 구조를 개선하는 패턴
    /// </summary>
    public interface IFood // Component
    {
        string ToString();
    }

    public class Soup : IFood
    {
        public override string ToString()
        {
            return "수프";
        }
    }

    public abstract class Decorator : IFood
    {
        protected IFood _food;

        public Decorator(IFood food)
        {
            _food = food;
        }
        public abstract override string ToString();
    }

    public class Seasoning : Decorator
    {
        public Seasoning(IFood food) : base(food)
        {
        }
        public override string ToString()
        {
            return _food.ToString() + "+조미료첨가";
        }
    }

    public class Source : Decorator
    {
        public Source(IFood food) : base(food)
        {
        }
        public override string ToString()
        {
            return _food.ToString() + "+소스첨가";
        }
    }
}