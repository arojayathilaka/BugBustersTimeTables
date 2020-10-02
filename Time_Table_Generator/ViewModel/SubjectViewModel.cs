using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class SubjectViewModel
    {
        SubjectData _subjectData;
        public SubjectViewModel()
        {
            _subjectData = new SubjectData();
        }

        public List<SubjectEntity> LoadSubjectData()
        {
            return _subjectData.LoadData();
        }

        public void SaveSubjectData(SubjectEntity Subject)
        {
            _subjectData.SaveData(Subject);
        }

        public void UpdateSubjectData(SubjectEntity Subject)
        {
            _subjectData.UpdateData(Subject);
        }

        public void DeleteSubjectData(int SubjectId)
        {
            _subjectData.DeleteData(SubjectId);
        }
    }
}
