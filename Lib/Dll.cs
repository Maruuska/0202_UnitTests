using System;
using System.Threading.Tasks;

namespace Lib
{
    //класс, содержащий методы работы с задачами
    public class Dll
    {
        //создание листа для задач
        private List<Task> _tasks = new List<Task>();

        //метод, создающий задачу
        public Task CreateTask(Task newTask)
        {
            _tasks.Add(newTask);
            return _tasks.FirstOrDefault(it => it.id == newTask.id);
        }

        //метод, удаляющий задачу по ее id
        public void DeleteTask(int taskId)
        {
            Task taskDelete = _tasks.FirstOrDefault(it => it.id == taskId);  //получение задачи по ее id из листа
            if (taskDelete != null)
            {
                _tasks.Remove(taskDelete);
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
                return true;
            }                 
            return false;
        }


        //метод, возвращающий задачу по ее id
        public Task GetTaskById(int idTask)
        {
            return _tasks.FirstOrDefault(it => it.id == idTask);
        }

        //Получение списка всех задач
        public List<Task> GetAllTask()
        {
            return _tasks.ToList();
        }

        //Получение задач по статусу
        public int GetTaskStatus(Status status)
        {
            int count = 0;
            foreach (Task task in _tasks)
            {
                if(task.status == status)
                {
                    count++;
                }
            }
            return count;
        }

        //Получение задач по приоритету
        public int GetTaskPriority(Priority priority)
        {
            int count = 0;
            foreach (Task task in _tasks)
            {
                if (task.priority == priority)
                {
                    count++;
                }
            }
            return count;
        }

        //Получение количества задач
        public int GetTaskCount()
        {
            return _tasks.Count;
        }

        //Получение задач по пользователю
        public int GetTaskUsers(int idUser, string nameUser)
        {
            int count = 0;
            foreach (Task task in _tasks)
            {
                if (task.user.id == idUser && task.user.name == nameUser)
                {
                    count++;
                }
            }
            return count;
        }

        //Получение задач по дате создания
        public int GetTaskDate(DateTime date)
        {
            int count = 0;
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
