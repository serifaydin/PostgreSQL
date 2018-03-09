using Npgsql;
using PostgreSQL.Entities;
using System.Collections.Generic;

namespace PostgreSQL.Service
{
    public class tblUserService : StateConnection, IService<tbluser>
    {
        public EntityResult<tbluser> GetList()
        {
            EntityResult<tbluser> result = new EntityResult<tbluser>();
            result.Result = true;
            result.ErrorText = "Success";

            try
            {
                List<tbluser> userList = new List<tbluser>();
                NpgsqlCommand command = new NpgsqlCommand("select * from public.tbluser", ConnectionOpen());
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tbluser user = new tbluser();
                    user.ID = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Surname = reader.GetString(2);
                    user.BirthDate = reader.GetDateTime(3);

                    userList.Add(user);
                }

                result.Objects = userList;
                ConnectionClosed();
            }
            catch (NpgsqlException ex)
            {
                result.Result = false;
                result.ErrorText = ex.Message;
            }
            return result;
        }

        public EntityResult<tbluser> Insert(tbluser entities)
        {
            EntityResult<tbluser> result = new EntityResult<tbluser>();
            result.Result = true;
            result.ErrorText = "success";

            try
            {
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO public.tbluser(name,surname,birthdate) VALUES(@name, @surname, @birthdate);", ConnectionOpen());
                command.Parameters.AddWithValue("@name", entities.Name);
                command.Parameters.AddWithValue("@surname", entities.Surname);
                command.Parameters.AddWithValue("@birthdate", entities.BirthDate);

                command.ExecuteNonQuery();
                ConnectionClosed();
            }
            catch (NpgsqlException ex)
            {
                result.ErrorText = ex.Message;
                result.Result = false;
            }

            return result;
        }

        public EntityResult<tbluser> Delete(tbluser entities)
        {
            throw new System.NotImplementedException();
        }

        public EntityResult<tbluser> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public EntityResult<tbluser> Update(tbluser entities)
        {
            throw new System.NotImplementedException();
        }
    }
}