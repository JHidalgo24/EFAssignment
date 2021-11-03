using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Day10Class.Models
{
    public class Blog
    {
        
        public int BlogId { get; set; }
        public string Name { get; set; }
        // emtity framwork relationship
        //navigation properties
        public List<Post> Post {get;set;}
    }
}