using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApi.Models
{

    public class OrderViewModel
    {
        public string userId { get; set; }

        
        public List<ItemViewModel> Items { get; set; }
    }

    
    public class ItemViewModel
    {
        
        public string ProductId { get; set; }
        public int Quantity { get; set; }

    }
}