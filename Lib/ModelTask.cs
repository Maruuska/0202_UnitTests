using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    //класс, описывающий модель задачи
    public class Task
    {
        public int id;
        public string name;
        public DateTime creatDate;
        public Priority priority;
        public Status status;
        public User user;

        public Task(int id, string name, DateTime creatDate, Priority priority, Status status, User user)   //конструктор
        {
            this.id = id;
            this.name = name;
            this.creatDate = creatDate;
            this.priority = priority;
            this.status = status;
            this.user = user;
        }
    }

    public enum Priority  //перечисление приоритетов задачи
    {
        Low,
        Medium,
        High
    }

    public enum Status    //перечисление статусов задачи
    {
        Open,
        Progress,
        Close
    }

    //класс, описывающий пользователя, создавшего задачу
    public class User
    {
        public int id;
        public string name;

        public User(int id, string name)  //конструктор
        {
            this.id = id;
            this.name = name;
        }
    }
}
