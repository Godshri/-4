using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Задание_1
{
    public class User
    {

    public User(string login, string firstName, string surName, DateTime dateOfRegistration)
    {
        Login = login;
        FirstName = firstName;
        SurName = surName;
        DateOfRegistration = dateOfRegistration;
    }

    public User(string login, string firstName, string surName, string email, DateTime dateOfBirth) :
        this(login, firstName, surName, DateTime.Now)
    {
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    public User(string login, string firstName, string surName, string email, DateTime dateOfBirth, DateTime dateOfRegistration) :
        this(login, firstName, surName, dateOfRegistration)
    {
        Email = email;
        DateOfBirth = dateOfBirth;
    }
    private string _firstName;
    private string _surName;
    private string _email;
    private string _login;
    private DateTime? _dateOfBirth;
    private DateTime _dateOfRegistration;

    private const int COUNT_ARGS = 5;
    private const int MAXLENGTH_FIRSTNAME = 50;
    private const int MAXLENGTH_SURNAME = 200;
    private const int MAXLENGTH_LOGIN = 20;

    const string REGEX_LOGIN = @"^[a-zA-Z]+$";
    const string REGEX_FIRSTNAME = @"(^[А-Я][а-яА-Я]+$)|(^[A-Z][A-Za-z]+$)";
    const string REGEX_SURNAME = @"(^[А-Я][а-яА-Я]+([-][А-Я][а-я]*)*$)|(^[A-Z][a-zA-Z]+([-][A-Z][a-z]*)*$)";
    const string REGEX_EMAIL = @"^([a-zA-Z\d])+([-_\.a-zA-Z\d][a-zA-Z\d]+)*@(([A-Za-z\d]\.)|"
                                        + @"([A-Za-z\d][-_A-Za-z\d]*[A-Za-z\d]\.)+([A-Za-z]{2,6})$)";

    new public string ToString()
    {
        if (DateOfBirth is null)
        {
            return $"{Login}, {FirstName}, {SurName}, {Email}, {String.Empty}";
        }
        else
        {
            return $"{Login}, {FirstName}, {SurName}, {Email}, {DateOfBirth.Value.ToString("dd-MM-yyyy")}";
        }
    }

    public static User FillingObjectFromString(string textObject)
    {
        string[] textSplit = textObject.Split(',');
        if (textSplit.Length == COUNT_ARGS)
        {
            return new User(textSplit[0].Trim(),
                            textSplit[1].Trim(),
                            textSplit[2].Trim(),
                            textSplit[3].Trim(),
                            Functions.StringToDateTime(textSplit[4].Trim()));
        }
        else
        {
            throw new UserExeption.UserExeption("Error while converting string to object!");
        }
    }

    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            if(value is null)
            {
                throw new UserExeption.UserExeption("FirstName error!");
            }

            if (value.Length <= MAXLENGTH_FIRSTNAME && Regex.IsMatch(value, REGEX_FIRSTNAME))
            {
                _firstName = value;
            }
            else
            {
                throw new UserExeption.UserExeption("FirstName error!");
            }
        }
    }

    public string SurName
    {
        get
        {
            return _surName;
        }
        set
        {
            if(value is null)
            {
                throw new UserExeption.UserExeption("SurName error!");
            }

            if (value.Length <= MAXLENGTH_SURNAME && Regex.IsMatch(value, REGEX_SURNAME))
            {
                _surName = value;
            }
            else
            {
                throw new UserExeption.UserExeption("SurName error!");
            }
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            if (Regex.IsMatch(value, REGEX_EMAIL))
            {
                _email = value;
            }
            else
            {
                throw new UserExeption.UserExeption("Email error!");
            }
        }
    }

    public DateTime? DateOfBirth
    {
        get
        {
            return _dateOfBirth;
        }
        set
        {
            if (value is null || (value < DateTime.Now && value < DateOfRegistration))
            {
                _dateOfBirth = value;
            }
            else
            {
                throw new UserExeption.UserExeption("DateOfBirth error!");
            }
        }
    }

    public DateTime DateOfRegistration
    {
        get
        {
            return _dateOfRegistration;
        }
        set
        {
            if (DateOfBirth is null || (DateOfBirth is not null && DateOfBirth < value))
            {
                _dateOfRegistration = value;
            }
            else
            {
                throw new UserExeption.UserExeption("DateOfRegistration error");
            }
        }
    }

    public string Login
    {
        get
        {
            return _login;
        }
        set
        {
            if(value is null)
            {
                throw new UserExeption.UserExeption("Login error!");
            }

            if (value.Length <= MAXLENGTH_LOGIN && Regex.IsMatch(value, REGEX_LOGIN))
            {
                _login = value;
            }
            else
            {
                throw new UserExeption.UserExeption("Login error!");
            }
        }
    }
}
}
