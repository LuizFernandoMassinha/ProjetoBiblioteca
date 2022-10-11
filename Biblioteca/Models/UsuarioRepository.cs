using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Linq;
using System.Collections;

namespace Biblioteca.Models
{

public class UsuarioRepository
{
     public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuario.Add(u);
                bc.SaveChanges();
            }
        }

    public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario Usuario = bc.Usuario.Find(u.IdUsuario);
                Usuario.nomeUsuario = u.nomeUsuario;
                Usuario.loginUsuario = u.loginUsuario;
                Usuario.datadenascimentoUsuario = u.datadenascimentoUsuario;
                Usuario.senhaUsuario = u.senhaUsuario;
                Usuario.emailUsuario = u.emailUsuario;

                bc.SaveChanges();
            }
        }

         public ICollection<Usuario> ListarTodos(FiltrosUsuario filtro = null)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                
                if(filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "nomeUsuario":
                            query = bc.Usuario.Where(u => u.nomeUsuario.Contains(filtro.Filtro));
                        break;

                        default:
                            query = bc.Usuario;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuario;
                }
                
                //ordenação padrão
                return query.OrderBy(u => u.IdUsuario).ToList();
            }
        }

         public Usuario ObterPorId(int IdUsuario)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuario.Find(IdUsuario);
            }
        }
}
}


