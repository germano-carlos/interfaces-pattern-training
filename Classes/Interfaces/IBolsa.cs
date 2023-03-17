namespace RoboAco.Classes.Interfaces;

public interface IBolsa
{
    public string Name { get; set; }
    public void MonitorarAtivo(string ativo);
    public void VerificarPreco();
    public void Compra(string ativo);
    public void Vender(string ativo);
}