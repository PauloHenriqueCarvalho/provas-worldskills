using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sessao2._1302.Data;
using Sessao2._1302.Models;
using static Sessao2._1302.View.ProdutoView;


namespace Sessao2._1302.Services
{
    public class PadraoDAO
    {
        public static SqlConnection Con()
        {
            var c = new SqlConnection("Server=localhost;Database=Sessao2;User Id=sa;Password=1234;TrustServerCertificate=True");
            c.Open();
            return c;
        }


        public double CashbackUsuario()
        {
            double valor = 0.00;
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT c.valor FROM Cashback c\r\n  JOIN Solicitacao s ON s.Id = c.SolicitacaoId\r\n  WHERE s.ClienteId = @id", c);
                cmd.Parameters.AddWithValue("id", Global.user.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        valor += r.GetDouble(0);
                    }
                }
            }
            return valor;
        }


        public int CadastrarSolicitacao(Solicitacao s)
        {
            double valor = 0.00;
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Solicitacao]\r\n           ([Validade]\r\n           ,[DataHoraCadastro]\r\n           ,[ClienteId]\r\n           ,[Descricao])\r\n         \r\n     VALUES\r\n           (@v\r\n           ,@cad\r\n           ,@cli\r\n           ,@des);  SELECT CAST(SCOPE_IDENTITY() AS INT)", c);
                cmd.Parameters.AddWithValue("v", s.Validade);
                cmd.Parameters.AddWithValue("cad", DateTime.Now);
                cmd.Parameters.AddWithValue("cli", Global.user.Id);
                cmd.Parameters.AddWithValue("des", s.Descricao);
                return (int)cmd.ExecuteScalar();
            }
        }
        public void CadastrarProdutoSolicitacao(ProdutoSolicitacao ps)
        {
            double valor = 0.00;
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[ProdutoSolicitacao]\r\n           ([SolicitcaoId]\r\n           ,[ProdutoId]\r\n           ,[Quantidade]\r\n           ,[Desconto])\r\n     VALUES\r\n           (@s\r\n           ,@p\r\n           ,@q\r\n           ,@d)", c);
                cmd.Parameters.AddWithValue("s", ps.SolicitacaoId);
                cmd.Parameters.AddWithValue("p", ps.produtoID);
                cmd.Parameters.AddWithValue("q", ps.Quantidade);
                cmd.Parameters.AddWithValue("d", 0);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateSolicitacao(Solicitacao ps)
        {
            double valor = 0.00;
            using (var c = Con())
            {
                var cmd = new SqlCommand("UPDATE Solicitacao SET Descricao =@d, Validade = @v WHERE id = @id", c);
                cmd.Parameters.AddWithValue("d", ps.Descricao);
                cmd.Parameters.AddWithValue("v", ps.Validade);
                cmd.Parameters.AddWithValue("id", ps.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void ExcluirSolicitacao(int idSol)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("DELETE Solicitacao WHERE id = @s ", c);
                cmd.Parameters.AddWithValue("s", idSol);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirCashbackSolicitacao(int idSol)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("DELETE cashback WHERE SolicitacaoId = @s", c);
                cmd.Parameters.AddWithValue("s", idSol);
                cmd.ExecuteNonQuery();
            }
        }
        public void ExcluirProdutoSolicitacao(int idSol)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("DELETE ProdutoSolicitacao WHERE SolicitcaoId = @s", c);
                cmd.Parameters.AddWithValue("s", idSol);
                cmd.ExecuteNonQuery();
            }
        }
        public void CadastroUsuario(Usuarios u)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO Usuario (id,login,senhaHash) VALUES(@id,@l,@s);", c);
                cmd.Parameters.AddWithValue("@id", u.Id);
                cmd.Parameters.AddWithValue("@l", u.Login);
                cmd.Parameters.AddWithValue("@s", u.SenhaHash);
                cmd.ExecuteNonQuery();
            }
        }

        public int CadastroPessoa(Pessoa u)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO Pessoa (Nome,Telefone) VALUES(@l,@s);  SELECT SCOPE_IDENTITY()", c);
                cmd.Parameters.AddWithValue("l", u.nome);
                cmd.Parameters.AddWithValue("s", u.telefone);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        //public void CadastroProduto(Produto u)
        //{
        //    using (var c = Con())
        //    {
        //        var cmd = new SqlCommand("INSERT INTO Produto (Nome,Valor,CPF) VALUES(@id,@l,@s);", c);
        //        cmd.Parameters.AddWithValue("id", u.ID);
        //        cmd.Parameters.AddWithValue("l", u.DataNasciment);
        //        cmd.Parameters.AddWithValue("s", u.CPF);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        public void CadastroCliente(Cliente u)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO Cliente (id,DataNascimento,CPF) VALUES(@id,@l,@s);", c);
                cmd.Parameters.AddWithValue("id", u.ID);
                cmd.Parameters.AddWithValue("l", u.DataNasciment);
                cmd.Parameters.AddWithValue("s", u.CPF);
                cmd.ExecuteNonQuery();
            }
        }

        public void CadastroFornecedor(Fornecedor u)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("INSERT INTO Fornecedor (id,RazaoSocial,Cnpj) VALUES(@id,@l,@s);", c);
                cmd.Parameters.AddWithValue("id", u.Id);
                cmd.Parameters.AddWithValue("l", u.RazaoSocial);
                cmd.Parameters.AddWithValue("s", u.CNPJ);
                cmd.ExecuteNonQuery();
            }
        }


        public void ExcluirProdutoSolicitacao(int idSol, int idProd)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("DELETE ProdutoSolicitacao WHERE SolicitcaoId = @s AND ProdutoId = @p", c);
                cmd.Parameters.AddWithValue("s", idSol);
                cmd.Parameters.AddWithValue("p", idProd);
                cmd.ExecuteNonQuery();
            }
        }

        public void GerarCashback(int idSol, double valor)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("  INSERT INTO Cashback(SolicitacaoId,Valor) VALUES(@s,@v)", c);
                cmd.Parameters.AddWithValue("s", idSol);
                cmd.Parameters.AddWithValue("v", valor);
                cmd.ExecuteNonQuery();
            }
        }

        public void AtualizarEstoque(ProdutoSolicitacao ps)
        {
            double valor = 0.00;
            using (var c = Con())
            {
                var cmd = new SqlCommand("UPDATE Produto SET Estoque = @qtd WHERE id = @id", c);
                cmd.Parameters.AddWithValue("qtd", ps.EstoqueAtual);
                cmd.Parameters.AddWithValue("id", ps.produtoID);
                cmd.ExecuteNonQuery();
            }
        }
        public Usuarios Login(string login, string senha)
        {
            Usuarios u = new Usuarios();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Usuario WHERE Login = @l AND SenhaHash=@s", c);
                cmd.Parameters.AddWithValue("l", login);
                cmd.Parameters.AddWithValue("s", senha);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        u = new Usuarios()
                        {
                            Id = r.GetInt32(0),
                            Login = r.GetString(1),
                            SenhaHash = r.GetString(2),
                        };


                    }
                    else return null;
                }
                var cmd2 = new SqlCommand("select * from Cliente WHERE id = @i", c);
                cmd2.Parameters.AddWithValue("i", u.Id);
                using (var r2 = cmd2.ExecuteReader())
                {
                    if (r2.Read())
                    {
                        u.cliente = true;
                    }
                    else
                    {
                        u.cliente = false;
                    }
                }
                return u;

            }
            return null;
        }


        public class ProdutoSolicitacaoDTO
        {
            public double valorProduto { get; set; }
            public int quantidade { get; set; }
            public string nome { get; set; }
        }

        public List<ProdutoSolicitacaoDTO> ProdutoPorSolicitacao(int idSolicitacao)
        {
            List<ProdutoSolicitacaoDTO> u = new List<ProdutoSolicitacaoDTO>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT \r\n  ps.Quantidade,\r\n  p.Valor,\r\n  p.Nome\r\n  FROM ProdutoSolicitacao ps\r\n  JOIN Produto p ON p.Id = ps.ProdutoId\r\n  WHERE ps.SolicitcaoId = @id", c);
                cmd.Parameters.AddWithValue("id", idSolicitacao);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        u.Add(new ProdutoSolicitacaoDTO()
                        {
                            quantidade = r.GetInt32(0),
                            valorProduto = r.GetDouble(1),
                            nome = r.GetString(2),
                        });


                    }

                }


            }
            return u;
        }




        public List<Produto> ListaProduto()
        {
            var l = new List<Produto>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT * FROM Produto", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        l.Add(new Produto
                        {
                            Id = r.GetInt32(0),
                            nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Tipoid = r.GetInt32(3),
                            FornecedorID = r.GetInt32(4),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8)

                        });
                    }
                }
            }
            return l;
        }



        public List<ProdutoDataDTO> ListaProdutoFornecedor()
        {
            var l = new List<ProdutoDataDTO>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT p.Nome, t.Nome AS Tipo, p.Validade,p.DataHoraCadastro,p.id  FROM Produto p JOIN TiposProduto t ON p.TipoId = t.Id WHERE p.FornecedorId = @id", c);
                cmd.Parameters.AddWithValue("id", Global.user.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        l.Add(new ProdutoDataDTO
                        {
                            Nome = r.GetString(0),
                            Tipo = r.GetString(1),
                            DataValidade = r.GetDateTime(2),
                            DataCadastro = r.GetDateTime(3),
                            Id = r.GetInt32(4),


                        });
                    }
                }
            }
            return l;
        }

        public List<Produto> ListaProdutoAdicionados(int id)
        {
            var l = new List<Produto>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT p.*\r\nFROM Produto p\r\nJOIN ProdutoSolicitacao ps ON ps.ProdutoId = p.Id\r\nWHERE ps.SolicitcaoId = @id", c);
                cmd.Parameters.AddWithValue("id", id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        l.Add(new Produto
                        {
                            Id = r.GetInt32(0),
                            nome = r.GetString(1),
                            Valor = r.GetDouble(2),
                            Tipoid = r.GetInt32(3),
                            FornecedorID = r.GetInt32(4),
                            Descricao = r.GetString(5),
                            Validade = r.GetDateTime(6),
                            Estoque = r.GetInt32(8)

                        });
                    }
                }
            }
            return l;
        }



        public List<SolicitacaoDTO> SolicitacaoClienteLogado()
        {
            List<SolicitacaoDTO> u = new List<SolicitacaoDTO>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("WITH TipoMaisFrequente AS\r\n(\r\n    SELECT \r\n        " +
                    "ps.SolicitcaoId,\r\n        p.TipoId,\r\n        COUNT(*) AS Total,\r\n       " +
                    " ROW_NUMBER() OVER (\r\n            PARTITION BY ps.SolicitcaoId\r\n            " +
                    "ORDER BY COUNT(*) DESC\r\n        ) AS rn\r\n    FROM ProdutoSolicitacao ps\r\n  " +
                    "  JOIN Produto p ON p.Id = ps.ProdutoId\r\n    GROUP BY ps.SolicitcaoId, p.TipoId\r\n)\r\nSELECT " +
                    "\r\n    s.Id,\r\n    s.Descricao,\r\n    s.Validade,\r\n    tp.Id AS TipoId, tp.Nome\r\nFROM Solicitacao s\r\nJOIN TipoMaisFrequente tm \r\n    ON tm.SolicitcaoId = s.Id\r\n    AND tm.rn = 1\r\nJOIN TiposProduto tp \r\n    ON tp.Id = tm.TipoId\r\nWHERE s.ClienteId = @id\r\nORDER BY s.Validade ASC;\r\n\r\n\r\n", c);
                cmd.Parameters.AddWithValue("id", Global.user.Id);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        u.Add(new SolicitacaoDTO()
                        {
                            Id = r.GetInt32(0),
                            Descricao = r.GetString(1),
                            Data = r.GetDateTime(2),
                            Tipo = r.GetInt32(3),
                            TipoNome = r.GetString(4),
                            listaProduto = ProdutoPorSolicitacao(r.GetInt32(0))

                        });

                    }
                }


            }
            return u;
        }


        public List<string> NomesFornecedores()
        {
            List<string> nome = new List<string>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT DISTINCT f.Nome FROM Pessoa f JOIN Produto p ON p.FornecedorId = f.id", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        nome.Add(r.GetString(0));

                    }
                }


            }
            return nome;
        }

        public List<TipoProduto> GetTipoProduto()
        {
            List<TipoProduto> tipos = new List<TipoProduto>();
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT * FROM TiposProduto", c);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        tipos.Add(new TipoProduto
                        {
                            Id = r.GetInt32(0),
                            Nome = r.GetString(1),
                        });

                    }
                }


            }
            return tipos;
        }
        public string NomeFornecedor(int id)
        {
            using (var c = Con())
            {
                var cmd = new SqlCommand("SELECT f.Nome FROM Pessoa f JOIN Produto p ON p.FornecedorId = f.id WHERE p.id = @id", c);
                cmd.Parameters.AddWithValue("id", id);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return r.GetString(0);

                    }
                }


            }
            return null;
        }

    }
}