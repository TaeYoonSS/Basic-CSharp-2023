﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepCopy
{
    class SomeClass
    {
        public int SomeField1;
        public int SomeField2;

        public SomeClass DeepCopy()
        {
            SomeClass newCopy = new SomeClass();
            newCopy.SomeField1 = this.SomeField1;
            newCopy.SomeField2 = this.SomeField2;   

            return newCopy;
        }


    }

    // this 사용법
    class Employee 
    {
        private string Name;
        public void SetName(string name) 
        {
            this.Name = name; // 멤버변수(속성) 와 매개변수 이름이 대소문자까지 완전히 똑같을 때 
        }

        class ThisClass
        {
            int a, b, c;

            public ThisClass()
            {
                this.a = 1;
            }

            public ThisClass(int b) : this()
            {
                this.b = b;
            }

            public ThisClass(int a, int b, int c) : this(b)
            {
                this.c = c;
            }   
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얕은 복사 시작"); // source 와 target이 (주소복사) 값이 쉐어 조심!

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source;
            target.SomeField2 = 300;

            Console.WriteLine("s.SomeField1 => {0}, s.SomeField2 => {1}",
                                source.SomeField1, source.SomeField2);

            Console.WriteLine("t.SomeField1 => {0}, t.SomeField2 => {1}",
                                target.SomeField1, target.SomeField2);
            
            Console.WriteLine("깊은 복사 시작");
            SomeClass s = new SomeClass();
            s.SomeField1 = 100; 
            s.SomeField2 = 200;

            SomeClass t = s.DeepCopy();



        }
    }
}
