using HUMAN;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace NEW_LESSON
{
    public class Program
    {
        static USER[] sortUsersByUsername(USER[] array)
        {
            string[] un_array = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                un_array[i] = array[i].username;
            }
            Array.Sort(un_array);
            USER[] users = new USER[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                foreach (USER user in array)
                {
                    if (user.username == un_array[i])
                    {
                        users[i] = user;
                        break;
                    }
                }
            }
            return users;
        }

        static USER[] filterByBirthYear(USER[] array, int Year)
        {
            int count = 0;
            foreach (var obj in array)
            {
                if (obj.getBirthYear() <= Year)
                {
                    count++;
                }
            }
            string[] passage = new string[count];
            for (int i = 0; i < array.Length; i++)
            {
                int y = array[i].getBirthYear();
                if (y <= Year)
                {
                    passage[count - 1] = array[i].getBirthYear().ToString() + array[i].username;
                    count--;
                }
            }
            Array.Sort(passage);
            Array.Reverse(passage);
            USER[] s_users = new USER[passage.Length];
            count = passage.Length;
            foreach (string age in passage)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (age == array[i].getBirthYear().ToString() + array[i].username)
                    {
                        s_users[count - 1] = array[i];
                        count--;
                    }
                }
            }
            return s_users;
        }
          
        static void Login(USER[] users, string username, string password)
        {
            bool lamp = false;
            foreach (var obj in users)
            {
                if (obj.username == username)
                {
                    lamp = true;
                    if (obj.Password == password)
                    {   
                        if (!obj.isLogged)
                        {
                            Console.WriteLine("successfully logged in");
                            obj.isLogged = true;
                            //Console.WriteLine(obj.isLogged);
                            break;  
                        }
                        else
                        {
                            Console.WriteLine("another user allready loged");
                        }
                    }
                    else
                    {
                        Console.WriteLine("incorrect username or password");
                    }
                }
            }
            if (!lamp) 
            {
                Console.WriteLine("user not found!");
            }
        }

        static void LogOut(USER[] users, string username)
        {
            bool lamp = false;
            foreach (var obj in users)
            {
                if (obj.username == username)
                {
                    lamp = true;
                    if (obj.isLogged)
                    {
                        Console.WriteLine("successfully logged out");
                        obj.isLogged = false;
                        //Console.WriteLine(obj.isLogged);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("user did not logged in to log out!");
                    }
                }
            }
            if (!lamp)
            {
                Console.WriteLine("user not found!");
            }
        }

        static USER[] CreateUser(ref USER[] array, USER user)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = user;
            return array;   
        }
        
        static USER[] DeleteUser(ref USER[] array, string username)
        {
            USER[] users = new USER[array.Length-1];

            for (int i=0; i<array.Length;i++) {
                if (array[i].username==username)
                {
                    continue;
                }
                else
                {
                    users[i]=array[i];
                }
            }

            array = users;

            return array;
        }

        static void Main()
        {
            USER insan = new USER("stiglitz", "buf2@gmail.com", true, true, "salam123", "inglorious  basterds ", "Raul", "Ibrahimov", 19, "male", "Spanish");

            USER insan_2 = new USER("doe_john", "john.doe@example.com", false, true, "john123", "The Matrix", "John", "Doe", 25, "male", "English");

            USER insan_3 = new USER("emma_w", "emma.white@gmail.com", true, false, "emma2025", "La La Land", "Emma", "White", 22, "female", "French");

            USER insan_4 = new USER("michael_b", "m.brown@yahoo.com", true, true, "brownie!", "Inception", "Michael", "Brown", 30, "male", "German");

            USER insan_5 = new USER("lucas_r", "lucasr@outlook.com", false, true, "lucaspass", "Avatar", "Lucas", "Rodriguez", 28, "male", "Spanish");

            USER insan_6 = new USER("sofia_k", "sofiak123@gmail.com", true, true, "skyblue7", "Titanic", "Sofia", "Keller", 24, "female", "Italian");

            USER insan_7 = new USER("alex_king", "alexking@mail.com", false, false, "king123", "The Godfather", "Alex", "King", 27, "male", "Portuguese");

            USER insan_8 = new USER("nina_l", "nina.l@protonmail.com", true, false, "nina@pass", "Barbie", "Nina", "Lopez", 21, "female", "Spanish");

            USER insan_9 = new USER("ethan_m", "ethan.miller@gmail.com", true, true, "ethanM!", "Interstellar", "Ethan", "Miller", 30, "male", "English");

            USER insan_10 = new USER("maria_d", "mariad@hotmail.com", false, true, "maria123", "Coco", "Maria", "Diaz", 26, "female", "Spanish");

            USER insan_11 = new USER("li_wei", "li.wei@china.cn", true, true, "dragon99", "Spirited Away", "Wei", "Li", 23, "male", "Chinese");

            USER insan_12 = new USER("fyteri", "farid@gmail.com", true, true, "bazar", "jj", "Farid", "Huseynzada", 20, "male", "Turk");

            USER[] users = { insan, insan_2, insan_3, insan_4, insan_5, insan_6, insan_7, insan_8, insan_9, insan_10, insan_11};

            //Console.WriteLine(sortUsersByUsername(users)[0].username);
            USER[] user = filterByBirthYear(users, 2000);
            foreach (var item in user)
            {
                Console.WriteLine(item.username +": "+ item.getBirthYear().ToString());
            }
            Console.WriteLine(insan_7.isLogged);
            Login(users, "alex_king", "king123");
            Console.WriteLine(insan_7.isLogged);
            LogOut(users, "alex_king");
            Console.WriteLine(insan_7.isLogged);
            Login(users, "alex_king", "king123");
            Console.WriteLine(insan_7.isLogged);
            Console.WriteLine(users[users.Length - 1].name);
            Console.WriteLine(CreateUser(ref users,insan_12));
            Console.WriteLine(users[users.Length - 1].name);
            Console.WriteLine(users.Length);
            DeleteUser(ref users,"fyteri");
            Console.WriteLine(users[users.Length - 1].name);
            Console.WriteLine(users.Length);
            //insan.changePassword("bazar123", "bazar123");
            //insan.changeEmail("rauli2@gmail.com",);
        }
    }
}
