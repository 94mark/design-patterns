namespace DesignPatterns.InterpreterPattern
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 인터프리터 패턴
    /// 간단한 언어적 문법을 표현하는 패턴
    /// </summary>

    public class Client //Client
    {
        private Context _context;

        public int Interpret(string lex)
        {
            _context = new Context(lex);

            var stack = new Stack<IExpression>();

            while (_context.Next())
            {
                var token = _context.Current();

                if (int.TryParse(token, out int number))
                {
                    stack.Push(new Terminal(number));
                }
                else if (token == "+")
                {
                    if (stack.Count > 1)
                    {
                        var left = stack.Pop();
                        var right = stack.Pop();

                        var add = new Add(left, right);
                        var value = add.Interpret();

                        stack.Push(new Terminal(value));
                    }
                    else
                    {
                        Debug.Log("문장 오류");
                        return int.MinValue;
                    }
                }
            }

            if (stack.Count > 1)
            {
                Debug.Log("문장 오류");
                return int.MinValue;
            }
            else
            {
                return stack.Pop().Interpret();
            }
        }
    }

    public class Context //Context
    {
        private string[] _token;
        private int _index = -1;

        public Context(string text)
        {
            _token = text.Split(' ');
            _index = -1;
        }

        public bool Next()
        {
            if (_index + 1 < _token.Length)
            {
                _index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Current()
        {
            return _token[_index];
        }
    }


    public interface IExpression //Abstract Expression
    {
        int Interpret();
    }

    public class Add : IExpression //NonTerminal Expression
    {
        private IExpression _left;
        private IExpression _right;

        public Add(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() + _right.Interpret();
        }
    }

    public class Terminal : IExpression //Terminal Expression
    {
        private int _terminal;

        public Terminal(int terminal)
        {
            _terminal = terminal;
        }

        public int Interpret()
        {
            return _terminal;
        }
    }
}