﻿using BubaTube.Data.Models;
using System.Collections.Generic;

namespace BubaTube.Services.Contracts
{
    public interface ICategoryWriteService
    {
        void SaveToDatabase(IEnumerable<string> categories);

        IEnumerable<Category> FilterCategories(IEnumerable<string> categories);
    }
}
