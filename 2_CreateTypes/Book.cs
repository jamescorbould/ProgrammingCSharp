using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CreateTypes
{
    [DebuggerDisplay("Title == {Title}")]
    class Book
    {
        [Developer("JamesC", level:"1", Reviewed=true)] // Implies a constructor with 2 parameters, name and level, on the attribute class and a property called reviewed.
        private string Title { get; set; }

        public Book(string title)
        {
            this.Title = title;
        }
    }
}
