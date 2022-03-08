namespace DesignPatterns.FactoryPattern
{
    using System;
    using UnityEngine;

    /// <summary>
    /// 팩토리 패턴
    /// 객체 생성을 위임합니다
    /// </summary>
    public class FoodMaker
    {
        public static T GetInstance<T>() where T : Food
        {
            return Activator.CreateInstance<T>();
        }

        public static Food GetInstance(string name)
        {
            switch (name)
            {
                case "Soup":
                    return new Soup();
                case "Bread":
                    return new Bread();
            }
            Debug.LogWarning($"{name}에 부합하는 클래스 이름이 없습니다");
            return null;
        }
    }



    public abstract class Food
    {
        public override abstract string ToString();
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