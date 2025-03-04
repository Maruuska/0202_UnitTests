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
        //public void CreateTask(Task newTask)
        //{
        //    _tasks.Add(newTask);
        //}

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
        public Task UpdateTask(Task oldTask, Task updTask)
        {
            oldTask.id = updTask.id;
            oldTask.name = updTask.name;
            oldTask.creatDate = updTask.creatDate;
            oldTask.priority = updTask.priority;
            oldTask.status = updTask.status;
            oldTask.user = updTask.user;
            return oldTask;
        }

        //public int UpdateTask(int u)
        //{
        //    return u + 20;
        //}


        //метод, возвращающий задачу по ее id
        public Task GetTaskById(int idTask)
        {
            return _tasks.FirstOrDefault(it => it.id == idTask);
        }

        //Получение списка всех задач
        public List<Task> GetAllTask(int idTask)
        {
            return _tasks.ToList();
        }


    }




}
