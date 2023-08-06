using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Item_Marketplace.Models
{
    public class SortViewModel
    {
        public enum SortState
        {
            CreatedDtAsc,    // за порядком збільшення
            CreatedDtDesc,   // за порядком зменшення
            PriceAsc,        // за збільшенням прайсу
            PriceDesc,       // за зменшенням прайсу
        }
        public SortState CreatedDtSort { get; private set; }  // значення для сортування за порядком
        public SortState PriceSort { get; private set; }      // значення для сортування за пайсом
        public SortState Current { get; private set; }     // поточне значення після сортування

        public SortViewModel(SortState sortOrder)
        {
            CreatedDtSort = sortOrder == SortState.CreatedDtAsc ? SortState.CreatedDtDesc : SortState.CreatedDtAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }
    }
}
