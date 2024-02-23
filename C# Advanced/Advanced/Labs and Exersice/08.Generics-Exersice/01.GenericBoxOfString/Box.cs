using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        private T Text { get; set; }
        public Box(T text)
        {
            Text = text;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(typeof(T) + ": " + Text);
            return sb.ToString().TrimEnd();
        }
    }
}
