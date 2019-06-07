using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    using System;
    class Room
    {
        public Action<int> OnHeatAlert;
        int temp;
        public int Temperature
        {
            get { return this.temp; }
            set
            {
                temp = value;
                if (temp > 60)
                {
                    if (OnHeatAlert != null)
                    {
                        OnHeatAlert(temp);
                    }
                }
            }
        }
    }
}
