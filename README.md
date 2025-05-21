<h1 align = "center"> Task Management DLL </h1>
<h2>Описание</h2>
Библиотека TasksDll предназначена для обработки задач. Она предоставляет функциональность для создания задач, их удаления, обновления, отбора по заданным параметрам.

<h2>Структура</h2>
- MyDllTests.cs - класс, содержащий набор автоматизированных тестов, реализованных с использованием платформы MSTest.<br>
- TasksDll.cs - библиотека, содержащая методы обработки задач<br>
- ModelTask.cs - класс, содержащий модель задачи<br>

<h2>Класс TasksDll содержит следующие методы </h2>
1. `public Task CreateTask(Task newTask)` - создание задачи. <br>
Параметры: newTask - новая задача.<br>
2. `public bool DeleteTask(int taskId)` - удаление задачи.<br>
Параметры: taskId - номер задачи, которую нужно удалить.<br>
3. `public bool UpdateTask(Task oldTask, Task updTask)` - изменение информации о задаче (приоритет, статус и т;д;).<br>
Параметры: oldTask - задача, которую нудно обновить, updTask - значения для обновления задачи.<br>
4. `public Task GetTaskById(int idTask)` - получение информации о задаче по ID.<br>
Параметры: idTask - id задачи, которая будет возвращена.<br>
5. `public List<Task> GetAllTask()` - получение списка всех задач.<br>
6. `public bool СomparisonLists(List<Task> exp, List<Task> act)` - сравнение двух листов.<br>
Параметры: exp - ожидаемая задача, act - акутальная задача.<br>
7. `public IEnumerable<Task> GetTasksStatus(Status status)` - получение задач по статусу.<br>
Параметры: status - статус для отбора задач.<br>
8. `public IEnumerable<Task> GetTasksPriority(Priority priority)` - получение задач по приоритету.<br>
Параметры: priority - приоритет для отбора задач.<br>
9. `public int GetTaskCount()` - получение количества всех задач.<br>
10. `public int GetTasksUser(int idUser, string nameUser)` - получение задач по пользователю.<br>
Параметры: idUser - id пользователя, nameUser - имя пользователя.<br>
11. `public int GetTaskDate(DateTime date)` - получение задач по дате создания.<br>
Параметры: date - дата для отбора задач.<br>

<h2>Использование</h2>
Для использования библиотеки `TasksDll` необходимо добавить ссылку на DLL в проект. После этого необходимо создать экземпляр класса TasksDll, передав ему данные задачи и использовать предоставленные методы для обработки задач.
