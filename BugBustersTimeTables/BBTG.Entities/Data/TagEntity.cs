using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class TagEntity
    {

        public int TagId { get; set; }

        public string TagName { get; set; }

        public TagEntity()
        {

        }

        public TagEntity(int TagId, string TagName)
        {
            this.TagId = TagId;
            this.TagName = TagName;
        }
    }
}
