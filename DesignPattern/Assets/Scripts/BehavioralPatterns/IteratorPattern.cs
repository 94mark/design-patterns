namespace DesignPatterns.IteratorPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 반복자 패턴
    /// 내부구조를 노출하지 않고 집합체를 통해 원소 객체에 순차적으로 접근할 수 있는 방법을 제공
    /// </summary>

    public interface IIterator //Iterator
    {
        bool HasNext();
        Food Next();
    }

    public class Iterator : IIterator //Iterator1
    {
        private Bucket _bucket;
        private int _index = 0;

        public Iterator(Bucket bucket)
        {
            _index = 0;
            _bucket = bucket;
        }

        public bool HasNext()
        {
            return _index < _bucket.GetLength();
        }

        public Food Next()
        {
            if (_index < _bucket.GetLength())
                return _bucket[_index++];
            throw new System.Exception();
        }

    }

    public interface IBucket //Aggregate
    {
        IIterator CreateIterator();
    }

    public class Bucket : IBucket //Aggregate1
    {
        private Food[] foods;

        public Food this[int i]
        {
            get
            {
                return foods[i];
            }
        }

        public int GetLength() => foods.Length;
        public Bucket(params string[] arr)
        {
            foods = new Food[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                foods[i] = new Food(arr[i]);
            }
        }

        public IIterator CreateIterator()
        {
            var iterator = new Iterator(this);
            return iterator;
        }
    }

    public class Food
    {
        private string _name;
        public Food(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}