// Задание 1
using System.Text.RegularExpressions;

List<Exception> exceptionsList = new List<Exception> ()
{
    new NotImplementedException (),
    new DivideByZeroException (),
    new ArgumentNullException (),
    new IndexOutOfRangeException ()
};

foreach (Exception ex in exceptionsList)
{
    try
    {
        var type = ex.GetType();

        switch(ex)
        {
            case NotImplementedException:
                throw new NotImplementedException();
            case DivideByZeroException:
                throw new DivideByZeroException();
            case ArgumentNullException:
                throw new ArgumentNullException();
            case IndexOutOfRangeException:
                throw new IndexOutOfRangeException();
        }
    }
    catch (NotImplementedException)
    {
        Console.WriteLine("Возникло исключение NotImplementedException");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Возникло исключение DivideByZeroException");
    }
    catch (ArgumentNullException)
    {
        Console.WriteLine("Возникло исключение ArgumentNullException");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Возникло исключение IndexOutOfRangeException");
    }
    finally
    {
        Console.WriteLine("Выполнение кода в блоке finaly");
    }
}

Helper helper = new Helper();
Student newStudent = new Student();
try
{
    newStudent.StudentName = "Иван007";

    helper.ValidateStudent(newStudent);
}
catch (InvalidStudentNameException ex)
{
    Console.WriteLine(ex.Message);
}



// Задание 2
List<string> studentsList = new List<string> ()
{
    "Иванов",
    "Петров001",
    "Никитин",
    "Ярославов",
    "Авдотьев"
};

MyEvent evt = new MyEvent();

// Добавляем обработчик события
evt.UserEvent += helper.OrderStudents;

// Запустим событие
evt.OnUserEvent();

Console.WriteLine($"{Environment.NewLine}Введите 1(2) для выбора типа сортировки:");





class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
}

[Serializable]
class InvalidStudentNameException : Exception
{
    public InvalidStudentNameException() { }

    public InvalidStudentNameException(string name)
        : base(String.Format("Некорректное имя у студента: {0}", name))
    {

    }
}

class Helper
{
    public void ValidateStudent(Student std)
    {
        Regex regex = new Regex("^[а-яА-Я]+$");

        if (!regex.IsMatch(std.StudentName))
            throw new InvalidStudentNameException(std.StudentName);
    }

    // Обработчик события
    public void OrderStudents()
    {
        List<string> newList = new List<string>();
        try
        {
            // Проблемы с работой event + метод с параметрами и return
            // Должно быть:
            // public List<string> OrderStudents(List<string> itemsList, int orderSide)
            newList = newList.OrderBy(x => x).ToList();
        }
        catch (Exception ex)
        {

        }
    }
}



delegate void UI();

class MyEvent
{
    // Объявляем событие
    public event UI UserEvent;

    // Используем метод для запуска события
    public void OnUserEvent()
    {
        UserEvent();
    }
}