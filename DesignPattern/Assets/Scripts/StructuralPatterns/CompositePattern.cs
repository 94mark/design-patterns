namespace DesignPatterns.CompositePattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 컴포지트 패턴
    /// 객체가 또 다른 객체를 포함
    /// </summary>
    public abstract class Room
    {
        public abstract override string ToString();
    }

    public class Box : Room
    {
        private string _name;

        private List<Room> _children = new List<Room>();
        public string name => _name;

        public Box(string name)
        {
            _name = name;
        }

        public void Add(Room room)
        {
            _children.Add(room);
        }

        public void Remove(Room room)
        {
            _children.Remove(room);
        }

        public bool IsHasRoom(Room room) => _children.Contains(room);

        public override string ToString()
        {
            var str = _name + "\n";
            for (int i = 0; i < _children.Count; i++)
            {
                str += _children[i].ToString() + "\n";
            }
            return str;
        }

    }

    public class Tray : Room
    {
        private string _name;

        public Tray(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }


}