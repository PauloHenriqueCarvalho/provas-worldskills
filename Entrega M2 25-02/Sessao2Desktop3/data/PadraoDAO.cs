using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sessao2Desktop3.Model;

namespace Sessao2Desktop3.data
{
    public class PadraoDAO
    {
        public static SqlConnection Con()
        {
            var con = new SqlConnection("Server=localhost;Database=Sessao2;User id=sa;Password=1234;TrustServerCertificate=True");
            con.Open();
            return con;
        }


        public int CadastroPessoa(string nome, string t)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Pessoa]\r\n           ([Nome]\r\n           ,[Telefone])\r\n     VALUES\r\n           (@n\r\n           ,@t); SELECT CAST(SCOPE_IDENTITY() AS INT)", c);
                cmd.Parameters.AddWithValue("@n", nome);
                cmd.Parameters.AddWithValue("@t", t);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void CadastroUsuario(string login, int id, string senha)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Usuario]\r\n           ([Id]\r\n           ,[Login]\r\n           ,[SenhaHash])\r\n     VALUES\r\n           (@id\r\n           ,@l\r\n           ,@s)", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@l", login);
                cmd.Parameters.AddWithValue("@s", senha);

                cmd.ExecuteNonQuery();
            }
        }

        public void CadastroCliente(string cpf, int id, DateTime data)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Cliente]\r\n           ([Id]\r\n           ,[DataNascimento]\r\n           ,[CPF]\r\n           ,[ResponsavelId])\r\n     VALUES\r\n           (@id\r\n           ,@d\r\n           ,@c\r\n           ,null)", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", data);
                cmd.Parameters.AddWithValue("@c", cpf);

                cmd.ExecuteNonQuery();
            }
        }
        public void CadastroFornecedor(string razao, int id, string cnpj)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Fornecedor]\r\n           ([Id]\r\n           ,[RazaoSocial]\r\n           ,[CNPJ])\r\n     VALUES\r\n           (@id\r\n           ,@r\r\n           ,@c)", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@r", razao);
                cmd.Parameters.AddWithValue("@c", cnpj);

                cmd.ExecuteNonQuery();
            }
        }


        public int CadastroSolicitacao(CardSolicitacaoDTO s)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Solicitacao]\r\n           ([Validade]\r\n           ,[DataHoraCadastro]\r\n           ,[ClienteId]\r\n           ,[Descricao]\r\n           ,[Cashback])\r\n     VALUES\r\n           (@v\r\n           ,@da\r\n           ,@c\r\n           ,@d\r\n           ,null); SELECT CAST(SCOPE_IDENTITY() AS INT)", c);
                cmd.Parameters.AddWithValue("@v", s.Vencimento);
                cmd.Parameters.AddWithValue("@da", DateTime.Now);
                cmd.Parameters.AddWithValue("@c", Global.user.id);
                cmd.Parameters.AddWithValue("@d", s.Descricao);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void CadastroProdutoSolicitacao(Produto p, int id)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[ProdutoSolicitacao]\r\n           ([SolicitcaoId]\r\n           ,[ProdutoId]\r\n           ,[Quantidade]\r\n           ,[Desconto])\r\n     VALUES\r\n           (@s\r\n           ,@p\r\n           ,@q\r\n           ,null)", c);
                cmd.Parameters.AddWithValue("@s", id);
                cmd.Parameters.AddWithValue("@p", p.Id);
                cmd.Parameters.AddWithValue("@q", p.Quantidade);
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteSolicitacao(int idSolicitacao)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("DELETE ProdutoSolicitacao WHERE SolicitcaoId = @id", c);
                cmd.Parameters.AddWithValue("@id", idSolicitacao);
                cmd.ExecuteNonQuery();

                var cmd2 = new SqlCommand("DELETE Cashback WHERE SolicitacaoId = @id", c);
                cmd2.Parameters.AddWithValue("@id", idSolicitacao);
                cmd2.ExecuteNonQuery();

                var cmd3 = new SqlCommand("DELETE Solicitacao WHERE Id = @id", c);
                cmd3.Parameters.AddWithValue("@id", idSolicitacao);
                cmd3.ExecuteNonQuery();
            }
        }
        public void DeleteCashback(int idS)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("DELETE Cashback WHERE SolicitacaoId = @id", c);
                cmd.Parameters.AddWithValue("@id", idS);
                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarEstoque(int idProd, int qtd)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("UPDATE Produto SET Estoque = @q WHERE Id = @id", c);
                cmd.Parameters.AddWithValue("@q", qtd);
                cmd.Parameters.AddWithValue("@id", idProd);

                cmd.ExecuteNonQuery();
            }
        }

        public void CadastroCashback(double valor, int id)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Cashback]\r\n           ([SolicitacaoId]\r\n           ,[Valor])\r\n     VALUES\r\n           (@id\r\n           ,@v)", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@v", valor);
                cmd.ExecuteNonQuery();
            }
        }



        public int TipoSolicitacao(int id)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT TOP 1 t.id  FROM TiposProduto t\r\n  JOIN Produto p ON t.Id = p.TipoId\r\n  JOIN ProdutoSolicitacao ps ON ps.ProdutoId = p.Id\r\n  WHERE ps.SolicitcaoId = @id\r\n  GROUP BY t.id\r\n  ORDER BY COUNT(*) DESC", c);
                cmd.Parameters.AddWithValue("id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return r.GetInt32(0);
                    }
                }
            }
            return 0;
        }
        public double GetCashback()
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT SUM(c.valor) AS Valor FROM Cashback c JOIN Solicitacao s ON s.Id = c.Id WHERE s.ClienteId = @id", c);
                cmd.Parameters.AddWithValue("id", Global.user.id);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                    return Convert.ToDouble(result);
            }
            return 0;
        }
        public List<Produto> ProdutoSolicitacao(int id)
        {
            List<Produto> lista = new List<Produto>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT p.*, ps.Quantidade FROM Produto p JOIN ProdutoSolicitacao ps ON  p.Id = ps.ProdutoId WHERE ps.SolicitcaoId =@id", c);
                cmd.Parameters.AddWithValue("id", id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Produto()
                        {
                            Id = r.GetInt32(0),
                            Nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8),
                            Quantidade = r.GetInt32(9)

                        });
                    }
                }

            }
            return lista;
        }


        public Dictionary<int, string> GetFornecedor()
        {
            Dictionary<int, string> lista = new Dictionary<int, string>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Fornecedor", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(r.GetInt32(0), r.GetString(1));
                    }
                }

            }
            return lista;
        }

        public List<Produto> GetProdutos()
        {
            List<Produto> lista = new List<Produto>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT p.*, f.RazaoSocial FROM Produto p JOIN Fornecedor f ON f.id = p.FornecedorId", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Produto()
                        {
                            Id = r.GetInt32(0),
                            Nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8),
                            Tipoid = r.GetInt32(3),
                            FornecedorId = r.GetInt32(4),
                            Fornecedor = r.GetString(9)

                        });
                    }
                }

            }
            return lista;
        }

        public List<Produto> GetProdutosfornecedor()
        {
            List<Produto> lista = new List<Produto>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT p.*, t.Nome AS tipo\r\nFROM Produto p \r\nJOIN TiposProduto t ON t.Id = p.TipoId\r\nWHERE p.fornecedorid= @id", c);
                cmd.Parameters.AddWithValue("id", Global.user.id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Produto()
                        {
                            Id = r.GetInt32(0),
                            Nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8),
                            Cadastro = r.GetDateTime(7),
                            Tipoid = r.GetInt32(3),
                            Tipo = r.GetString(9),

                        });
                    }
                }

            }
            return lista;
        }

        public List<CardSolicitacaoDTO> ListaSolicitacoesUsuario()
        {
            List<CardSolicitacaoDTO> lista = new List<CardSolicitacaoDTO>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Solicitacao WHERE ClienteId=@id", c);
                cmd.Parameters.AddWithValue("id", Global.user.id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new CardSolicitacaoDTO()
                        {
                            Id = r.GetInt32(0),
                            Vencimento = r.GetDateTime(1),
                            DataCadastro = r.GetDateTime(2),
                            Descricao = r.GetString(4),
                            tipoId = TipoSolicitacao(r.GetInt32(0)),
                            Produtos = ProdutoSolicitacao(r.GetInt32(0))
                        });
                    }
                }


            }
            return lista;
        }

        public Usuario Login(string l, string s)
        {
            var u = new Usuario();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Usuario WHERE Login= @l AND SenhaHash=@s", c);
                cmd.Parameters.AddWithValue("@l", l);
                cmd.Parameters.AddWithValue("@s", s);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        u.id = r.GetInt32(0);

                    }
                }

                if (u.id != 0)
                {
                    var cmd2 = new SqlCommand("SELECT * FROM Cliente WHERE Id= @id", c);
                    cmd2.Parameters.AddWithValue("@id", u.id);
                    using (var r2 = cmd2.ExecuteReader())
                    {
                        if (r2.Read())
                        {
                            u.cliente = true;
                        }

                    }
                    return u;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
