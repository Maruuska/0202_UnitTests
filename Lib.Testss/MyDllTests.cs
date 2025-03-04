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
            Task expectedTask = new Task(3, "полить кактус", new DateTime(2000, 04, 30), Priority.Low, Status.Progress, new User(1, "Den"));   //объект класса
            Task expectedTask2 = new Task(3, "полить кактус", new DateTime(2000, 04, 30), Priority.Low, Status.Progress, new User(1, "Den"));

            // Act
            Task actualTask = _dll.UpdateTask(origTask, origTask);

            // Assert
            Assert.AreEqual(expectedTask, actualTask);
        }

        //[TestMethod]
        //public void UpdateTask_UpdateOldTask()
        //{
        //    int r = 10;
        //    int f = _dll.UpdateTask(r);
        //    int t = 30;
        //    Assert.AreEqual(t, f);
        //}

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
            List<Task> list = new List<Task>();

            // Act
            Task actualTask = _dll.GetTaskById(4);  //получение задачи по ее id

            // Assert
            //Assert.AreEqual(task4, actualTask);
        }

    }
}
