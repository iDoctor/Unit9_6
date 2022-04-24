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

Student newStudent = null;
try
{
    newStudent = new Student();
    newStudent.StudentName = "James007";

    if (newStudent.StudentID == 0)
        throw new InvalidStudentNameException(newStudent.StudentName);
}
catch (InvalidStudentNameException ex)
{
    Console.WriteLine(ex.Message);
}

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
        : base(String.Format("Некорректный ID у студента: {0}", name))
    {

    }
}