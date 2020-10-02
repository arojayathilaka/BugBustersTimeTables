using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {

            List<LecturerEntity> lecturerEntities = new List<LecturerEntity>
            {
                new LecturerEntity{Name="Saman" , EmployeeId = 1001},
                new LecturerEntity{Name="Kumara" , EmployeeId = 1002}
            };

            //UI
            string[] vs = new string[] { "1001", "1002" };
            SessionEntity sessionEntity = new SessionEntity { LecturerIds = string.Join(",", vs) };

            Console.WriteLine("TO DB");
            //sessionEntity.LecturerIds = string.Join(",", vs);


            Console.WriteLine(sessionEntity.LecturerIds);


            Console.WriteLine("FROM DB");
            SessionEntity sessionEntity1 = new SessionEntity { LecturerIds = "1001,1002" };

            sessionEntity1.SessionLectures = new List<LecturerEntity>();
            for (int i = 0; i < sessionEntity1.LecturerIdsArr.Length; i++)
            {
                sessionEntity1.SessionLectures.Add(lecturerEntities.Find(e => e.EmployeeId == sessionEntity1.LecturerIdsArr[i]));
            }

            Console.WriteLine(sessionEntity1.SessionLectures[0].Name);


            Console.ReadLine();
        }


    }
}
