using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Lib.Tests
{
    [TestClass]
    public class MyDllTests
    {
        //объект класса Dll для доступа к методам
        private Dll _dll = new Dll();

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

        [TestMethod]
        public void DeleteTask_DeleteOldTask()
        {
            // Arrange
            Task task2 = new Task(2, "испечь кексик", DateTime.Now, Priority.High, Status.Open, new User(2, "Inna"));   //объект класса

            // Act
            _dll.CreateTask(task2);
            _dll.DeleteTask(2);

            // Assert
            Task actualTask = _dll.GetTaskById(2);   //получение null если задача удалена
            Assert.IsNull(actualTask);
        }

        [TestMethod]
        public void UpdateTask_UpdateOldTask()
        {
            // Arrange
            // задача, которую обновим
            Task origTask = new Task(3, "полить цветы", new DateTime(2000, 04, 30), Priority.Medium, Status.Close, new User(1, "Den"));   //объект класса
            // ожидаемая задача
            Task expectedTask = new Task(3, "полить кактусик", new DateTime(2000, 04, 30), Priority.Low, Status.Progress, new User(1, "Den"));   //объект класса

            // Act
            bool vozvrat = _dll.UpdateTask(origTask, expectedTask);

            // Assert
            Assert.AreEqual(true, vozvrat);
        }


        [TestMethod]
        public void GetTaskId_ReturnTask()
        {
            // Arrange
            Task task4 = new Task(4, "решить задачи", DateTime.Now, Priority.High, Status.Open, new User(2, "Inna"));   //объект класса
            Task r = _dll.CreateTask(task4);

            // Act
            Task actualTask = _dll.GetTaskById(4);  //получение задачи по ее id

            // Assert
            Assert.AreEqual(task4, actualTask);
        }


        [TestMethod]
        public void GetAllTasks_ReturnAllTask()
        {
            // Arrange
            //создание двух задач в листе
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.Low, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(1, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            List<Task> list = _dll.GetAllTask();

            // Assert
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void GetStatusTasks_ReturnStatusTasks()
        {
            // Arrange
            //создание задач в листе с двумя статусами Open
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.Low, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.Low, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.Low, Status.Open, new User(3, "Jon"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            int countTasks = _dll.GetTaskStatus(Status.Open);

            // Assert
            Assert.AreEqual(2, countTasks);
        }

        [TestMethod]
        public void GetPriorityTasks_ReturnPriorityTasks()
        {
            // Arrange
            //создание задач в листе с тремя приоритетами High
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            int countTasks = _dll.GetTaskPriority(Priority.High);

            // Assert
            Assert.AreEqual(3, countTasks);
        }

        [TestMethod]
        public void GetCountTasks_ReturnCountTasks()
        {
            // Arrange
            //создание задач в листе с тремя приоритетами High
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса
            Task task4 = new Task(3, "посмотреть киношку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            _dll.CreateTask(task4);
            int countTasks = _dll.GetTaskCount();

            // Assert
            Assert.AreEqual(4, countTasks);
        }

        [TestMethod]
        public void GetUsersTasks_ReturnUsersTasks()
        {
            // Arrange
            //создание задач в листе с тремя приоритетами High
            Task task = new Task(1, "нарисовать картинку", DateTime.Now, Priority.High, Status.Progress, new User(3, "Jon"));   //объект класса
            Task task2 = new Task(2, "купить чипсики", DateTime.Now, Priority.High, Status.Open, new User(2, "Nick"));   //объект класса
            Task task3 = new Task(3, "съесть тыблочко", DateTime.Now, Priority.High, Status.Open, new User(3, "Jon"));   //объект класса
            Task task4 = new Task(3, "посмотреть киношку", DateTime.Now, Priority.High, Status.Progress, new User(7, "Rick"));   //объект класса

            // Act
            _dll.CreateTask(task);
            _dll.CreateTask(task2);
            _dll.CreateTask(task3);
            _dll.CreateTask(task4);
            int countTasks = _dll.GetTaskUsers(3,"Jon");

            // Assert
            Assert.AreEqual(2, countTasks);
        }

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
            int countTasks = _dll.GetTaskDate(new DateTime(2025, 10, 08));

            // Assert
            Assert.AreEqual(1, countTasks);
        }
    }
}
