using System;
using System.Security.Cryptography.X509Certificates;

using HUMAN;
namespace NEW_LESSON
{
    public class USER:Human
    {
        public string username;
        public string email;
        public bool isAdmin;
        public bool isLogged;
        private string password;
        public string bio;

        public string Password
        {
            get
            {
                if (password.Length >= 5)
                {
                    return password;
                }
                else
                {
                    return "error" ;
                }

            }
            set
            {
                if (password.Length >= 5)
                {
                    this.password = password;
                }
                else
                {
                    Console.WriteLine("error min must 5 chars"); 
                }
            }

        }

        public string Bio 
        {
            get
            {
                if (bio.Length <= 30)
                {
                    return bio;
                }
                else
                {
                    return "bio is too long";
                }
            }
            set
            {
                if (bio.Length <= 30)
                {
                     this.bio=bio;
                }
                else
                {
                    Console.WriteLine("error max must 30 chars");
                }
            }
        }

        public USER(string username, string email, bool isAdmin, bool isLogged, string password, string bio, string name, string surname, int age, string gender, string nation) : base( name,  surname, age,  gender, nation)
        {
            if(password.Length>=5) {
                this.username = username;
                this.email = email;
                this.isAdmin = isAdmin;
                this.isLogged = isLogged;
                this.password = password;
            }
            else
            {
                Console.WriteLine("please enter again your password must be min 5 char or bio max can be 30 chars");
            }
        }

        public USER(string username, string email, bool isLogged, string password, string bio, string name, string surname, int age, string gender, string nation, bool isAdmin=false):base(name, surname, age, gender, nation)
        {
            if (password.Length >= 5)
            {
                this.username = username;
                this.email = email;
                this.isAdmin = isAdmin;
                this.isLogged = isLogged;
                this.password = password;
            }
            else
            {
                Console.WriteLine("please enter again your password must be min 5 char or bio max can be 30 chars");
            }
        }

        public void changePassword(string currentPassword, string newPassword)
        {
            if (currentPassword == password && currentPassword!=newPassword)
            {
                password = newPassword;
            }
            else if (currentPassword == newPassword)
            {
                Console.WriteLine("your currrent and old passwords are same");
            } else
            {
                Console.WriteLine("your current password is wrong");
            }
        }

        public void changeEmail(string C_email, USER[] array)
        {
            bool lamp = false;
            foreach(USER obj in array)
            {
               if(obj.email == C_email)
               {
                    lamp = true;
                    break;
               }
            }
            if (!lamp)
            {
                this.email = C_email;
                Console.WriteLine("email updated succsesfuly");
            }
            else
            {
                Console.WriteLine("this email already had");
            }
        }
    }
}
