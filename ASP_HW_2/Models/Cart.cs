using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_HW_2.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void Add(Bicycle bicycle, int number)
        {
            CartLine cartLine = lineCollection.FirstOrDefault(x => x.Bicycle.BicycleId == bicycle.BicycleId);
            if(cartLine == null)
            {
                lineCollection.Add(new CartLine
                {
                    Bicycle = bicycle,
                    Number = number
                }); 
            }
            else
            {
                cartLine.Number += number;
            }

        }

        public void Delete(Bicycle bicycle)
        {
            lineCollection.RemoveAll(x => x.Bicycle.BicycleId == bicycle.BicycleId);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public int GetTotalValue()
        {
            return lineCollection.Sum(x => (int)x.Bicycle.Price * x.Number);
        }

        public IEnumerable<CartLine> GetAllLines
        {
            get => lineCollection;
        }
   
    }

}
