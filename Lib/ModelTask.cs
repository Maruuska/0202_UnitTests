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
        public int id;   //номер задачи
        public string name;  //название задачи
        public DateTime creatDate;  //дата создания задачи
        public Priority priority;   //приоритетность задачи
        public Status status;       //статус задачи
        public User user;           //создатель задачи

        //конструктор класса Task, создающий задачу
        public Task(int id, string name, DateTime creatDate, Priority priority, Status status, User user)   
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
        public int id;    //id пользователя, создающего задачу
        public string name;    //имя пользователя

        //конструктор класса User, создающий нового поьзователя
        public User(int id, string name)  
        {
            this.id = id;
            this.name = name;
        }
    }
}
