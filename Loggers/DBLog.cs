using RoboAco.Classes.Interfaces;
using RoboAco.Model.NSLog;

namespace RoboAco.Loggers;

public class DBLog : ILog
{
    public void Logar(string msg, string acao)
    {
        Auditoria.Logar(msg, acao);
    }
}