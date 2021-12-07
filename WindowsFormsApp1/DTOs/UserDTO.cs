using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager.DTOs
{
    public class UserDTO
    {
        private string userId;
        private string password;
        private string roleID;
        private string fullName;
        private bool status;
        private string majorId;

        public UserDTO()
        {
        }

        public UserDTO(string userId, string password, string roleID, string fullName, bool status, string majorId)
        {
            UserID = userId;
            Password = password;
            RoleID = roleID;
            FullName = fullName;
            Status = status;
            MajorID = majorId;
        }

        public string UserID { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string RoleID { get => roleID; set => roleID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public bool Status { get => status; set => status = value; }
        public string MajorID { get => majorId; set => majorId = value; }
    }
}
