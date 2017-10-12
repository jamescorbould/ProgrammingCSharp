using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    class Book
    {
        [Developer("JamesC", level:"1", Reviewed=true)]
        private string Title { get; set; }

        public Book(string title)
        {
            this.Title = title;
        }
    }
}
