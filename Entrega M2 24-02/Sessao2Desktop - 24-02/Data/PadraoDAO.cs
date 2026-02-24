using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sessao2Desktop2.Model;

namespace Sessao2Desktop2.Data
{

    public static class Conexao
    {
        public static SqlConnection Con()
        {
            var c = new SqlConnection("Server=localhost;Database=Sessao2;User Id=sa;Password=1234;TrustServerCertificate=True");
            c.Open();
            return c;
        }
    }
    public class PadraoDAO
    {

        public Usuario Login(string l, string s)
        {
            Usuario u = new Usuario();
            using (var c = Conexao.Con())
            {

                var cmd = new SqlCommand("SELECT * FROM Usuario WHERE login = @l AND SenhaHash = @s", c);
                cmd.Parameters.AddWithValue("@l", l);
                cmd.Parameters.AddWithValue("@s", s);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        u.Id = r.GetInt32(0);
                        u.Login = r.GetString(1);
                        u.SenhaHash = r.GetString(2);
                    }
                }
                if (u.Id == null) return null;
                var cmd2 = new SqlCommand("SELECT * FROM Cliente WHERE id = @id", c);
                cmd2.Parameters.AddWithValue("@id", u.Id);
                using (var r2 = cmd2.ExecuteReader())
                {
                    if (r2.Read())
                    {
                        u.cliente = true;
                    }

                }

            }
            return u;

        }

        public int TipoDaSolicitacao(int id)
        {
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT TOP 1 p.TipoId\r\nFROM ProdutoSolicitacao ps\r\nJOIN Produto p ON p.Id = ps.ProdutoId\r\nWHERE ps.SolicitcaoId =  @id\r\nGROUP BY p.TipoId\r\nORDER BY COUNT(*) DESC", c);
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return r.GetInt32(0);
                }
            }
            return 0;


        }
        public double Getcashback()
        {
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT SUM( c.Valor) AS Valor FROM Cashback c \r\n  JOIN Solicitacao s ON s.Id = c.SolicitacaoId WHERE s.ClienteId = @id", c);
                cmd.Parameters.AddWithValue("@id", Global.user.Id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return r.GetDouble(0);
                }
            }
            return 0;


        }

        public string NomeTipo(int id)
        {
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT nome FROM TiposProduto WHERE id = @id", c);
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                        return r.GetString(0);
                }
            }
            return "";


        }
        public void RemoverTodoCashback(int idS)
        {
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("DELETE Cashback WHERE SolicitacaoId = @id", c);
                cmd.Parameters.AddWithValue("@id", idS);
                cmd.ExecuteNonQuery();

            }

        }
        public void Adicionarcashback(int idS, double valor)
        {
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("INSERT INTO Cashback(SolicitacaoId,valor) VALUES(@id,@valor)", c);
                cmd.Parameters.AddWithValue("@id", idS);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.ExecuteNonQuery();

            }

        }
        public class Solicitacao
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public DateTime Validade { get; set; }
            public string Descricao { get; set; }


        }

        public class ProdutoSolicitacao
        {
            public int Id { get; set; }
            public int SolicitacaoId { get; set; }
            public int produtoID { get; set; }
            public int Quantidade { get; set; }
        }

        public void CadastrarProdutoSolicitacao(ProdutoSolicitacao ps)
        {
            double valor = 0.00;
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[ProdutoSolicitacao]\r\n           ([SolicitcaoId]\r\n           ,[ProdutoId]\r\n           ,[Quantidade]\r\n           ,[Desconto])\r\n     VALUES\r\n           (@s\r\n           ,@p\r\n           ,@q\r\n           ,@d)", c);
                cmd.Parameters.AddWithValue("s", ps.SolicitacaoId);
                cmd.Parameters.AddWithValue("p", ps.produtoID);
                cmd.Parameters.AddWithValue("q", ps.Quantidade);
                cmd.Parameters.AddWithValue("d", 0);
                cmd.ExecuteNonQuery();
            }
        }
        public int AdicionarSolicitacao(Solicitacao s)
        {
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Solicitacao]\r\n           ([Validade]\r\n           ,[DataHoraCadastro]\r\n           ,[ClienteId]\r\n           ,[Descricao]\r\n           ,[Cashback])\r\n   " +
                    "VALUES\r\n           (@v\r\n           ,@d\r\n           ,@c\r\n           ,@de\r\n           ,null);  SELECT CAST(SCOPE_IDENTITY() AS INT) ", c);
                cmd.Parameters.AddWithValue("@v", s.Validade);
                cmd.Parameters.AddWithValue("@d", DateTime.Now);
                cmd.Parameters.AddWithValue("@c", Global.user.Id);
                cmd.Parameters.AddWithValue("@de", s.Descricao);

                return (int)cmd.ExecuteScalar();

            }

        }
        public Dictionary<int, string> Fornecedores()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT p.Id, p.Nome FROM Pessoa p\r\n  JOIN Fornecedor f ON f.Id = p.Id", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(r.GetInt32(0), r.GetString(1));
                    }
                }
            }
            return list;


        }


        public List<Produtos> TodosProdutos()
        {
            List<Produtos> list = new List<Produtos>();
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Produto", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Produtos()
                        {
                            Id = r.GetInt32(0),
                            Nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8),
                            TipoId = r.GetInt32(3),
                            FornecedorId = r.GetInt32(4),


                        });
                    }
                }
            }
            return list;


        }

        public List<Produtos> ProdutosSolicitacao(int id)
        {
            List<Produtos> list = new List<Produtos>();
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT p.*,ps.quantidade FROM Produto p\r\nJOIN ProdutoSolicitacao ps ON ps.ProdutoId = p.Id\r\nJOIN Solicitacao s ON s.Id = ps.SolicitcaoId\r\nWHERE s.Id = @id", c);
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Produtos()
                        {
                            Id = r.GetInt32(0),
                            Nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8),
                            Quantidade = r.GetInt32(9),



                        });
                    }
                }
            }
            return list;


        }
        public List<CardSolicitacaoDTO> SolicitacaoCliente(int id)
        {
            List<CardSolicitacaoDTO> list = new List<CardSolicitacaoDTO>();
            using (var c = Conexao.Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Solicitacao WHERE ClienteId=@id", c);
                cmd.Parameters.AddWithValue("@id", id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new CardSolicitacaoDTO()
                        {
                            Id = r.GetInt32(0),
                            Data = r.GetDateTime(1),
                            Descricao = r.GetString(4),
                            NomeTipo = NomeTipo(TipoDaSolicitacao(r.GetInt32(0))),
                            Produtos = ProdutosSolicitacao(r.GetInt32(0)),
                            DataCricao = r.GetDateTime(2),

                        });
                    }
                }
            }
            return list;


        }

    }
}
