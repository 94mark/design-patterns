namespace DesignPatterns.TemplateMethodPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// 템플릿 메서드 패턴
    /// 메서드를 이용해 각 단계를 템플릿 구조화하고 행동을 구분
    /// </summary>
    public abstract class Work //AbstractClass
    {
        public void Process()
        {
            Move();
            Check();
            Working();
            Return();
        }

        protected abstract void Move();
        protected abstract void Check();
        protected abstract void Working();
        protected abstract void Return();
    }


    public class CompanyWork : Work //SubClass
    {
        protected override void Check()
        {
            Debug.Log("회사 출석");
        }

        protected override void Move()
        {
            Debug.Log("회사로 이동");
        }

        protected override void Return()
        {
            Debug.Log("집으로 퇴근");
        }

        protected override void Working()
        {
            Debug.Log("일하기");
        }
    }

    public class HomeWork : Work //SubClass
    {
        protected override void Check()
        {
            Debug.Log("집에서 출석");
        }

        protected override void Move()
        {
            Debug.Log("컴퓨터 부팅");
        }

        protected override void Return()
        {
            Debug.Log("컴퓨터 종료");
        }

        protected override void Working()
        {
            Debug.Log("집에서 일하기");
        }
    }
}