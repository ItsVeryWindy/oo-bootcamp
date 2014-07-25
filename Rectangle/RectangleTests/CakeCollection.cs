using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleTests
{
    class CakeCollection : IEnumerable
    {
        private readonly List<string> _cakes = new List<string>(); 

        internal void Add(IPerimeter cake)
        {
            _cakes.Add("Cake has perimeter: " + cake.Perimeter);
        }

        public string this[int index]
        {
            get { return _cakes[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
