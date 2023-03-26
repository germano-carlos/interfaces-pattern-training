using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboAco.Model.NSLog;

[Table("auditoria")]
public sealed class Auditoria
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id", TypeName = "INT")] public int Id { get; set; } 
    [Column("descricao", TypeName = "TEXT")] public string Descricao { get; set; }
    [Column("acao", TypeName = "VARCHAR(15)")] public string Acao { get; set; }

    public Auditoria(string descricao, string acao)
    {
        Descricao = descricao;
        Acao = acao;

        RoboAcaoContext.Get()!.AuditoriaSet.Add(this);
    }
    
    public static void Logar(string descricao, string acao)
    {
        _ = new Auditoria(descricao, acao);
    }
}