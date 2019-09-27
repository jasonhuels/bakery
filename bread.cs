namespace BreadNS
{
    public class Bread
    {
        public int Price { get; set; }
        public Bread()
        {
            Price = 5;
        }

        public int GetCost(int quantity)
        {
            int cost = 0;
            while(quantity > 0)
            {
                if(quantity % 3 == 0)
                {
                    cost += Price*2;
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