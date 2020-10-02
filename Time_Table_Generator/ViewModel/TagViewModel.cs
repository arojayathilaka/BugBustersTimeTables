using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class TagViewModel
    {
        TagData _tagData;
        public TagViewModel()
        {
            _tagData = new TagData();
        }

        public List<TagEntity> LoadTagData()
        {
            return _tagData.LoadData();
        }

        public void SaveTagData(TagEntity tag)
        {
            _tagData.SaveData(tag);
        }

        public void UpdateTagData(TagEntity tag)
        {
            _tagData.UpdateData(tag);
        }

        public void DeleteTagData(int tagId)
        {
            _tagData.DeleteData(tagId);
        }
    }
}
