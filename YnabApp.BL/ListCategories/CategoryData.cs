using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL.ListCategories
{
    public class CategoryData
    {
        public string Id { get; set; }

        public string CategoryGroupId { get; set; }

        public string Name { get; set; }

        public bool IsHidden { get; set; }

        public bool IsDeleted { get; set; }

        public decimal CrunchedAmount { get; set; }
    }
}
