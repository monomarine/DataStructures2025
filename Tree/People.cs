using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class People
    {
        public string Name { get; set; } //полезные данные
        public int age { get; set; }
        public People Left { get; set; } //ссылка на левое поддерево
        public People Right { get; set; } //ссылка на правое поддерево

        public People(string value = null, People left = null, People right = null, int age = 0)
        {
            this.Name = value;
            this.Left = left;
            this.Right = right;
            this.age = age;
        }
        public override string ToString() => Name;
    }
}
