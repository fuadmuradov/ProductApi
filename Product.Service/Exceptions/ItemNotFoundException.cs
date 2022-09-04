using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Exceptions
{
    public class ItemNotFoundException:Exception
    {
        public ItemNotFoundException(string message):base(message)
        {

        }
    }
}
