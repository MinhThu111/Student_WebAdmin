using Student_WebAdmin.Models;

namespace Student_WebAdmin.Services
{
    public class S_Student:IS_Student
    {
        public List<M_Student> getAll()
        {
            return new List<M_Student>()
            {
                new M_Student()
                {
                  id= 1,
                  firstName = "A",
                  lastName = "Nguyen thi ",
                  gender = 1,
                  email = "123@gmail.com",
                  avatar = "none",
                  className = "19DTH1",
                  schoolName = "DNTU",
                  status =0,
                  maths = new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  physics=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  chemistry=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  }

                },
                new M_Student()
                {
                  id= 2,
                  firstName = "B",
                  lastName = "Tran Van ",
                  gender = 0,
                  email = "12345@gmail.com",
                  avatar = "none",
                  className = "19DTH2",
                  schoolName = "DNTU",
                  status=1,
                  maths = new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  physics=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  chemistry=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  }
                },
                new M_Student() {
                  id= 3,
                  firstName = "A",
                  lastName = "Nguyen thi ",
                  gender = 1,
                  email = "123@gmail.com",
                  avatar = "none",
                  className = "19DTH1",
                  schoolName = "DNTU",
                  status=1,
                  maths = new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  physics=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  chemistry=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  }

                },
                new M_Student() {
                  id= 4,
                  firstName = "Mở",
                  lastName = "Nguyen thi ",
                  gender = 1,
                  email = "123@gmail.com",
                  avatar = "https://upload.wikimedia.org/wikipedia/vi/0/03/Haruno_Sakura.jpg",
                  className = "19DTH1",
                  schoolName = "DNTU",
                  status=0,
                  maths = new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  physics=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  },
                  chemistry=new Point()
                  {
                      fifteenMinutes=10,
                      sixtyMinutes=9,
                      midTerm=8,
                      lastTerm=9.5
                  }

                }
            };
        }
        public bool Create(M_Student model)
        {
            List<M_Student> data = getAll();
            data.Add(model);
            return true;
        }
    }
}
