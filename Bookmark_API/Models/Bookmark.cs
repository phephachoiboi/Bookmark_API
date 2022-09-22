using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmark_API.Models
{
    public class Bookmark
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }
        
        public DateTime Date { get; set; }
    }
}
