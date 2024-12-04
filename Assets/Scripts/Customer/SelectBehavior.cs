using System.Collections.Generic;

public interface SelectBehavior
{
    Shop SelectShop(Customer customer, List<Shop> shops);
}
