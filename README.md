<h1 align = "center"> Task Management DLL </h1>
<h2>Описание</h2>
Библиотека TasksDll предназначена для обработки задач. Она предоставляет функциональность для создания задач, их удаления, обновления, отбора по заданным параметрам.

<h2>Структура</h2>
- MyDllTests.cs - класс, содержащий набор автоматизированных тестов, реализованных с использованием платформы MSTest.
- TasksDll.cs - библиотека, содержащая методы обработки задач
- ModelTask.cs - класс, содержащий модель задачи

<h2>Класс TasksDll содержит следующие методы </h2>
1. `public Task CreateTask(Task newTask)` - создание задачи
Параметры: newTask - новая задача
2. `public bool DeleteTask(int taskId)` - удаление задачи
Параметры: taskId - номер задачи, которую нужно удалить
3. `public bool UpdateTask(Task oldTask, Task updTask)` - изменение информации о задаче (приоритет, статус и т;д;)
Параметры: oldTask - задача, которую нудно обновить, updTask - значения для обновления задачи
4. public Task GetTaskById(int idTask) - получение информации о задаче по ID
Параметры: idTask - id задачи, которая будет возвращена
5. `public List<Task> GetAllTask()` - получение списка всех задач
6. `public bool СomparisonLists(List<Task> exp, List<Task> act)` - сравнение двух листов
Параметры: exp - ожидаемая задача, act - акутальная задача
7. `public IEnumerable<Task> GetTasksStatus(Status status)` - получение задач по статусу
Параметры: status - статус для отбора задач
8. `public IEnumerable<Task> GetTasksPriority(Priority priority)` - получение задач по приоритету
Параметры: priority - приоритет для отбора задач
9. `public int GetTaskCount()` - получение количества всех задач
10. `public int GetTasksUser(int idUser, string nameUser)` - получение задач по пользователю
Параметры: idUser - id пользователя, nameUser - имя пользователя
11. `public int GetTaskDate(DateTime date)` - получение задач по дате создания
Параметры: date - дата для отбора задач

<h2>Использование</h2>
Для использования библиотеки `TasksDll` необходимо добавить ссылку на DLL в проект. После этого необходимо создать экземпляр класса TasksDll, передав ему данные задачи и использовать предоставленные методы для обработки задач.
