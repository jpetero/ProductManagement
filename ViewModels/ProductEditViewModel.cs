﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class ProductEditViewModel : ProductCreateViewModel
    {
        public string Id { get; set; }
        public string ExistingPhotoPath { get; set; }

    }
}
