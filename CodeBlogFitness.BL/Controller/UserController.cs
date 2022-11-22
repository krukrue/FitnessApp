using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CodeBlogFitness.BL.Controller
{
    public class UserController
    {
        public List<User> Users;
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string UserName) {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                throw new ArgumentNullException("Name is incorrect");
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == UserName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(UserName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users); 
            }
        }

        public List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is List<User> users)
                {
                    
                    return users;
                }
                else
                {
                    return new List<User>();
                }

            }
        }

        public void setNewUserData(string gender, DateTime birth, double weight = 1, int height = 1)
        {
            CurrentUser.Gender = new Gender(gender);
            CurrentUser.BirthDate = birth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
        }
        public static SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"dbsys.cs.vsb.cz\STUDENT";   
            builder.UserID = "kva0081";             
            builder.Password = "doBxrNSZ2pXJQA3z";      
            builder.InitialCatalog = "kva0081";
            return builder;
        }

    }
}
