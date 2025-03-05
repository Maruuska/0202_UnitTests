using System;
using System.Threading.Tasks;

namespace Lib
{
    //класс Dll, содержит методы работы с задачами
    public class Dll
    {
        //создание листа для задач
        private List<Task> _tasks = new List<Task>();

        //метод, создающий новую задачу
        public Task CreateTask(Task newTask)
        {
            _tasks.Add(newTask);
            return _tasks.FirstOrDefault(it => it.id == newTask.id);
        }

        //метод, удаляющий задачу по ее id
        public bool DeleteTask(int taskId)
        {
            Task taskDelete = _tasks.FirstOrDefault(it => it.id == taskId);  //получение задачи по ее id из листа
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

        //метод, проверяющий, что список всех задач равен переданному
        public bool GetAllTask(List<Task> myList)
        {
            int countTaskMyList = myList.Count;  //кол-во задач в переданном листе
            if (countTaskMyList == _tasks.Count)  //если кол-во задач в листах совпадает сравниваем их
            {
                int i = 0;
                bool flag = false;
                // сравнение каждой задачи из переданного листа с задачами из листа _tasks
                foreach (Task task in _tasks)
                {
                    if (myList[i] == _tasks[i])
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
                return flag;  //списки равны
            }
            return false; //списки не равны
        }

        //метод, возвращающий кол-во задач с указанным статусом
        public int GetTaskStatus(Status status)
        {
            int count = 0;  //кол-во найденных задач
            foreach (Task task in _tasks)
            {
                if(task.status == status)
                {
                    count++;
                }
            }
            return count;
        }

        //метод, возвращающий кол-во задач с указанным приоритетом
        public int GetTaskPriority(Priority priority)
        {
            int count = 0;  //кол-во найденных задач
            foreach (Task task in _tasks)
            {
                if (task.priority == priority)
                {
                    count++;
                }
            }
            return count;
        }

        //метод, возвращающий кол-во задач в листе
        public int GetTaskCount()
        {
            return _tasks.Count;
        }

        //метод, возвращающий кол-во задач, созданных указанным пользователем
        public int GetTaskыUser(int idUser, string nameUser)
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
