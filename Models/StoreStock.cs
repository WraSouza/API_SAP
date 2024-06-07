
namespace API_SAP.Models
{
    public class StoreStock
    {
        public StockItem stock_item { get; set; }
        public StoreStock()
        {
            
        }

        public StoreStock(StockItem stock_item)
        {
            this.stock_item = stock_item;
        }

        public class StockItem
        {
            public StockItem(int item_id, int product_id, int stock_id, int qty, bool is_in_stock)
            {
                this.item_id = item_id;
                this.product_id = product_id;
                this.stock_id = stock_id;
                this.qty = qty;
                this.is_in_stock = is_in_stock;
            }        

            public int item_id { get; set; }
            public int product_id { get; set; }
             public int stock_id { get; set; }
             public int qty { get; set; }
            public bool is_in_stock { get; set; }
        }
       
        
    }
}