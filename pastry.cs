namespace PastryNS
{
    public class Pastry
    {
        public int Price { get; set; }
        public Pastry()
        {
            Price = 2;
        }

        public int GetCost(int quantity)
        {
            int cost = 0;
            while(quantity > 0)
            {
                if(quantity % 3 == 0)
                {
                    cost += 5;
                    quantity -= 3;
                } 
                else
                {
                    cost += Price;
                    quantity--;
                }
            }          
            return cost;
        }
    }
}