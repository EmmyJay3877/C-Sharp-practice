﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface IProductModel
    {
        string Title { get; set; }

        bool HasBeenDelivered { get; }

        void ShipItem(CustomerModel customer);

    }
}
