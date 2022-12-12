using Student_WebAdmin.Models;

namespace Student_WebAdmin.Services
{
    public interface IS_Register
    {
        List<M_Register> getAll();
        List<M_Register> Create(M_Register model);
    }
}
