using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoboAco.Model.NSLog;

namespace RoboAco.Model;

public class RoboAcaoContext : DbContext
{
    private static AsyncLocal<RoboAcaoContext?> _instance = new ();

		internal static RoboAcaoContext? Get()
		{
			if (_instance.Value == null)
				throw new Exception("Uma transação não pode ser iniciada sem título.");
			return _instance.Value;
		}

		internal static RoboAcaoContext Get(string titulo)
		{
			if (_instance.Value != null)
				throw new Exception($"Uma transação só pode ter um título {titulo}.");
			return _instance.Value = new RoboAcaoContext(titulo);
		}

		internal static RoboAcaoContext Get(string titulo, string detalhes)
		{
			if (_instance.Value != null)
				throw new Exception($"Uma transação só pode ter um título {titulo}.");
			return _instance.Value = new RoboAcaoContext(titulo, detalhes);
		}

		internal static void ResetContext()
		{
			_instance.Value = null;
		}
		
		public DbSet<Auditoria> AuditoriaSet { get; set; }
		
		private RoboAcaoContext(string titulo) 
		{ 
			//<#keep(criacao)#><#/keep(criacao)#>
		}
		private RoboAcaoContext(string titulo, string detalhes)
		{
			//<#keep(criacao2)#><#/keep(criacao2)#>
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) 
				return;

			var cs = "";
			optionsBuilder.UseMySql(cs, new MySqlServerVersion(new Version(8, 0, 28)));
				
			if (Debugger.IsAttached)
			{
				optionsBuilder.UseLoggerFactory(LoggerFactory.Create(b => b
						.AddConsole()
						.AddFilter(level => level >= LogLevel.Information)))
					.EnableSensitiveDataLogging()
					.EnableDetailedErrors();
			}
		}
		//<#keep(generico)#><#/keep(generico)#>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//<#keep(index)#>
			// modelBuilder
			// 	.HasDbFunction(typeof(ConnectInfoContext).GetMethod(nameof(WeekDay)))
			// 	.HasTranslation(args =>
			// 		SqlFunctionExpression.Create(
			// 		"WEEKDAY", args, typeof(int?), null));

			// para chave composta
			//modelBuilder.Entity<Order>().HasKey(o => new { o.CustomerAbbreviation, o.OrderNumber });

			//modelBuilder.Entity<Solicitacao>()
			//	.HasOne(c => c.IFDestino)
			//	.WithOne

			/*
			modelBuilder.Entity<Solicitacao>().HasIndex(s => new {
				s.CPFCliente,
				s.CNPJEmpregador,
				s.IdIFFolha
			});
			modelBuilder.Entity<InstituicaoFinanceira>().HasIndex(s => s.CNPJ).IsUnique();
			*/

			//<#/keep(index)#>
		}
		public override int SaveChanges()
		{
			return base.SaveChanges();
		}
		public override void Dispose()
		{
			base.Dispose();
			_instance.Value = null;
			//<#keep(dispose)#><#/keep(dispose)#>
		}
		public override async ValueTask DisposeAsync()
		{
			await base.DisposeAsync();
			_instance.Value = null;
			//<#keep(dispose)#><#/keep(dispose)#>
		}
}