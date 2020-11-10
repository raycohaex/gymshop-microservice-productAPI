using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Classes
{
    public class QueryParameters
    {
        const int _maxSize = 100;
        private int _size = 20;

        public int Page { get; set; }
        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
    }
}
