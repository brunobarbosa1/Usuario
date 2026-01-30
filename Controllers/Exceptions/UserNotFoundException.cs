namespace Usuario.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string mensagem) : base(mensagem)
    {
    }
}