using Student_WebAdmin.Models;

namespace Student_WebAdmin.Services
{
    public interface IS_Student
    {
        List<M_Student> getAll();
        bool Create(M_Student model);
    }
}
