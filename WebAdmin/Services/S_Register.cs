using Student_WebAdmin.Models;
namespace Student_WebAdmin.Services
{
    public class S_Register: IS_Register
    {
        public List<M_Register> getAll()
        {
            return new List<M_Register>()
            {
                new M_Register(){
                    Username="abc", 
                    Email="abc@gmail.com", 
                    Password="abc12345", 
                    ConfirmPassword="abc12345"
                },
                new M_Register(){
                    Username="bca", 
                    Email="bca@gmail.com", 
                    Password="bca12345", 
                    ConfirmPassword="bca12345"
                },
                new M_Register(){
                    Username="aaa", 
                    Email="aaa@gmail.com", 
                    Password="aaa12345", 
                    ConfirmPassword="aaa12345"
                },
                new M_Register(){
                    Username="qswe", 
                    Email="qswe@gmail.com", 
                    Password="qswe12345", 
                    ConfirmPassword="qswe12345"
                }
            };
        }
        public List<M_Register> Create(M_Register model)
        {
            List<M_Register> dataAccount = new List<M_Register>();
            dataAccount = getAll();            
            dataAccount.Add(model);
            return dataAccount;
        }
    }
}
