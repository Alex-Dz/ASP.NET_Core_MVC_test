using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebApp.Models.DB;

namespace WebApp.Models
{
    public class User
    {
        public int IdUsuario { get; set; }
        
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(45, ErrorMessage = "Máximo 45 caracteres")]
        public string Name { get; set; }
        
        
        /*    methods for accessing DB    */

        public List<Usuario> getAllUsers()
        {
            List<Usuario> allUsers = new List<Usuario>();
            using (var DB = new webapptestdbContext())
            {
                allUsers = DB.Usuario.ToList();
            }

            return allUsers;
        }

        public User getUserById(int idUser)
        {
            using (var db = new webapptestdbContext())
            {
                Usuario userDB = db.Usuario.Find(idUser);
                if (userDB != null)
                {
                    User user = new User()
                    {
                        IdUsuario = userDB.IdUsuario,
                        Name = userDB.Name
                    };
                    return user;
                }

                return null;
            }
        }

        public void saveUser(User newUser)
        {
            using (var db = new webapptestdbContext())
            {
                Usuario newUserDB = new Usuario()
                {
                    Name = newUser.Name
                };
                db.Usuario.Add(newUserDB);
                db.SaveChanges();
            }
        }

        public User updateUser(User user)
        {
            using (var db = new webapptestdbContext())
            {
                Usuario userDB = db.Usuario.Find(user.IdUsuario);
                if (userDB != null)
                {
                    userDB.Name = user.Name;
                    db.Entry(userDB).State = EntityState.Modified;
                    db.SaveChanges();
                    return user;
                }

                return null;
            }
        }

        public void deleteUser(int idUser)
        {
            using (var DB = new webapptestdbContext())
            {
                Usuario userDB = DB.Usuario.Find(idUser);
                if (userDB != null)
                {
                    DB.Remove(userDB);
                    DB.SaveChanges();
                }
            }
        }
    }
}