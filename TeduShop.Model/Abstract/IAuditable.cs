using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        string CreateBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        string UpdateBy { set; get; }

        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }

        bool Status { set; get; }
    }
}
