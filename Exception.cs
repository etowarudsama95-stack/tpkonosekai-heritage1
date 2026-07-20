


using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using MySqlConnector;
class KonoEvenementException : Exception

{
    public KonoEvenementException(string message) : base(message)
    {

    }
    public KonoEvenementException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}

class AmeException : KonoEvenementException
{
    public AmeException(string message) : base(message)
    {

    }
}

class EtoException : KonoEvenementException
{
    public EtoException(string message) : base(message)
    {

    }
    

}


class CelestiaException : KonoEvenementException
{
    public CelestiaException(string message) : base(message)
    {

    }
}

class EnergieInsuffisante : KonoEvenementException 
{



    public EnergieInsuffisante(string message) : base(message)
    {

    }
    public EnergieInsuffisante(String message, Exception innerException) : base(message, innerException)
    {

    }

}

class TechniqueException : KonoEvenementException
{
    public TechniqueException(string message) : base(message)
    {

    }
    public TechniqueException(string message, Exception innerException) : base(message, innerException)
    {

    }
}

    class AkariException : KonoEvenementException
    {
        public AkariException(string message) : base(message)
        {

        }

    }


class UmiException : KonoEvenementException
{
    public UmiException(string message) : base(message)
    {

    }
}

class RairyuException : KonoEvenementException
{
    public RairyuException(string message) : base(message)
    {

    }
}


class StellaException : Exception
{
    public StellaException (string message) :base(message)
    {
        
    }
}

class KoNotImplemented : NotImplementedException
{


}


