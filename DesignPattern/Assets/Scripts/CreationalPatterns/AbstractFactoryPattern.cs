namespace DesignPatterns.AbstractFactoryPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 추상 팩토리 패턴
    /// 팩토리 메서드 패턴의 확장판
    /// 큰 규모의 객체군을 형성하는 패턴
    /// </summary>
    public abstract class FoodMaker
    {
        public abstract Dessert CreateDessert();
        public abstract Meal CreateMeal();

        public abstract override string ToString();
    }


    public class KoreanStyleFoodVendingMachine : FoodMaker
    {
        public KoreanStyleFoodVendingMachine()
        {
            Debug.Log("한식자판기 생성");
        }

        public override Dessert CreateDessert()
        {
            return new KoreanStyleDessert();
        }

        public override Meal CreateMeal()
        {
            return new KoreanStyleMeal();
        }
        public override string ToString()
        {
            return "한식자판기";
        }
    }

    public class WesternStyleFoodVendingMachine : FoodMaker
    {
        public WesternStyleFoodVendingMachine()
        {
            Debug.Log("양식자판기 생성");
        }

        public override Dessert CreateDessert()
        {
            return new WesternStyleDessert();
        }

        public override Meal CreateMeal()
        {
            return new WesternStyleMeal();
        }
        public override string ToString()
        {
            return "양식자판기";
        }

    }






    #region ##### Meal #####

    public abstract class Meal
    {
        public abstract override string ToString();
    }


    public class KoreanStyleMeal : Meal
    {
        public KoreanStyleMeal()
        {
            Debug.Log("한식 생성");
        }
        public override string ToString()
        {
            return "국밥";
        }
    }

    public class WesternStyleMeal : Meal
    {
        public WesternStyleMeal()
        {
            Debug.Log("양식 생성");
        }
        public override string ToString()
        {
            return "파스타";
        }
    }

    #endregion






    #region ##### Dessert #####

    public abstract class Dessert
    {
        public abstract override string ToString();

    }


    public class KoreanStyleDessert : Dessert
    {
        public KoreanStyleDessert()
        {
            Debug.Log("한식 디저트 생성");
        }

        public override string ToString()
        {
            return "수정과";
        }
    }

    public class WesternStyleDessert : Dessert
    {
        public WesternStyleDessert()
        {
            Debug.Log("양식 디저트 생성");
        }
        public override string ToString()
        {
            return "푸딩";
        }
    }

    #endregion

}