using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib
{
    //класс Dll, содержит методы работы с задачами
    public class TasksDll
    {
        //создание листа для задач
        private List<Task> _tasks = new List<Task>();

        //метод, создающий новую задачу
        public Task CreateTask(Task newTask)
        {
            _tasks.Add(newTask);
            return _tasks.First(it => it.id == newTask.id);
        }

        //метод, удаляющий задачу по ее id
        public bool DeleteTask(int taskId)
        {
            Task taskDelete = _tasks.First(it => it.id == taskId);  //получение задачи по ее id из листа
            if (taskDelete != null)
            {
                _tasks.Remove(taskDelete);  //удаление задачи
                return true;  //задача удалена
            }
            else
            {
                return false;  //задача не удалена 
            }
        }

        //метод, обновляющий задачу
        public bool UpdateTask(Task oldTask, Task updTask)
        {
            //обновление полей старой задачи новыми
            oldTask.id = updTask.id;
            oldTask.name = updTask.name;
            oldTask.creatDate = updTask.creatDate;
            oldTask.priority = updTask.priority;
            oldTask.status = updTask.status;
            oldTask.user = updTask.user;

            //проверка равенства задач
            if(oldTask.id == updTask.id && oldTask.name == updTask.name && oldTask.creatDate == updTask.creatDate && oldTask.priority == updTask.priority && oldTask.status == updTask.status && oldTask.user == updTask.user )
            {
                return true;  //задача обновлена
            }                 
            return false;
        }

        //метод, возвращающий задачу по ее id
        public Task GetTaskById(int idTask)
        {
            return _tasks.First(it => it.id == idTask);
        }

        //метод, возвращающий список всех задач
        public List<Task> GetAllTask()
        {      
            return _tasks.ToList(); 
        }

        //метод, сравнивающий два переданных листа с задачами
        public bool СomparisonLists(List<Task> exp, List<Task> act)
        {
            if (exp.Count == act.Count)  //если кол-во задач в листах совпадает сравниваем их
            {
                int i = 0;
                bool flag = false;
                // сравнение каждой задачи из листа act с задачами из листа exp
                foreach (Task task in act)
                {
                    if (task == exp[i])
                    {
                        i++;
                        flag = true;  //задачи совпадают
                    }
                    else
                    {
                        flag = false;  //задачи не совпадают
                        break;
                    }
                }
                return flag;
            }
            return false; //списки не равны
        }

        //метод, возвращающий список задач по статусу
        public IEnumerable<Task> GetTasksStatus(Status status)
        {
            return _tasks.Where(t => t.status == status);
        }

        //метод, возвращающий список задач по приоритету
        public IEnumerable<Task> GetTasksPriority(Priority priority)
        {
            return _tasks.Where(t => t.priority == priority);
        }

        //метод, возвращающий кол-во всех задач в листе
        public int GetTaskCount()
        {
            return _tasks.Count;
        }

        //метод, возвращающий кол-во задач по пользователю
        public int GetTasksUser(int idUser, string nameUser)
        {
            int count = 0;  //кол-во найденных задач
            foreach (Task task in _tasks)
            {
                if (task.user.id == idUser && task.user.name == nameUser)
                {
                    count++;
                }
            }
            return count;
        }

        //метод, возвращающий кол-во задач по дате создания
        public int GetTaskDate(DateTime date)
        {
            int count = 0;  //кол-во найденных задач
            foreach (Task task in _tasks)
            {
                if (task.creatDate == date)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
