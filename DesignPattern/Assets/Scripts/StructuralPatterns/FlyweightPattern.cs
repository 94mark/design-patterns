namespace DesignPatterns.FlyweightPattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 플라이웨이트 패턴
    /// 객체를 공유하기 위해 구조를 변경하는 패턴
    /// </summary>
    public class Market
    {
        List<IGoodsData> _sharedList = new List<IGoodsData>();

        List<Goods> _bucket = new List<Goods>();

        public Market()
        {
            _sharedList.Add(new FoodGoodsData("토마토", 10));
            _sharedList.Add(new FoodGoodsData("무우", 5));
            _sharedList.Add(new FoodGoodsData("대파", 3));
            _sharedList.Add(new FoodGoodsData("양파", 4));
            _sharedList.Add(new FoodGoodsData("등심", 20));
            _sharedList.Add(new FoodGoodsData("안심", 30));
        }

        public IGoodsData GetGoodsData(string name, int cost)
        {
            var goodsData = FindGoodsData(name, cost);
            if (goodsData == null)
                goodsData = AddFoodData(name, cost);
            return goodsData;
        }

        private IGoodsData AddFoodData(string name, int cost)
        {
            var goodsData = new FoodGoodsData(name, cost);
            _sharedList.Add(goodsData);
            return goodsData;
        }

        private IGoodsData FindGoodsData(string name, int cost)
        {
            return _sharedList.Where(data => data.name == name && data.cost == cost).SingleOrDefault();
        }

        public void PutGoodsData(IGoodsData goodsData, int value)
        {
            _bucket.Add(new Goods(goodsData, value));
        }

        public string ToBill()
        {
            var str = "";
            for (int i = 0; i < _bucket.Count; i++)
            {
                str += _bucket[i].ToString();
            }
            return str;
        }
    }

    public interface IGoodsData
    {
        string name { get; }
        int cost { get; }

    }

    public class FoodGoodsData : IGoodsData
    {
        private string _name;
        private int _cost;

        public string name => _name;
        public int cost => _cost;

        public FoodGoodsData(string name, int cost)
        {
            _name = name;
            _cost = cost;
        }
    }


    public class Goods
    {
        private IGoodsData _goodsData;
        private int _value;

        public Goods(IGoodsData goodsData, int value)
        {
            _goodsData = goodsData;
            _value = value;
        }

        public override string ToString()
        {
            return $"{_goodsData.name} {_value} {_goodsData.cost * _value} {_goodsData.GetHashCode()}\n";
        }
    }

}