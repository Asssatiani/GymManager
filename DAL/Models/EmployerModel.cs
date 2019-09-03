using System;

namespace DAL.Models
{
    public class EmployerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        public string ProfileImage { get; set; }

        public string ProfileImagePath
        {
            get
            {
                return $@"..\Resources\Images\{ProfileImage}";
            }
        }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

    }
}
