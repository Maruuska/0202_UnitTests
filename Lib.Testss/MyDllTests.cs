using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Lib.Tests
{
    [TestClass]
    public class MyDllTests
    {
        //объект класса Dll для доступа к методам
        private TasksDll _dll = new TasksDll();

        // Тест для проверки, что новая задача создается
        [TestMethod]
        public void CreateTask_CreateNewTask()
        {
            // Arrange
            //ожидаемая задача
            Task task1 = new Task(1, "test", DateTime.Now, Priority.Medium, Status.Open, new User(1, "Mark"));   //объект класса

            // Act
            Task actualTask = _dll.CreateTask(task1);

            // Assert
            Assert.AreEqual(task1, actualTask);   //сравнение созданной задачи с возвращенной из метода
        }

        // Тест для проверки, что задача с указанным id удаляется
        [TestMethod]
        public void DeleteTask_DeleteOldTask()
        {
            // Arrange
            Task task2 = new Task(2, "испечь кексик", DateTime.Now, Priority.High, Status.Open, new User(2, "Inna"));   //объект класса

            // Act
            Task t =_dll.CreateTask(task2);
            bool rez=_dll.DeleteTask(2);

            // Assert
            Assert.IsTrue(rez);
        }

        // Тест для проверки, что старая задача обновляется новыми данными
        [TestMethod]
        public void UpdateTask_UpdateOldTask()
        {
            // Arrange
            // задача, которую обновим
            Task origTask = new Task(3, "полить цветы", new DateTime(2000, 04, 30), Priority.Medium, Status.Close, new User(1, "Den"));   //объект класса
            // ожидаемая задача
            Task expectedTask = new Task(3, "полить кактусик", new DateTime(2000, 04, 30), Priority.Low, Status.Progress, new User(1, "Den"));   //объект класса

            // Act
            bool vozvrat = _dll.UpdateTask(origTask, expectedTask); //возвращает true если origTask обновилась

            // Assert
            Assert.IsTrue(vozvrat);  //проверка, что задача обновлена
        }

        // Тест для проверки, что по переданному id возвращается нужная задача 
        [TestMethod]
        public void GetTaskId_ReturnTask()
        {
            // Arrange
            //создание задачи
            Task task4 = new Task(4, "решить задачи", DateTime.Now, Priority.High, Status.Open, new User(2, "Inna"));
            Task create = _dll.CreateTask(task4);

            // Act
            Task actualTask = _dll.GetTaskById(4);  //получение задачи по ее id

            // Assert
            Assert.AreEqual(task4, actualTask);  //проверка, что возвращена правильная задача
        }

        //Тест для проверки, что возвращается список всех задач 
        [TestMethod]
        public void GetAllTasks_ReturnAllTask()
        {
            // Arrange
            //ожидаемый лист задач
            List<Task> expectedListTasks = new List<Task>
            {
                new Task(1, "нарисовать картинку", DateTime.Now, Priority.Low, Status.Progress, new User(3, "Jon")),
                new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"))
            };

            // Act
            //добавление задач в лист _tasks
            _dll.CreateTask(expectedListTasks[0]);
            _dll.CreateTask(expectedListTasks[1]);
            List<Task> actualList = _dll.GetAllTask();   //возврат списка всех задач
            bool sravnenie = _dll.СomparisonLists(expectedListTasks, actualList);   //возвращает true если листы равны

            // Assert
            Assert.IsTrue(sravnenie);  //проверка, что возвращены все задачи
        }

        //Тест для проверки, что возвращается список задач по статусу
        [TestMethod]
        public void GetStatusTasks_ReturnStatusTasks()
        {
            // Arrange
            //лист задач с двумя статусами Open
            List<Task> origListTasks = new List<Task>
            {
                new Task(1, "нарисовать картинку", DateTime.Now, Priority.Low, Status.Progress, new User(3, "Jon")),
                new Task(2, "купить чипсики", DateTime.Now, Priority.Low, Status.Open, new User(2, "Nick")),
                new Task(3, "съесть тыблочко", DateTime.Now, Priority.Low, Status.Open, new User(3, "Jon"))
            };

            // Act
            //добавление задач в лист _tasks
            _dll.CreateTask(origListTasks[0]);
            _dll.CreateTask(origListTasks[1]);
            _dll.CreateTask(origListTasks[2]);

            //возврат списка задач с указанным статусом
            var actualList = _dll.GetTasksStatus(Status.Open).ToList();   

            // Assert
            Assert.AreEqual(2, actualList.Count);  //сравнение кол-ва ожидаемых задач и полученных 
            Assert.IsTrue(actualList.All(t => t.status == Status.Open));  //проверка что все статусы в возвращенном листе равны заданному
        }

        //Тест для проверки, что возвращается список задач по приоритету
        [TestMethod]
        public void GetPriorityTasks_ReturnPriorityTasks()
        {
            // Arrange
            //создание задач в листе с тремя приоритетами High
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "пробежать 10 км", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);

            //возврат списка задач с указанным приоритетом
            var actualList = _dll.GetTasksPriority(Priority.High).ToList();

            // Assert
            Assert.AreEqual(3, actualList.Count);  //сравнение кол-ва ожидаемых задач и полученных
            Assert.IsTrue(actualList.All(t => t.priority == Priority.High));  //проверка что все приоритеты в возвращенном листе равны заданному
        }

        //Тест для проверки, что возвращается правильное количество задач в листе
        [TestMethod]
        public void GetCountTasks_ReturnCountTasks()
        {
            // Arrange
            //создание 4 задач в листе
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса
            Task task4 = new Task(3, "посмотреть киношку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            _dll.CreateTask(task4);
            int countTasks = _dll.GetTaskCount();  //возврат кол-ва задач

            // Assert
            Assert.AreEqual(4, countTasks);  //сравнение кол-ва ожидаемых задач и полученных
        }

        //Тест для проверки, что возвращается список задач по пользователю
        [TestMethod]
        public void GetUsersTasks_ReturnUsersTasks()
        {
            // Arrange
            //создание двух задач для Jon
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));
            Task task4 = new Task(4, "посмотреть киношку", DateTime.Now, Priority.High, Status.Progress, new User(7, "Rick"));

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            _dll.CreateTask(task4);
            int countTasks = _dll.GetTasksUser(3, "Jon");  //получение кол-ва задач с указанным пользователем

            // Assert
            Assert.AreEqual(2, countTasks);   //сравнение кол-ва ожидаемых задач и полученных
        }

        //Тест для проверки, что возвращается список задач по дате создания
        [TestMethod]
        public void GetDateTasks_ReturnDateTasks()
        {
            // Arrange
            //создание задач в листе с тремя приоритетами High
            Task task = new Task(1, "нарисовать картинку", new DateTime(2025, 10, 08), Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса
            Task task4 = new Task(3, "посмотреть киношку", DateTime.Now, Priority.High, Status.Progress, new User(7, "Rick"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            _dll.CreateTask(task4);
            int countTasks = _dll.GetTaskDate(new DateTime(2025, 10, 08));  //получение кол-ва задач с указанной датой

            // Assert
            Assert.AreEqual(1, countTasks);  //сравнение кол-ва ожидаемых задач и полученных
        }
    }
}
