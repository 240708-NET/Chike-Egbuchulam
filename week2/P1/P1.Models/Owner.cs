using System.ComponentModel.DataAnnotations.Schema;

namespace P1.Models;

public class Owner
{
        public int Id {get;set;}
        public string Name {get;set;}
        [NotMapped]
        public Dictionary<string,int> Inventory{get;set;}
      
        


}
