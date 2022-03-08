namespace DesignPatterns.FactoryMethodPattern
{
    using UnityEngine;

    /// <summary>
    /// 팩토리 메소드 패턴
    /// 
    /// </summary>
    public abstract class FoodMaker
    {
        protected abstract Food CreateInstance(string name);

        public Food Create(string name)
        {
            return CreateInstance(name);
        }

        // 팩토리 패턴
        public static FoodMaker GetInstance()
        {
            return new FoodVendingMachine();
        }
    }

    public sealed class FoodVendingMachine : FoodMaker
    {

        public FoodVendingMachine()
        {
            Debug.Log("음식자판기 생성");
        }

        protected override Food CreateInstance(string name)
        {
            switch (name)
            {
                case "Soup":
                    return new Soup();
                case "Bread":
                    return new Bread();
            }
            return null;
        }

        public override string ToString()
        {
            return "음식자판기";
        }
    }


    public abstract class Food
    {
        public abstract override string ToString();
    }

    public class Soup : Food
    {
        public override string ToString()
        {
            return "수프";
        }
    }

    public class Bread : Food
    {
        public override string ToString()
        {
            return "빵";
        }
    }


}