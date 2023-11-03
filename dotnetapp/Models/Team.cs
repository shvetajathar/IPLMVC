using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Models
{
    public class Team
    {
         
        public string TeamName{get;set;}

       public ICollection<Player> Players{get;set;}
        
        // Write your Team class here...        
    }
}